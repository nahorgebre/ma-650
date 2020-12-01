using System;
using Amazon.S3.Model;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace IR_ResultTables
{

    class Methods
    {

        public static void retriveInformation(Dictionary<string, List<string>> resultFileDictionary)
        {

            foreach (KeyValuePair<string, List<string>> resultFileDictionaryItem in resultFileDictionary)
            {
                
                                    //correspondencesResultTable.txt
                    //evaluationResultTable.txt

                    string evaluationResultTable;

                    string correspondencesResultTable;
            }

        }

        public static FileInfo downloadFile(string key)
        {

            string remoteUri = "https://nahorgebre-ma-650-master-thesis.s3.us-east-2.amazonaws.com/";

            string file = "ms-banner.gif", myStringWebResource = null;


            string[] keyArray = key.Split('/');
            
            string fileName = keyArray[5];

            string className = keyArray[4];

            string comparisonName = keyArray[3];

            string solution = keyArray[2];

            FileInfo outputFile = new FileInfo(Environment.CurrentDirectory + "/data/output/" + solution + "/" + comparisonName + "-" + className + "/" + fileName);

            outputFile.Directory.Create();


            using (WebClient myWebClient = new WebClient())
            {

                myStringWebResource = remoteUri + file;

                myWebClient.DownloadFile(myStringWebResource, outputFile.FullName);

            }

            return outputFile;

        }

    }

}