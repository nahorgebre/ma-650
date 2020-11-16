package genes.IdentityResolution.AWS;

import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
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

        //getDI1Datasets();

        //getDI1GoldstandardDatasets();

        getDI2Datasets();
   
    }

    public static void getDI1Datasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-D-1.sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/input/DI1");
        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 4) {

                String fileName = parts[3];
    
                String mkdir = "mkdir -p data/input/DI1";

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);
    
                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/input/DI1/" + fileName;
                
                writer.println(wgetString);

            }

        }

        writer.close();

        Path source = Paths.get(System.getProperty("user.dir") + "/Get-D-1.sh");
        Path dest = Paths.get(System.getProperty("user.dir") + "/GoldstandardCreation/Get-D-1.sh");

        Files.copy(source, dest, StandardCopyOption.REPLACE_EXISTING);

    }

    public static void getDI1GoldstandardDatasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-GD-1.sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/goldstandard/DI1");
        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 5) {

                String comparison = parts[3];
                String fileName = parts[4];
    
                String mkdir = "mkdir -p data/goldstandard/DI1/" + comparison;

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);
    
                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/goldstandard/DI1/" + comparison + "/" + fileName;
                
                writer.println(wgetString);

            }

        }

        writer.close();

    }

    public static void getDI2Datasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        PrintWriter writer = new PrintWriter("Get-D-2.sh", "UTF-8");

        String mkdir = "mkdir -p data/input/DI2";

        writer.println(mkdir);

        writer.println("");

        ObjectListing objectListing1 = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution/input/DI2");
        for(S3ObjectSummary os : objectListing1.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 4) {

                String fileName = parts[3];

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key + " -O data/input/DI2/" + fileName;
                
                writer.println(wgetString);

            }

        }

        writer.close();

        Path source = Paths.get(System.getProperty("user.dir") + "/Get-D-2.sh");
        Path dest = Paths.get(System.getProperty("user.dir") + "/GoldstandardCreation/Get-D-2.sh");

        Files.copy(source, dest, StandardCopyOption.REPLACE_EXISTING);

    }

}