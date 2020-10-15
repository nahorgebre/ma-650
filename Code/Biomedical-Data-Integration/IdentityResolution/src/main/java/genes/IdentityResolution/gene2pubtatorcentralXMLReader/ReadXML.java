package genes.IdentityResolution.gene2pubtatorcentralXMLReader;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.xml.sax.SAXException;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneName;
import genes.IdentityResolution.model.Publication;

public class ReadXML {

    public static HashedDataSet<Gene, Attribute> getGene2pubtatorcentralHashDataSet() {

        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = new HashedDataSet<>();

        SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();

        try {

            SAXParser saxParser = saxParserFactory.newSAXParser();
            gene2pubtatorcentralHandler gene2pubtatorcentralHandler = new gene2pubtatorcentralHandler();
            saxParser.parse(new File("data/input/gene2pubtatorcentral_dt.xml"), gene2pubtatorcentralHandler);

            List <gene2pubtatorcentral> gene2pubtatorcentralsList = gene2pubtatorcentralHandler.getGene2pubtatorcentralsList();

            for (gene2pubtatorcentral gene2pubtatorcentralItem : gene2pubtatorcentralsList) {

                String recordId = gene2pubtatorcentralItem.recordId.toString();
                String ncbiId = gene2pubtatorcentralItem.ncbiId.toString();
                String name = gene2pubtatorcentralItem.name.toString();

                String pmid = gene2pubtatorcentralItem.pmid.toString();
                String ressource = gene2pubtatorcentralItem.ressource.toString();

                Gene gene = new Gene(recordId, "gene2pubtatorcentral_dt.xml");
                gene.setNcbiId(ncbiId);

                // GeneName
                GeneName geneName = new GeneName(recordId, "gene2pubtatorcentral_dt.xml");
                geneName.setName(name);

                List<GeneName> geneNameList = new ArrayList<GeneName>();
                geneNameList.add(geneName);
                gene.setGeneNames(geneNameList);

                // Publication
                Publication publication = new Publication(recordId, "gene2pubtatorcentral_dt.xml");
                publication.setPmId(pmid);
                publication.setRessource(ressource);

                List<Publication> publicationList = new ArrayList<Publication>();
                publicationList.add(publication);
                gene.setPublications(publicationList);

                gene2pubtatorcentral.add(gene);
            }
                     
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
        }
        
        return gene2pubtatorcentral;
    }

    public static void main(String[] args) {

        SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();

        try {

            SAXParser saxParser = saxParserFactory.newSAXParser();
            gene2pubtatorcentralHandler gene2pubtatorcentralHandler = new gene2pubtatorcentralHandler();
            saxParser.parse(new File("data/input/TargetSchema.xml"), gene2pubtatorcentralHandler);

            List <gene2pubtatorcentral> gene2pubtatorcentralsList = gene2pubtatorcentralHandler.getGene2pubtatorcentralsList();

            for (gene2pubtatorcentral gene2pubtatorcentral : gene2pubtatorcentralsList) {
                System.out.println(gene2pubtatorcentral);
            }
                     
        } catch (ParserConfigurationException | SAXException | IOException e) {
            e.printStackTrace();
        }

    }
    
}
