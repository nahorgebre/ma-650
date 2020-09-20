using System;
using System.IO;
using System.IO.Compression;

namespace PubMedDate
{
    class FileArchiver
    {
        public static string extractSingleFile(string sourceArchiveFileName)
        {
            string returnValue = string.Empty;
            string destinationDirectoryName = sourceArchiveFileName.Substring(0, sourceArchiveFileName.LastIndexOf("."));

            if (Directory.Exists(destinationDirectoryName))
            {
                Directory.Delete(destinationDirectoryName, true);
            }

            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
            
            foreach (string destinationFileName in Directory.GetFiles(destinationDirectoryName))
            {
                returnValue = destinationFileName;   
            }

            return returnValue;
        }

        public static void deleteExtractedFile(string fileName)
        {       
            string deleteFileName = fileName.Substring(0, fileName.LastIndexOf("/"));    
            Directory.Delete(deleteFileName, true);
            Console.WriteLine("Delete Directory: {0}", deleteFileName);
        }

    }
}