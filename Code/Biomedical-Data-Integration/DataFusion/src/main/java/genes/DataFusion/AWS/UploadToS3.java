package genes.DataFusion.AWS;

import java.io.File;
import java.io.FilenameFilter;
import java.io.IOException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import com.amazonaws.auth.AWSCredentials;
import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.regions.Regions;
import com.amazonaws.services.s3.AmazonS3;
import com.amazonaws.services.s3.AmazonS3ClientBuilder;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.xml.sax.SAXException;

import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathExpression;
import javax.xml.xpath.XPathExpressionException;
import javax.xml.xpath.XPathFactory;

public class UploadToS3 {

    public static void main( String[] args ) throws Exception
    {

        String outputDirectory = System.getProperty("user.dir") + "/data/output";

        for (String solution : getSubDirectoryList(outputDirectory)) {
            
            String solutionDirectory = outputDirectory + "/" + solution;

            for (String comparisonDescription : getSubDirectoryList(solutionDirectory)) {

                String comparisonDescriptionDirectory = solutionDirectory + "/" + comparisonDescription;

                for (String className : getSubDirectoryList(comparisonDescriptionDirectory)) {

                    String classNameDirectory = comparisonDescriptionDirectory + "/" + className;

                    for (String file : getFiles(classNameDirectory)) {

                        String fileName = classNameDirectory + "/" + file;

                        if (file.contains("evaluation") | file.contains("correspondences")) {
                            
                            String keyName = "identity-resolution/output/" + solution + "/" + comparisonDescription + "/" + className + "/" + file;
                            uploadFile("nahorgebre-ma-650-master-thesis", keyName, fileName);

                        }

                    }
          
                }
                
            }

        }

    }

    public static String[] getSubDirectoryList(String directory) {
        File file = new File(directory);
        String[] subDirectoryList = file.list(new FilenameFilter() {
            @Override
            public boolean accept(File current, String name) {
                return new File(current, name).isDirectory();
            }
        });

        return subDirectoryList;
    }

    public static String[] getFiles(String directory) {
        File file = new File(directory);
        String[] fileList = file.list(new FilenameFilter() {
            @Override
            public boolean accept(File current, String name) {
                return new File(current, name).isFile();
            }
        });

        return fileList;
    }
    
    public static void uploadFile(String bucketName, String keyName, String filePath) throws ParserConfigurationException, SAXException, IOException, XPathExpressionException{

        AmazonS3 s3client = AmazonS3ClientBuilder.standard().withCredentials(new AWSStaticCredentialsProvider(getCredentials())).withRegion(Regions.US_EAST_2).build();

        try {
            s3client.putObject(
                bucketName, 
                keyName, 
                new File(filePath)
            );
        } catch (Exception e) {
            System.out.println("Upload failed!");
            System.out.println("Upload - Key Name: " + bucketName + "/" + keyName);
            System.out.println("Upload - File Name: " + filePath);
            System.out.println(e);

        }

    }

    public static AWSCredentials getCredentials() throws ParserConfigurationException, SAXException, IOException, XPathExpressionException {

        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();
        String xmlFileName = System.getProperty("user.dir") + "/credentials.config";
        Document doc = builder.parse(xmlFileName);

        XPathFactory xPathFactory = XPathFactory.newInstance();
        XPath xPath = xPathFactory.newXPath();

        XPathExpression exprAccessKey = xPath.compile("/credentials/accessKey");
        XPathExpression exprSecretKey = xPath.compile("/credentials/secretKey");

        Node nodeAccessKey = (Node) exprAccessKey.evaluate(doc, XPathConstants.NODE);
        Node nodeSecretKey = (Node) exprSecretKey.evaluate(doc, XPathConstants.NODE);

        String accesskey = nodeAccessKey.getTextContent();
        String secretkey = nodeSecretKey.getTextContent();
        
        AWSCredentials credentials = new BasicAWSCredentials(
            accesskey, 
            secretkey
        );

        return credentials;
    }

}