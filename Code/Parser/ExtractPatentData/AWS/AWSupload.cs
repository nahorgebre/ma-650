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

            DirectoryInfo directory = new DirectoryInfo(string.Format("{0}/data/output", Environment.CurrentDirectory));

            foreach (FileInfo file in directory.GetFiles())
            {
                
                string keyName = string.Format("parser/output/{0}", file.Name);
                string bucketName = "nahorgebre-ma-650-master-thesis";
                UploadFileAsync(bucketName, file.FullName, keyName).Wait();        
            }
        }

        public static async Task UploadFileAsync(string bucketName, string fileName, string keyName)
        {
            if (!File.Exists("./credentials.config"))
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