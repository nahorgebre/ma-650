using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading.Tasks;

namespace IR_ResultTables
{
    
    public class AWSlistingContents
    {

        public static void test2()
        {

            AmazonS3Client s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);
            var lista = s3Client.ListObjectsAsync("nahorgebre-ma-650-master-thesis", $"identity-resolution/output/").Result;

            var files = lista.S3Objects.ToArray();

            foreach (var item in files)
            {
                Console.WriteLine(item.Key);
            }

        }

        /*

        public static void test()
        {

            string bucketName = "your bucket";

            AmazonS3Client client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);

            S3DirectoryInfo dir = new S3DirectoryInfo(client, bucketName, "your AmazonS3 folder name");
    foreach (IS3FileSystemInfo file in dir.GetFileSystemInfos())
    {
        Console.WriteLine(file.Name);
        Console.WriteLine(file.Extension);
        Console.WriteLine(file.LastWriteTime);
    }
        }

        public static async Task show()
        {

            AmazonS3Client client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);

            ListObjectsRequest request = new ListObjectsRequest();

            request.BucketName = "nahorgebre-ma-650-master-thesis";

            Task<ListObjectsResponse> response = client.ListObjectsAsync(request.BucketName);

            response.

            foreach (S3Object o in response.S3Objects)
            {

                Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);

            }

        }

        */

    }

}