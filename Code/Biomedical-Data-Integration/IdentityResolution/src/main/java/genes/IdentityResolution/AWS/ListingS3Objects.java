package genes.IdentityResolution.AWS;

import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.ObjectListing;
import com.amazonaws.services.s3.model.S3ObjectSummary;

public class ListingS3Objects {
    
    public static void main( String[] args ) throws Exception
    {

        getDatasets("DI1", "Get-D-1.sh");
        getDatasets("DI2", "Get-D-2.sh");

        getGoldstandardDatasets("DI1", "Get-GD-1.sh");
        getGoldstandardDatasets("DI2", "Get-GD-2.sh");
        
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

    public static void getGoldstandardDatasets(String solution, String outputFileName) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter(outputFileName, "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/goldstandard/" + solution);
        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 5) {

                String comparison = parts[3];
                String fileName = parts[4];
    
                String mkdir = "mkdir -p data/goldstandard/" + solution + "/" + comparison;

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);
    
                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/goldstandard/" + solution + "/" + comparison + "/" + fileName;
                
                writer.println(wgetString);

            }

        }

        writer.close();

    }

}