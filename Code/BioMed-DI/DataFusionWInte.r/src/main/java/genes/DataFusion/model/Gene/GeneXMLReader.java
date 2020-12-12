package genes.DataFusion.model.Gene;

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

import genes.DataFusion.model.Disease.Disease;
import genes.DataFusion.model.Disease.DiseaseXMLReader;
import genes.DataFusion.model.Organ.Organ;
import genes.DataFusion.model.Organ.OrganXMLReader;
import genes.DataFusion.model.Patent.Patent;
import genes.DataFusion.model.Patent.PatentXMLReader;
import genes.DataFusion.model.Publication.Publication;
import genes.DataFusion.model.Publication.PublicationXMLReader;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute> implements FusibleFactory<Gene, Attribute> {

    @Override
    protected void initialiseDataset(DataSet<Gene, Attribute> dataset) {
        super.initialiseDataset(dataset);

        dataset.addAttribute(Gene.ENSEMBLID);
        dataset.addAttribute(Gene.NCBIID);
        dataset.addAttribute(Gene.GENENAMES);
        dataset.addAttribute(Gene.GENEDESCRIPTIONS);

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

        gene.setGeneNames(getValueFromChildElement(node, "geneNames"));

        gene.setGeneDescriptions(getValueFromChildElement(node, "geneDescriptions"));
        
        List<Organ> organs = getObjectListFromChildElement(node, "organs", "organ", new OrganXMLReader(), provenanceInfo);
        gene.setOrgans(organs);

        List<Publication> publicationMentions = getObjectListFromChildElement(node, "publicationMentions", "publicationMention", new PublicationXMLReader(), provenanceInfo);
        gene.setPublicationMentions(publicationMentions);

        List<Patent> patentMentions = getObjectListFromChildElement(node, "patentMentions", "patentMention", new PatentXMLReader(), provenanceInfo);
        gene.setPatentMentions(patentMentions);

        List<Disease> diseaseAssociations = getObjectListFromChildElement(node, "diseaseAssociations", "diseaseAssociation", new DiseaseXMLReader(), provenanceInfo);
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
