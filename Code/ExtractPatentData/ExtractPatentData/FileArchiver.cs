using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ExtractPatentData
{
    class FileArchiver
    {
        public static HashSet<string> extractFiles(string year)
        {
            HashSet<string> fileNameList = new HashSet<string>();
            foreach (string sourceArchiveFileName in Directory.GetFiles(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year.ToString()))
            {
                string destinationDirectoryName = sourceArchiveFileName.Substring(0, sourceArchiveFileName.LastIndexOf("."));
                if (!Directory.Exists(destinationDirectoryName))
                {
                    ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
                }
                foreach (string destinationFileName in Directory.GetFiles(destinationDirectoryName))
                {
                    fileNameList.Add(destinationFileName);
                }
            }
            return fileNameList;
        }

        public static void deleteExtractedFiles(string year)
        {         
            foreach (string directory in Directory.GetDirectories(Environment.CurrentDirectory + @"\data\input\PatentGrantFullTextData\" + year.ToString()))
            {
                Directory.Delete(directory, true);
            }       
        }
    }
}