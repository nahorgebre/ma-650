using System;
using Amazon.S3;
using System.IO;
using System.Linq;
using Amazon.S3.Model;
using System.Collections.Generic;

namespace IR_GS_Creation
{

    public class AWSlistingContents
    {

        public static void getS3ObjectList(string solution)
        {

            AmazonS3Client s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);

            List<S3Object> s3ObjectList = (s3Client.ListObjectsAsync("nahorgebre-ma-650-master-thesis", "identity-resolution/input/" + solution).Result).S3Objects;

            FileInfo file = new FileInfo(Environment.CurrentDirectory + "/Get-" + solution + ".sh");

            file.Directory.Create();

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                sw.WriteLine(string.Empty);

                string mkdir = "mkdir -p data/input/" + solution;

                sw.WriteLine(mkdir);

                foreach (S3Object s3ObjectItem in s3ObjectList)
                {

                    if (s3ObjectItem.Key.Contains(".tsv"))
                    {

                        string[] keyArray = s3ObjectItem.Key.Split('/');

                        string fileName = keyArray.Last();

                        string wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + s3ObjectItem.Key
                            + " -O data/input/" + solution + "/" + fileName;

                        sw.WriteLine(wgetString);

                    }

                }

            }

        }

    }

}