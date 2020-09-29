using System;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Collections.Generic;

namespace ExtractPatentData
{
    class Parser
    {

        public static void DecompressAllXmlFiles(DirectoryInfo directorySelected) 
        {
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.zip"))
            {
                Console.WriteLine("Decompress: " + fileToDecompress.Name);
                
                bool exist = false;
                string xmlFileName1 = string.Format("{0}/{1}.xml", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf(".")));
                string xmlFileName2 = string.Format("{0}/{1}.XML", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf(".")));

                if (File.Exists(xmlFileName1))
                {
                    exist = true;
                }

                if (File.Exists(xmlFileName2))
                {
                    exist = true;
                }

                if (exist == false)
                {
                    List<string> sgmFileNameList = new List<string>();
                    sgmFileNameList.Add(string.Format("{0}/{1}.sgm", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf("."))));
                    sgmFileNameList.Add(string.Format("{0}/{1}.SGM", fileToDecompress.DirectoryName, fileToDecompress.Name.Substring(0, fileToDecompress.Name.LastIndexOf("."))));

                    foreach (var sgmFileName in sgmFileNameList)
                    {
                        if (File.Exists(sgmFileName))
                        {
                            File.Delete(sgmFileName);
                        }
                    }
 
                    ZipFile.ExtractToDirectory(fileToDecompress.FullName, directorySelected.FullName); 
                }

            }
        }

        public static string removeSpecialCharacters(string patentText)
        {
            HashSet<string> specialCharacterList = getInvalidSpecialCharInXml(patentText);

            foreach (string specialCharacter in specialCharacterList)
            {
                while (patentText.Contains(specialCharacter))
                {
                    int index = patentText.IndexOf(specialCharacter);
                    int length = specialCharacter.Length;
                    patentText = patentText.Remove(index, length);
                }
            }

            return patentText;
        }

        public static HashSet<string> getInvalidSpecialCharInXml(string text)
        {
            HashSet<string> specialCharacterList = new HashSet<string>();

            text = text.Replace(Environment.NewLine, " ");
            string[] tokens = text.Split(new[] { "&" }, StringSplitOptions.None);

            foreach (string token in tokens.Skip(1))
            {
                string firstWord = string.Empty;

                if (token.Contains(";"))
                {
                    int index = token.IndexOf(";");
                    firstWord = token.Substring(0, index + 1);
                }

                specialCharacterList.Add("&" + firstWord);
            }
            
            return specialCharacterList;
        }

        public static String getMergedDocumentTypeDeclaration(string[] tokens, int year)
        {
            HashSet<string> entityList = new HashSet<string>();
            foreach (var token in tokens)
            {
                string patternEnd = "]>";
                if (token.Contains(patternEnd))
                {
                    int patternEndIndex = token.IndexOf(patternEnd);
                    string header = token.Substring(patternEndIndex + 2);

                    foreach (var line in token.Split(
                        new[] { Environment.NewLine },
                        StringSplitOptions.None
                    ))
                    {
                        if (line.Contains("<!ENTITY"))
                        {
                            entityList.Add(line + Environment.NewLine);
                        }
                    }
                }
            }

            var docTypeDeclaration = new StringBuilder();

            string docTypeBegin = string.Empty;
            if (year >= 2002 & year <= 2004)
            {
                docTypeBegin = "<!DOCTYPE PATDOC SYSTEM \"ST32-US-Grant-025xml.dtd\" [" + Environment.NewLine;
            }

            if (year >= 2005 & year <= 2016)
            {
                docTypeBegin = "<!DOCTYPE us-patent-grant SYSTEM \"us-patent-grant-v41-2005-08-25.dtd\" [" + Environment.NewLine;
            }
            
            docTypeDeclaration.Append(docTypeBegin);

            foreach (var entity in entityList)
            {
                docTypeDeclaration.Append(entity);
            }

            string docTypeEnd = "]>";
            docTypeDeclaration.Append(docTypeEnd);

            return docTypeDeclaration.ToString();
        }

        public static string removeDocumentTypeDeclaration(string input)
        {
            string patternEnd = "]>";
            if (input.Contains(patternEnd))
            {
                int patternEndIndex = input.IndexOf(patternEnd);
                return input.Substring(patternEndIndex + 2);
            }
            else
            {
                return input;
            }
        }

    }
}