using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace GoldstandardCreation
{

    public class AWSupload
    {

        private static IAmazonS3 s3Client;

        public static void run(DirectoryInfo outputDirectory)
        {

            foreach (DirectoryInfo subDirectory in outputDirectory.GetDirectories())
            {

                string comparison = subDirectory.Name;

                foreach (FileInfo file in subDirectory.GetFiles())
                {

                    if (file.Name.Contains("train") | file.Name.Contains("test"))
                    {

                        string keyName = string.Format("identity-resolution/goldstandard/DI1/{0}/{1}", comparison, file.Name);

                        string bucketName = "nahorgebre-ma-650-master-thesis";

                        UploadFileAsync(bucketName, file.FullName, keyName).Wait();

                    }

                }

            }

        }

        // delete if not needed
        public static void runX(DirectoryInfo outputDirectory, String parameter = null)
        {

            Console.WriteLine("Start uploading files!");

            string solution = outputDirectory.Name;

            foreach (DirectoryInfo subDirectory in outputDirectory.GetDirectories())
            {

                string comparison = subDirectory.Name;

                foreach (FileInfo file in subDirectory.GetFiles())
                {

                    if (file.Name.Contains("train") | file.Name.Contains("test"))
                    {

                        string keyName = string.Empty;

                        if (parameter != null)
                        {

                            keyName = string.Format("identity-resolution/goldstandard/{0}/{1}/{2}/{3}", parameter, Variables.pubTatorPartitionSize, comparison, file.Name);
                        
                        }
                        else
                        {

                            keyName = string.Format("identity-resolution/goldstandard/{0}/{1}/{2}/", parameter, comparison, file.Name);

                        }
                        
                        string bucketName = "nahorgebre-ma-650-master-thesis";

                        UploadFileAsync(bucketName, file.FullName, keyName).Wait();

                    }

                }
                
            }

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