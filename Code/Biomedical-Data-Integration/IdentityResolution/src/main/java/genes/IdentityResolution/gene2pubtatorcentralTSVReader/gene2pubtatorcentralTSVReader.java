package genes.IdentityResolution.gene2pubtatorcentralTSVReader;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import de.uni_mannheim.informatik.dws.winter.model.HashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import genes.IdentityResolution.model.Gene;
import genes.IdentityResolution.model.GeneName;
import genes.IdentityResolution.model.Publication;

public class gene2pubtatorcentralTSVReader {

    public static HashedDataSet<Gene, Attribute> getGene2pubtatorcentralHashedDataSet() {

        HashedDataSet<Gene, Attribute> gene2pubtatorcentral = new HashedDataSet<>();

        String sourceFileName = System.getProperty("user.dir") + "/data/input/gene2pubtatorcentral_dt.tsv";
        BufferedReader br = null;
        String line;
        String delimiter = "\t";

        try {

            br = new BufferedReader(new FileReader(sourceFileName));
            while ((line = br.readLine()) != null) {

                String[] lineItemList = line.split(delimiter);

                // 0 - recordId
                // 1 - ensemblId
                // 2 - ncbiId
                // 3 - geneName
                // 4 - pmId

                Gene gene = new Gene(lineItemList[0], "gene2pubtatorcentral_dt.xml");
                gene.setNcbiId(lineItemList[2]);

                // GeneName
                GeneName geneName = new GeneName(lineItemList[0], "gene2pubtatorcentral_dt.xml");
                geneName.setName(lineItemList[3]);

                List<GeneName> geneNameList = new ArrayList<GeneName>();
                geneNameList.add(geneName);
                gene.setGeneNames(geneNameList);

                // Publication
                Publication publication = new Publication(lineItemList[0], "gene2pubtatorcentral_dt.xml");
                publication.setPmId(lineItemList[4]);

                List<Publication> publicationList = new ArrayList<Publication>();
                publicationList.add(publication);
                gene.setPublications(publicationList);

                gene2pubtatorcentral.add(gene);

            }

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        return gene2pubtatorcentral;
        
    }
    
}
