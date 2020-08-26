using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace ExtractPatentData
{
    public class AWSupload
    {
        private static IAmazonS3 s3Client;

        public static void run()
        {
            foreach (string fileName in Directory.GetFiles("./data/output"))
            {
                string keyName = string.Format("output/{0}", fileName.Substring(fileName.LastIndexOf("/") + 1));
                string bucketName = "extract-patent-data";
                UploadFileAsync(bucketName, fileName, keyName).Wait();
            }

            UploadFileAsync(
                bucketName: "extract-patent-data", 
                fileName: "./data/logs/ExtractPatentData.log", 
                keyName: "logs/ExtractPatentData.log"
                ).Wait();
        }

        public static async Task UploadFileAsync(string bucketName, string fileName, string keyName)
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
                    await fileTransferUtility.UploadAsync(fileName, bucketName, keyName);
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