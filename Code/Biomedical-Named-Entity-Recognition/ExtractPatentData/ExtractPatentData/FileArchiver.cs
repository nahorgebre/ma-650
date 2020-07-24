using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class FileArchiver
    {
        public static string extractSingleFile(string sourceArchiveFileName)
        {
            string retrunValue = string.Empty;
            string destinationDirectoryName = sourceArchiveFileName.Substring(0, sourceArchiveFileName.LastIndexOf("."));

            if (!Directory.Exists(destinationDirectoryName))
            {
                ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
                Console.WriteLine(string.Format("Extract to directory: {0}", destinationDirectoryName));
            }
            else
            {
                Console.WriteLine("Archive File is already extracted.");
            }
            
            foreach (string destinationFileName in Directory.GetFiles(destinationDirectoryName))
            {
                List<string> fileTypes = new List<string>
                {
                    ".txt", ".xml"
                };

                foreach (var fileType in fileTypes)
                {
                    if (destinationFileName.Contains(fileType))
                    {
                        retrunValue = destinationFileName;
                    }
                }         
            }

            Console.WriteLine(string.Format("File name: {0}", retrunValue));
            return retrunValue;
        }

        public static void deleteExtractedFile(string fileName)
        {     
            Directory.Delete(fileName.Substring(0, fileName.LastIndexOf(@"\")), true);
        }

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
                    List<string> fileTypes = new List<string>
                    {
                        ".txt", ".xml"
                    };

                    foreach (var fileType in fileTypes)
                    {
                        if (destinationFileName.Contains(fileType))
                        {
                            fileNameList.Add(destinationFileName);
                        }
                    }         
                }
            }
            Console.WriteLine(string.Format("All zip files for the year {0} are extracted.", year));
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