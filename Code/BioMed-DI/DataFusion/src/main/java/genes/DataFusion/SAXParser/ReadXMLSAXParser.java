package genes.DataFusion.SAXParser;

import java.io.File;
import java.io.IOException;
import java.util.List;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.xml.sax.SAXException;

import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;

import genes.DataFusion.SAXParser.Gene;

public class ReadXMLSAXParser {

    public static FusibleDataSet<Gene, Attribute> parse() {

        FusibleDataSet<Gene, Attribute> ds = new FusibleHashedDataSet<>();

        return ds;

    }

    public static void main(String[] args) {

        SAXParserFactory saxParserFactory = SAXParserFactory.newInstance();

        try {

            SAXParser saxParser = saxParserFactory.newSAXParser();

            GeneHandler handler = new GeneHandler();

            saxParser.parse(new File("C:\\Users\\nahor\\GitHub\\ma-650-master-thesis\\Code\\BioMed-DI\\DataFusion\\src\\main\\java\\genes\\DataFusion\\SAXParser\\Kaessmann2_dt.xml"), handler);
            
            List < Gene > geneList = handler.getEmpList();

        } catch (ParserConfigurationException | SAXException | IOException e) {

            e.printStackTrace();

        }

    }

}