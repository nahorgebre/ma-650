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
            Console.WriteLine(string.Format("Archive File Name: {0}", sourceArchiveFileName));
            Console.WriteLine(string.Format("Destination Directory for File Extraction: {0}", destinationDirectoryName));

            if (Directory.Exists(destinationDirectoryName))
            {
                Directory.Delete(destinationDirectoryName, true);
                Console.WriteLine(string.Format("Delete Directory: {0}", destinationDirectoryName));
            }

            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
            
            foreach (string destinationFileName in Directory.GetFiles(destinationDirectoryName))
            {
                List<string> fileTypes = new List<string>
                {
                    ".txt", ".TXT", ".xml", ".XML"
                };

                foreach (var fileType in fileTypes)
                {
                    if (destinationFileName.Contains(fileType))
                    {
                        returnValue = destinationFileName;
                        Console.WriteLine(string.Format("Destination File Name: {0}", returnValue));
                    }
                }         
            }

            return returnValue;
        }

        public static void deleteExtractedFile(string fileName)
        {
            string deleteFileName = fileName.Substring(0, fileName.LastIndexOf(@"\"));     
            Directory.Delete(deleteFileName, true);
            Console.WriteLine(string.Format("Delete Directory: {0}", deleteFileName));
        }

    }
}