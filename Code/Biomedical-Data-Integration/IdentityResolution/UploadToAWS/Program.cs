using System;
using System.IO;

namespace UploadToAWS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string organ in Directory.GetDirectories("{0}/data/output", getProjectDirectory()))
            {
                foreach (string comparison in Directory.GetDirectories(organ))
                {
                    foreach (string fileName in Directory.GetFiles(comparison))
                    {                        
                        string keyName = string.Format("identity-resolution/output/{0}/{1}/{2}", organ, comparison, fileName.Substring(fileName.LastIndexOf("/") + 1));
                        string bucketName = "nahorgebre-ma-650-master-thesis";
                        AWSupload.UploadFileAsync(bucketName, fileName, keyName).Wait();
                    }
                }
            }        
        }

        public static string getProjectDirectory()
        {
            return Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("/") - 1);
        }
    }
}
