using System;
using Amazon.S3;
using System.IO;
using System.Text;
using Amazon.S3.Model;
using System.Collections.Generic;

namespace IR_ResultTables
{

    public class AWSlistingContents
    {

        public static Dictionary<string, List<string>> getS3ObjectList(string solution)
        {

            AmazonS3Client s3Client = new AmazonS3Client(AWScredentials.getAccessKey(), AWScredentials.getSecretKey(), AWScredentials.bucketRegion);

            List<S3Object> s3ObjectList = (s3Client.ListObjectsAsync("nahorgebre-ma-650-master-thesis", "identity-resolution/output/" + solution).Result).S3Objects;

            Dictionary<string, List<string>> resultFileDictionary = getResultFileDictionary(s3ObjectList);

            createShellScriptOutput(resultFileDictionary, solution);

            return resultFileDictionary;

        }

        public static void createShellScriptOutput(Dictionary<string, List<string>> resultFileDictionary, string solution)
        {

            FileInfo file = new FileInfo(Environment.CurrentDirectory + "/data/shScript/" + solution + "/Get-D-" + solution + ".sh");

            file.Directory.Create();

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                foreach (KeyValuePair<string, List<string>> resultFileItem in resultFileDictionary)
                {

                    sw.WriteLine(string.Empty);

                    string mkdir = "mkdir -p data/input/" + solution + "/" + resultFileItem.Key;

                    sw.WriteLine(mkdir);

                    foreach (string key in resultFileItem.Value)
                    {

                        string[] keyArray = key.Split('/');

                        string fileName = keyArray[5];

                        string className = keyArray[4];

                        string comparisonName = keyArray[3];

                        string wgetString = "wget https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/" + key
                            + " -O data/input/" + solution + "/" + comparisonName + "-" + className + "/" + fileName;

                        sw.WriteLine(wgetString);

                    }

                }

            }

        }

        public static Dictionary<string, List<string>> getResultFileDictionary(List<S3Object> s3ObjectList)
        {

            Dictionary<string, List<string>> resultFileDictionary = new Dictionary<string, List<string>>();

            foreach (S3Object s3ObjectItem in s3ObjectList)
            {

                string[] keyArray = s3ObjectItem.Key.Split('/');


                string className = keyArray[4];

                string comparisonName = keyArray[3];


                string dictionaryKey = comparisonName + "-" + className;

                if (resultFileDictionary.ContainsKey(dictionaryKey))
                {

                    List<string> resultFileList = resultFileDictionary[dictionaryKey];

                    if (!resultFileList.Contains(s3ObjectItem.Key))
                    {

                        resultFileList.Add(s3ObjectItem.Key);

                    }

                }
                else
                {

                    List<string> resultFileList = new List<string>() { s3ObjectItem.Key };

                    resultFileDictionary.Add(dictionaryKey, resultFileList);

                }

            }

            return resultFileDictionary;

        }

    }

}