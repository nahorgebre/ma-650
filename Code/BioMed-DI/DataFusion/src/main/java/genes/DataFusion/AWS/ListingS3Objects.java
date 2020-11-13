package genes.DataFusion.AWS;

// Java
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.List;

// AWS
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.ObjectListing;
import com.amazonaws.services.s3.model.S3ObjectSummary;

public class ListingS3Objects {
    
    public static void main( String[] args ) throws Exception
    {

        getCorrespondences("DI1", "Get-C-1.sh");

        getDatasets("DI1", "Get-D-1.sh");
        
    }

    public static void getCorrespondences(String solution, String outputFileName) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter(outputFileName, "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/output/" + solution);

        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            String comparison = parts[3];

            String matchingEngine = parts[4];

            String fileName = parts[5];

            String mkdir = "mkdir -p data/correspondences/DI1/" + comparison;

            if (!mkdirList.contains(mkdir)) {

                mkdirList.add(mkdir);

                writer.println("");

                writer.println(mkdir);

            }

            if (solution.equals("DI1")) {

                if(DI1Comparisons.checkMatchingEngine(comparison, matchingEngine)) {

                    String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/correspondences/DI1/" + comparison + "/" + fileName;
                
                    writer.println(wgetString);

                }
                
            }

        }

        writer.close();

        /*

        Path source = Paths.get(System.getProperty("user.dir") + "/" + outputFileName);

        Path dest = Paths.get(System.getProperty("user.dir") + "/DataPreparation/" + outputFileName);

        Files.copy(source, dest, StandardCopyOption.REPLACE_EXISTING);

        */

    }


    public static void getDatasets(String solution, String outputFileName) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter(outputFileName, "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/input/" + solution);
        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 4) {

                String fileName = parts[3];
    
                String mkdir = "mkdir -p data/input/" + solution;

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);
    
                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/input/" + solution + "/" + fileName;
                
                writer.println(wgetString);

            }

        }

        writer.close();

    }


}