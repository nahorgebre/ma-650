package genes.IdentityResolution.AWS;

import java.io.File;
import java.io.FilenameFilter;
import java.io.IOException;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import com.amazonaws.auth.AWSCredentials;
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.Bucket;
import com.amazonaws.services.s3.model.ObjectListing;
import com.amazonaws.services.s3.model.S3ObjectSummary;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.xml.sax.SAXException;

import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathExpression;
import javax.xml.xpath.XPathExpressionException;
import javax.xml.xpath.XPathFactory;

public class ListingS3Objects {
    
    public static void main( String[] args ) throws Exception
    {

        getCorrespondences();
        
    }

    public static void getCorrespondences() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution");
	    for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            if (key.contains("output") & key.contains("correspondences")) {

                String[] parts = key.split("/");
                System.out.println(parts[3] + "=https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key);     
                
            }
	        
        }

    }

    public static void getGoldstandardDatasets() throws Exception {

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(Credentials.getCredentials())).withRegion(Regions.US_EAST_2).build();
        
        ObjectListing objectListing = s3client.listObjects("nahorgebre-ma-650-master-thesis", "identity-resolution");
        for(S3ObjectSummary os : objectListing.getObjectSummaries()) {

            String key = os.getKey();

            if (key.contains("goldstandard")) {
                
            }
        }

    }

}
