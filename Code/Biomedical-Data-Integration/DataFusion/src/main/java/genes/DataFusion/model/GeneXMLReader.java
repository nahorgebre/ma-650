package genes.DataFusion.model;

import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleFactory;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroup;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute> implements FusibleFactory<Gene, Attribute> {

    @Override
    protected void initialiseDataset(DataSet<Gene, Attribute> dataset) {
        super.initialiseDataset(dataset);

        dataset.addAttribute(Gene.ENSEMBLID);
        dataset.addAttribute(Gene.NCBIID);
        dataset.addAttribute(Gene.GENENAMES);
        dataset.addAttribute(Gene.GENEDESCRIPTION);

        dataset.addAttribute(Gene.ORGANS);
        dataset.addAttribute(Gene.PUBLICATIONMENTIONS);
        dataset.addAttribute(Gene.PATENTMENTIONS);
        dataset.addAttribute(Gene.DISEASEASSOCIATIONS);
    }

    @Override
    public Gene createModelFromElement(Node node, String provenanceInfo) {
        String recordId = getValueFromChildElement(node, "recordId");

        Gene gene = new Gene(recordId, provenanceInfo);

        gene.setEnsemblId(getValueFromChildElement(node, "ensemblId"));
        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));
        List<GeneName> geneNames = getObjectListFromChildElement(node, "geneNames", "geneName", new GeneNameXMLReader(), provenanceInfo);
        gene.setGeneNames(geneNames);
        List<geneDescription> geneDescriptions = getObjectListFromChildElement(node, "geneDescriptions", "geneDescriptions", new geneDescriptionXMLReader(), provenanceInfo);
        gene.setGeneDescription(geneDescriptions);
        
        List<Organ> organs = getObjectListFromChildElement(node, "organs", "organs", new OrganXMLReader(), provenanceInfo);
        gene.setOrgans(organs);
        List<Publication> publicationMentions = getObjectListFromChildElement(node, "publicationMentions", "publicationMentions", new PublicationXMLReader(), provenanceInfo);
        gene.setPublicationMentions(publicationMentions);
        List<Patent> patentMentions = getObjectListFromChildElement(node, "patentMentions", "patentMentions", new PatentXMLReader(), provenanceInfo);
        gene.setPatentMentions(patentMentions);
        List<Disease> diseaseAssociations = getObjectListFromChildElement(node, "diseaseAssociations", "diseaseAssociations", new DiseaseXMLReader(), provenanceInfo);
        gene.setDiseaseAssociations(diseaseAssociations);

        return gene;
    }

    @Override
    public Gene createInstanceForFusion(RecordGroup<Gene, Attribute> cluster) {

        List<String> ids = new LinkedList<>();

        for (Gene m : cluster.getRecords()) {
            ids.add(m.getIdentifier());
        }

        Collections.sort(ids);

        String mergedId = StringUtils.join(ids, '+');

        return new Gene(mergedId, "fused");
    }
}
