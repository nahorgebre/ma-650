package genes.IdentityResolution.model.Gene;

import java.util.List;

import org.w3c.dom.Node;

import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.model.io.XMLMatchableReader;
import genes.IdentityResolution.model.Disease.Disease;
import genes.IdentityResolution.model.Disease.DiseaseXMLReader;
import genes.IdentityResolution.model.Organ.Organ;
import genes.IdentityResolution.model.Organ.OrganXMLReader;
import genes.IdentityResolution.model.Patent.Patent;
import genes.IdentityResolution.model.Patent.PatentXMLReader;
import genes.IdentityResolution.model.Publication.Publication;
import genes.IdentityResolution.model.Publication.PublicationXMLReader;

public class GeneXMLReader extends XMLMatchableReader<Gene, Attribute> {

    @Override
    protected void initialiseDataset(DataSet<Gene, Attribute> dataset) {

        super.initialiseDataset(dataset);

    }

    @Override
    public Gene createModelFromElement(Node node, String provenanceInfo) {

        String recordId = getValueFromChildElement(node, "recordId");

        Gene gene = new Gene(recordId, provenanceInfo);

        gene.setEnsemblId(getValueFromChildElement(node, "ensemblId"));

        gene.setNcbiId(getValueFromChildElement(node, "ncbiId"));

        gene.setGeneNames(getValueFromChildElement(node, "geneNames"));

        gene.setGeneDescriptions(getValueFromChildElement(node, "geneDescriptions"));

        gene.setOverallCall(getValueFromChildElement(node, "overallCall"));

        gene.setFirstPublicationYear(getValueFromChildElement(node, "firstPublicationYear"));

        gene.setFrequencyPatent(getValueFromChildElement(node, "frequencyPatent"));

        gene.setFrequencyPatentTitle(getValueFromChildElement(node, "frequencyPatentTitle"));

        gene.setFrequencyPatentAbstract(getValueFromChildElement(node, "frequencyPatentAbstract"));

        gene.setFrequencyPatentDescription(getValueFromChildElement(node, "frequencyPatentDescription"));

        gene.setFrequencyPatentClaims(getValueFromChildElement(node, "frequencyPatentClaims"));

        
        List<Organ> organs = getObjectListFromChildElement(node, "organs", "organ", new OrganXMLReader(), provenanceInfo);

        gene.setOrgans(organs);

        List<Disease> diseases = getObjectListFromChildElement(node, "diseaseAssociations", "diseaseAssociation", new DiseaseXMLReader(), provenanceInfo);
        
        gene.setDiseases(diseases);

        List<Publication> publications = getObjectListFromChildElement(node, "publicationMentions", "publicationMention", new PublicationXMLReader(), provenanceInfo);
        
        gene.setPublications(publications);

        List<Patent> patents = getObjectListFromChildElement(node, "patentMentions", "patentMention", new PatentXMLReader(), provenanceInfo);
        
        gene.setPatents(patents);

        return gene;
        
    }

}