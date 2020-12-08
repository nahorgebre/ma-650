package genes.IdentityResolution.AWS;

// java
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.List;

// javax
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.xpath.XPathExpressionException;

// aws
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.ObjectListing;
import com.amazonaws.services.s3.model.S3ObjectSummary;

// xml
import org.xml.sax.SAXException;

public class ListingS3Objects {

    public static void main(String[] args) throws Exception {

        getDatasets("DI1");

        getGoldstandardDatasets("DI1");


        getDatasets("DI2");

        getGoldstandardDatasets("DI2");


        getDatasets("DI3");

        getGoldstandardDatasets("DI3");

        /*
         * 
         * getDI1Datasets();
         * 
         * getDI1GoldstandardDatasets();
         * 
         * getDI2Datasets();
         * 
         * getDI2GoldstandardDatasets();
         * 
         * getDI3Datasets();
         * 
         * getDI3GoldstandardDatasets();
         * 
         */

        // getIdentityResolutionResults("DI2");

    }

    public static void getDatasets(String solution) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-D-" + solution + ".sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/input/" + solution);

        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            if (key.contains(".xml")) {

                String[] parts = key.split("/");

                if (parts.length == 4) {

                    String fileName = parts[3];

                    String mkdir = "mkdir -p data/input/" + solution;

                    if (!mkdirList.contains(mkdir)) {

                        mkdirList.add(mkdir);

                        writer.println("");

                        writer.println(mkdir);

                    }

                    String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                            + " -O data/input/" + solution + "/" + fileName;

                    writer.println(wgetString);

                }

            }

        }

        writer.close();

    }

    public static void getGoldstandardDatasets(String solution) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-GD-" + solution + ".sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/goldstandard/" + solution);

        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

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

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                        + " -O data/goldstandard/" + solution + "/" + comparison + "/" + fileName;

                writer.println(wgetString);

            }

        }

        writer.close();

    }

    public static void getDI1GoldstandardDatasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-GD-1.sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/goldstandard/DI1");
        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

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

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                        + " -O data/goldstandard/DI1/" + comparison + "/" + fileName;

                writer.println(wgetString);

            }

        }

        writer.close();

    }


    public static void getDI2GoldstandardDatasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-GD-2.sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/goldstandard/DI2");
        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 5) {

                String comparison = parts[3];
                String fileName = parts[4];

                String mkdir = "mkdir -p data/goldstandard/DI2/" + comparison;

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);

                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                        + " -O data/goldstandard/DI2/" + comparison + "/" + fileName;

                writer.println(wgetString);

            }

        }

        writer.close();

    }


    public static void getDI3GoldstandardDatasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        List<String> mkdirList = new ArrayList<String>();

        PrintWriter writer = new PrintWriter("Get-GD-3.sh", "UTF-8");

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/goldstandard/DI3");
        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            if (parts.length == 5) {

                String comparison = parts[3];
                String fileName = parts[4];

                String mkdir = "mkdir -p data/goldstandard/DI3/" + comparison;

                if (!mkdirList.contains(mkdir)) {

                    mkdirList.add(mkdir);

                    writer.println("");
                    writer.println(mkdir);

                }

                String wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                        + " -O data/goldstandard/DI3/" + comparison + "/" + fileName;

                writer.println(wgetString);

            }

        }

        writer.close();

    }

    public static void getIdentityResolutionResults(String solution) throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard()
                .withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials()))
                .withRegion(Regions.US_EAST_2).build();

        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis",
                "identity-resolution/output/" + solution);
        for (S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            String[] parts = key.split("/");

            System.out.println(key);

            System.out.println(parts[3]);

            System.out.println(parts[4]);

            System.out.println(parts[5]);

        }

    }

}