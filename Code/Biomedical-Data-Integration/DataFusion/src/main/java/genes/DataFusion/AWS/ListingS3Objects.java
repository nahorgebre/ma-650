package genes.DataFusion.AWS;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;
import com.amazonaws.services.s3.model.ObjectListing;
import com.amazonaws.services.s3.model.S3ObjectSummary;

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

}
