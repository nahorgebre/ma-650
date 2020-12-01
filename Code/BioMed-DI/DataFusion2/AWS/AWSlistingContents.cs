using System;
using Amazon.S3;
using System.IO;
using System.Text;
using Amazon.S3.Model;
using System.Collections.Generic;

namespace DataFusion2
{

    public class AWSlistingContents
    {

        public static void createCorrespondencesShellScriptOutput(string solution)
        {

            AmazonS3Client s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);

            List<S3Object> s3ObjectList = (s3Client.ListObjectsAsync("nahorgebre-ma-650-master-thesis", "identity-resolution/output/" + solution).Result).S3Objects;

            Dictionary<string, List<string>> correspondencesShellScript = new Dictionary<string, List<string>>();

            foreach (S3Object s3ObjectItem in s3ObjectList)
            {

                string[] keyArray = s3ObjectItem.Key.Split('/');


                string fileName = keyArray[5];

                string matchingEngine = keyArray[4];

                string comparisonName = keyArray[3];


                string mkdir = "mkdir -p data/correspondences/" + solution + "/" + comparisonName;

                string wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + s3ObjectItem.Key.ToString()
                    + " -O data/correspondences/" + solution + "/" + comparisonName + "/" + fileName;



                if (matchingEngine.Equals(DI3MatchingEngine.checkMatchingEngine(comparisonName)))
                {

                    if (correspondencesShellScript.ContainsKey(mkdir))
                    {

                        List<string> wgetStringList = correspondencesShellScript[mkdir];

                        wgetStringList.Add(wgetString);

                        correspondencesShellScript[mkdir] = wgetStringList;

                    }
                    else
                    {

                        List<string> wgetStringList = new List<string>();

                        wgetStringList.Add(wgetString);

                        correspondencesShellScript.Add(mkdir, wgetStringList);

                    }

                }

            }


            FileInfo file = new FileInfo(Environment.CurrentDirectory + "/Get-C-" + solution + ".sh");

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                foreach (KeyValuePair<string, List<string>> resultFileDictionaryItem in correspondencesShellScript)
                {
                    sw.WriteLine(string.Empty);
                    sw.WriteLine(resultFileDictionaryItem.Key);

                    foreach (string wgetString in resultFileDictionaryItem.Value)
                    {

                        if (wgetString.Contains("correspondences.csv"))
                        {

                            sw.WriteLine(wgetString);
                            
                        }
                                     
                    }
                    
                }

            }

        }

    }

}