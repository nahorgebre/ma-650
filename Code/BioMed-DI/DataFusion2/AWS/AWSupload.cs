using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace DataFusion2
{

    public class AWSupload
    {

        private static IAmazonS3 s3Client;

        public static void run()
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/output/DI2/DI2-fused.xml", Environment.CurrentDirectory));

            string keyName = string.Format("data-fusion/output/{0}", file.Name);

            string bucketName = "nahorgebre-ma-650-master-thesis";

            UploadFileAsync(bucketName, file.FullName, keyName).Wait();

        }

        public static async Task UploadFileAsync(string bucketName, string filePath, string keyName)
        {

            if (!File.Exists(string.Format("{0}/credentials.config", Environment.CurrentDirectory)))
            {

                Console.WriteLine("{0} can not be uploaded since AWS credentials are missing!", keyName);

            }
            else
            {

                try
                {

                    s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);
                    var fileTransferUtility = new TransferUtility(s3Client);
                    await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);

                    Console.WriteLine("File Path: " + filePath);
                    Console.WriteLine("Key Name: " + keyName);
                    Console.WriteLine("Upload complited!");

                }
                catch (AmazonS3Exception e)
                {

                    Console.WriteLine("Error encountered on server, Message: '{0}' when writing an object", e.Message);

                }
                catch (Exception e)
                {

                    Console.WriteLine("Unknown encountered on server, Message: '{0}' when writing an object", e.Message);

                }

            }

        }

    }

}