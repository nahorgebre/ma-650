using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace GoldStandardGER
{
    class Program
    {
        //public static string developmentGoldStandard = Environment.CurrentDirectory + @"\data\input\chemdner_gpro_gold_standard_development.tsv";
        //public static string trainGoldStandard = Environment.CurrentDirectory + @"\data\input\chemdner_gpro_gold_standard_train_v02.tsv";
        //public static string patents = Environment.CurrentDirectory + @"\data\input\US_Patents_1985_2016_313392.csv";

        public static string developmentGoldStandard = getProjectDirectory() + @"\data\input\chemdner_gpro_gold_standard_development.tsv";
        public static string trainGoldStandard = getProjectDirectory() + @"\data\input\chemdner_gpro_gold_standard_train_v02.tsv";
        public static string patents = getProjectDirectory() + @"\data\input\US_Patents_1985_2016_313392.csv";

        public static string getProjectDirectory()
        {
            string path = Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }

        static void Main(string[] args)
        {
            //patentPrefix();
            commonPatents();
        }

        static void patentPrefix()
        {
            //HashSet<string> patentPrefixDGS = PatentPrefixMethods.getPatentPrefix(developmentGoldStandard);
            //HashSet<string> patentPrefixTGS = PatentPrefixMethods.getPatentPrefix(trainGoldStandard);
       
            //PatentPrefixMethods.printPatentPrefix("chemdner_gpro_gold_standard_development.tsv", patentPrefixDGS);
            //PatentPrefixMethods.printPatentPrefix("chemdner_gpro_gold_standard_train_v02.tsv", patentPrefixTGS);
     
            //Console.WriteLine("Number of patents in chemdner_gpro_gold_standard_development.tsv: " + CommonPatents.getNumberOfPatents(developmentGoldStandard));
            PatentPrefixMethods.getPatentPrefixFrequency(developmentGoldStandard);

            //Console.WriteLine("Number of patents in chemdner_gpro_gold_standard_train_v02.tsv: " + CommonPatents.getNumberOfPatents(trainGoldStandard));
            PatentPrefixMethods.getPatentPrefixFrequency(trainGoldStandard);
        }
        
        static void commonPatents()
        {
            HashSet<String> patents = CommonPatents.getPatents();

            HashSet<String> usaDevelopmentGoldStandard = CommonPatents.getUsDevelopmentGoldStandard();
            int dgsCount = 0;

            HashSet<String> usaTrainGoldStandard = CommonPatents.getUsTrainGoldStandard();
            int tgsCount = 0;

            foreach (var patent in patents)
            {
                foreach (var dgs in usaDevelopmentGoldStandard)
                {
                    if (patent.Equals(dgs))
                    {
                        dgsCount ++;
                    }
                }

                foreach (var tgs in usaTrainGoldStandard)
                {
                    if (patent.Equals(tgs))
                    {
                        tgsCount ++;
                    }
                }
            }

            Console.WriteLine("Number of US-Patens in usaDevelopmentGoldStandard: " + usaDevelopmentGoldStandard.Count);
            Console.WriteLine("Number of US-Patens in usaTrainGoldStandard: " + usaTrainGoldStandard.Count);
            Console.WriteLine("Common records: patents <-> usaDevelopmentGoldStandard: " + dgsCount);
            Console.WriteLine("Common records: patents <-> usaTrainGoldStandard: " + tgsCount);
        }
    }

    class PatentPrefixMethods
    {
        public static HashSet<string> getPatentPrefix(string filePath)
        {
            HashSet<string> prefix = new HashSet<string>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');

                    prefix.Add(values[0].Substring(0, 2));
                }
            }
            return prefix;
        }

        public static void printPatentPrefix(string fileName, HashSet<string> patentPrefix)
        {
            Console.WriteLine(Environment.NewLine + "Patent Prefix in " + fileName + " :");
            foreach (var item in patentPrefix)
            {
                Console.Write(item + ", ");
            }
        }

        public static void getPatentPrefixFrequency(string filePath)
        {
            HashSet<string> CA = new HashSet<string>();
            HashSet<string> CN = new HashSet<string>();
            HashSet<string> DE = new HashSet<string>();
            HashSet<string> EP = new HashSet<string>();
            HashSet<string> US = new HashSet<string>();
            HashSet<string> WO = new HashSet<string>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');

                    string prefix = values[0].Substring(0, 2);
                    if (prefix.Equals("CA"))
                    {
                        CA.Add(values[0].ToString());
                    } 
                    else if (prefix.Equals("CN")) 
                    {
                        CN.Add(values[0].ToString());
                    }
                    else if (prefix.Equals("DE"))
                    {
                        DE.Add(values[0].ToString());
                    }
                    else if (prefix.Equals("EP"))
                    {
                        EP.Add(values[0].ToString());
                    }
                    else if (prefix.Equals("US"))
                    {
                        US.Add(values[0].ToString());
                    }
                    else if (prefix.Equals("WO"))
                    {
                        WO.Add(values[0].ToString());
                    }
                }
            }
            Console.WriteLine("CA: " + CA.Count + ",CN: " + CN.Count + ",DE: " 
            + DE.Count + ",EP: " + EP.Count + ",US: " + US.Count 
            + ",WO: " + WO.Count);
        }
    }

    class CommonPatents
    {
        public static HashSet<String> getPatents()
        {
            HashSet<String> patents = new HashSet<String>();
            using (var reader = new StreamReader(Program.patents))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');
                    
                    patents.Add(values[0].Replace("\"", ""));
                }
            }
            return patents;
        }

        public static HashSet<String> getUsDevelopmentGoldStandard()
        {
            HashSet<String> patents = new HashSet<String>();
            using (var reader = new StreamReader(Program.developmentGoldStandard))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');
                    
                    if (values[0].Contains("US"))
                    {
                        patents.Add(values[0].Replace("US", ""));
                    }                   
                }
            }
            return patents;
        }

        public static HashSet<String> getUsTrainGoldStandard()
        {
            HashSet<String> patents = new HashSet<String>();
            using (var reader = new StreamReader(Program.trainGoldStandard))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');
                    
                    if (values[0].Contains("US"))
                    {
                        patents.Add(values[0].Replace("US", ""));
                    }                   
                }
            }
            return patents;
        }
    }
}