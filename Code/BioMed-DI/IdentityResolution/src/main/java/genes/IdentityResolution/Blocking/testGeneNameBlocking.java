package genes.IdentityResolution.Blocking;

import java.util.ArrayList;
import java.util.List;

public class testGeneNameBlocking {

    
    public static void main( String[] args ) throws Exception
    {

        System.out.println("Test");

        List<String> testList = new ArrayList<>();
        testList.add("A1BG|A2M");
        testList.add("NAT2|SERPINA3");
        testList.add("AARS|AAVS1|ABAT");

        for (String testItem : testList) {

            System.out.println("Gene Names: " + testItem);

            String[] geneNameArray = testItem.split("\\|");

            String geneName = geneNameArray[0].toLowerCase();
    
            for (String geneNameItem : geneNameArray) {

                System.out.println("Single Gene Name: " + geneNameItem);
                
                if (geneNameItem.length() > geneName.length()) {
                    
                    geneName = geneNameItem.toLowerCase();

                    System.out.println(geneName);
    
                }
    
            }
            
        }


    }
    
}
