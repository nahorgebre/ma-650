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
            string returnValue = string.Empty;
            string destinationDirectoryName = sourceArchiveFileName.Substring(0, sourceArchiveFileName.LastIndexOf("."));

            if (!Directory.Exists(destinationDirectoryName))
            {
                ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
                Console.WriteLine(Environment.NewLine + string.Format("Extract to directory: {0}", destinationDirectoryName));
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Archive File is already extracted.");
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
                        returnValue = destinationFileName;
                    }
                }         
            }

            Console.WriteLine(string.Format("File name: {0}", returnValue));
            return returnValue;
        }

        public static void deleteExtractedFile(string fileName)
        {     
            Directory.Delete(fileName.Substring(0, fileName.LastIndexOf(@"\")), true);
        }

    }
}