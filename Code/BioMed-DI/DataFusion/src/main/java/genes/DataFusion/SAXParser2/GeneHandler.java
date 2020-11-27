package genes.DataFusion.SAXParser2;

import java.util.ArrayList;
import java.util.List;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import genes.DataFusion.SAXParser2.Disease.Disease;
import genes.DataFusion.SAXParser2.Disease.ReadDiseaseXML;
import genes.DataFusion.SAXParser2.Organ.Organ;
import genes.DataFusion.SAXParser2.Organ.ReadOrganXML;
import genes.DataFusion.SAXParser2.Patent.Patent;
import genes.DataFusion.SAXParser2.Patent.ReadPatentXML;
import genes.DataFusion.SAXParser2.Publication.Publication;
import genes.DataFusion.SAXParser2.Publication.ReadPublicationXML;

public class GeneHandler extends DefaultHandler {

    private boolean hasRecordId = false;
    private boolean hasEnsemblId = false;
    private boolean hasNcbiId = false;
    private boolean hasGeneNames = false;
    private boolean hasGeneDescriptions = false;

    private boolean hasOrgans = false;
    private boolean hasDiseases = false;
    private boolean hasPatents = false;
    private boolean hasPublications = false;

    private List<Gene> geneList = null;
    private Gene gene = null;

    public List<Gene> getEmpList() {
        return geneList;
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {

        if (qName.equalsIgnoreCase("Gene")) {

            Gene gene = new Gene();

            if (geneList == null)
                geneList = new ArrayList<>();

        } else if (qName.equalsIgnoreCase("recordId")) {

            hasRecordId = true;

        } else if (qName.equalsIgnoreCase("ensemblId")) {

            hasEnsemblId = true;

        } else if (qName.equalsIgnoreCase("ncbiId")) {

            hasGeneNames = true;

        } else if (qName.equalsIgnoreCase("geneNames")) {

            hasGeneDescriptions = true;

        } else if (qName.equalsIgnoreCase("geneDescriptions")) {

            hasNcbiId = true;

        } else if (qName.equalsIgnoreCase("organs")) {

            hasOrgans = true;

        } else if (qName.equalsIgnoreCase("diseaseAssociations")) {

            hasDiseases = true;

        } else if (qName.equalsIgnoreCase("publicationMentions")) {

            hasPublications = true;

        } else if (qName.equalsIgnoreCase("patentMentions")) {

            hasPatents = true;

        }

    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {

        if (qName.equalsIgnoreCase("Gene")) {

            geneList.add(gene);

        }

    }

    @Override
    public void characters(char ch[], int start, int length) {

        if (hasRecordId) {

            String recordId = new String(ch, start, length);

            System.out.println("RecordId: " + recordId);

            gene.setRecordId(recordId);
            hasRecordId = false;

        } else if (hasGeneNames) {

            gene.setGeneNames(new String(ch, start, length));
            hasGeneNames = false;

        } else if (hasEnsemblId) {

            gene.setEnsemblId(new String(ch, start, length));
            hasEnsemblId = false;

        } else if (hasNcbiId) {

            gene.setNcbiId(new String(ch, start, length));
            hasNcbiId = false;

        } else if (hasGeneDescriptions) {

            gene.setGeneDescriptions(new String(ch, start, length));
            hasGeneDescriptions = false;

        } else if (hasOrgans) {

            String xmlUnprocessed = new String(ch, 0, ch.length);

            String pattern = "<organs />";

            if (!xmlUnprocessed.contains(pattern)) {

                String xmlSnippet = new String(ch, start, ch.length - start);
                int end = xmlSnippet.indexOf("</organs>");
                String xml = "<organs>" + xmlSnippet.substring(0, end) + "</organs>";
    
                List<Organ> organs = ReadOrganXML.getOrganList(xml);
    
                for (Organ organ : organs) {

                    System.out.println("Organ Name: " + organ.getOrganName());

                }
    
                gene.setOrgans(organs);
                
                hasOrgans = false;
                
            } else {

                List<Organ> organs = new ArrayList<Organ>();

                gene.setOrgans(organs);

                hasOrgans = false;

            }

        } else if (hasDiseases) {

            String xmlUnprocessed = new String(ch, 0, ch.length);

            String pattern = "<diseaseAssociations />";

            if (!xmlUnprocessed.contains(pattern)) {

                String xmlSnippet = new String(ch, start, ch.length - start);
                int end = xmlSnippet.indexOf("</diseaseAssociations>");
                String xml = "<diseaseAssociations>" + xmlSnippet.substring(0, end) + "</diseaseAssociations>";
    
                List<Disease> diseases = ReadDiseaseXML.getDiseaseList(xml);
    
                gene.setDiseases(diseases);
                
                hasDiseases = false;
                
            } else {

                List<Disease> diseases = new ArrayList<Disease>();

                gene.setDiseases(diseases);

                hasDiseases = false;

            }

        } else if (hasPublications) {

            String xmlUnprocessed = new String(ch, 0, ch.length);

            String pattern = "<publicationMentions />";

            if (!xmlUnprocessed.contains(pattern)) {

                String xmlSnippet = new String(ch, start, ch.length - start);
                int end = xmlSnippet.indexOf("</publicationMentions>");
                String xml = "<publicationMentions>" + xmlSnippet.substring(0, end) + "</publicationMentions>";
    
                List<Publication> publications = ReadPublicationXML.getPublicationList(xml);
    
                gene.setPublications(publications);
                
                hasPublications = false;
                
            } else {

                List<Publication> publications = new ArrayList<Publication>();

                gene.setPublications(publications);

                hasPublications = false;

            }

        } else if (hasPatents) {

            String xmlUnprocessed = new String(ch, 0, ch.length);

            String pattern = "<patentMentions />";

            if (!xmlUnprocessed.contains(pattern)) {

                String xmlSnippet = new String(ch, start, ch.length - start);
                int end = xmlSnippet.indexOf("</patentMentions>");
                String xml = "<patentMentions>" + xmlSnippet.substring(0, end) + "</patentMentions>";
    
                List<Patent> patents = ReadPatentXML.getPatentList(xml);
    
                gene.setPatents(patents);

                hasPatents = false;
                
            } else {

                List<Patent> patents = new ArrayList<Patent>();

                gene.setPatents(patents);

                hasPatents = false;

            }

        }

    }

}