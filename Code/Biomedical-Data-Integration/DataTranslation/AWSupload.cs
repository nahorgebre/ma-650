using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace DataTranslation
{
    public class AWSupload
    {
        private static IAmazonS3 s3Client;

        public static void run()
        {
            foreach (string directory in Directory.GetDirectories(string.Format("{0}/{1}", Environment.CurrentDirectory, "data/output")))
            {
                foreach (string fileName in Directory.GetFiles(directory))
                {
                    string keyName = string.Format("input/{0}", fileName.Substring(fileName.LastIndexOf("/") + 1));
                    string bucketName = "identity-resolution";
                    UploadFileAsync(bucketName, fileName, keyName).Wait();
                }
            }
        }

        public static async Task UploadFileAsync(string bucketName, string filePath, string keyName)
        {
            try
            {
                s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);

                await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
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