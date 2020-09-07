using System;
using System.IO;

namespace UploadToAWS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string fileName in Directory.GetFiles("{0}/data/output", getProjectDirectory()))
            {
                string keyName = string.Format("data-fusion/output/{0}", fileName.Substring(fileName.LastIndexOf("/") + 1));
                string bucketName = "nahorgebre-ma-650-master-thesis";
                AWSupload.UploadFileAsync(bucketName, fileName, keyName).Wait();
            }        
        }

        public static string getProjectDirectory()
        {
            return Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("/") - 1);
        }
    }
}
