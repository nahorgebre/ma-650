using System;
using System.Collections.Generic;
using System.IO;

namespace GoldstandardCreation
{
    
    class Organs
    {

        public static void run()
        {

            //Heart_2_Brain();
            Heart_2_Brain_4();
            //Heart_2_Cerebellum();
            Heart_2_Cerebellum_4();
            //Heart_2_Kidney();
            Heart_2_Kidney_4();
            //Heart_2_Liver();
            Heart_2_Liver_4();
            //Heart_2_Testis();
            Heart_2_Testis_4();

            
            //Cerebellum_2_Brain();
            Cerebellum_2_Brain_4();
            //Cerebellum_2_Kidney();
            Cerebellum_2_Kidney_4();
            //Cerebellum_2_Liver();
            Cerebellum_2_Liver_4();
            //Cerebellum_2_Testis();
            Cerebellum_2_Testis_4();
            

            //Brain_2_Kidney();
            Brain_2_Kidney_4();
            //Brain_2_Liver();
            Brain_2_Liver_4();
            //Brain_2_Testis();
            Brain_2_Testis_4();


            //Kidney_2_Liver();
            Kidney_2_Liver_4();
            //Kidney_2_Testis();
            Kidney_2_Testis_4();


            //Testis_2_Liver();
            Testis_2_Liver_4();

        }


        // Heart
        public static void Heart_2_Brain_4() {

            // ensembl Id
            string comparison = "Heart_2_Brain";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Heart_path, Datasets.Brain_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Heart_2_Brain()
        {
            // ensembl id
            string comparison = "Heart_2_Brain";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Brain_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }
        
        public static void Heart_2_Cerebellum_4() {

            // ensembl Id
            string comparison = "Heart_2_Cerebellum";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Heart_path, Datasets.Cerebellum_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Heart_2_Cerebellum()
        {

            // ensembl id
            string comparison = "Heart_2_Cerebellum";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Cerebellum_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Heart_2_Kidney_4() {

            // ensembl Id
            string comparison = "Heart_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Heart_path, Datasets.Kidney_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Heart_2_Kidney()
        {

            // ensembl id
            string comparison = "Heart_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Kidney_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Heart_2_Liver_4() {

            // ensembl Id
            string comparison = "Heart_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Heart_path, Datasets.Liver_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Heart_2_Liver()
        {

            // ensembl id
            string comparison = "Heart_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Liver_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }
        }

        public static void Heart_2_Testis_4() {

            // ensembl Id
            string comparison = "Heart_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Heart_path, Datasets.Testis_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Heart_2_Testis()
        {

            // ensembl id
            string comparison = "Heart_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Testis_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }


        // Cerebellum
        public static void Cerebellum_2_Brain_4() {

            // ensembl Id
            string comparison = "Cerebellum_2_Brain";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Cerebellum_path, Datasets.Brain_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Cerebellum_2_Brain()
        {
            // ensembl id
            string comparison = "Cerebellum_2_Brain";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Cerebellum_path, Datasets.Brain_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Cerebellum_2_Kidney_4() {

            // ensembl Id
            string comparison = "Cerebellum_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Cerebellum_path, Datasets.Kidney_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Cerebellum_2_Kidney()
        {

            // ensembl id
            string comparison = "Cerebellum_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Cerebellum_path, Datasets.Kidney_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Cerebellum_2_Liver_4() {

            // ensembl Id
            string comparison = "Cerebellum_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Cerebellum_path, Datasets.Liver_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Cerebellum_2_Liver()
        {

            // ensembl id
            string comparison = "Cerebellum_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Cerebellum_path, Datasets.Liver_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Cerebellum_2_Testis_4() {

            // ensembl Id
            string comparison = "Cerebellum_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Cerebellum_path, Datasets.Testis_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Cerebellum_2_Testis()
        {

            // ensembl id
            string comparison = "Cerebellum_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Cerebellum_path, Datasets.Testis_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }


        // Brain
        public static void Brain_2_Kidney_4() {

            // ensembl Id
            string comparison = "Brain_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Brain_path, Datasets.Kidney_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Brain_2_Kidney()
        {

            // ensembl id
            string comparison = "Brain_2_Kidney";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.Kidney_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Brain_2_Liver_4() {

            // ensembl Id
            string comparison = "Brain_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Brain_path, Datasets.Liver_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Brain_2_Liver()
        {

            // ensembl id
            string comparison = "Brain_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);
              
            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.Liver_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Brain_2_Testis_4() {

            // ensembl Id
            string comparison = "Brain_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Brain_path, Datasets.Testis_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Brain_2_Testis()
        {

            // ensembl id
            string comparison = "Brain_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Brain_path, Datasets.Testis_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }


        // Kidney
        public static void Kidney_2_Liver_4() {

            // ensembl Id
            string comparison = "Kidney_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Kidney_path, Datasets.Liver_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Kidney_2_Liver()
        {

            // ensembl id
            string comparison = "Kidney_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Kidney_path, Datasets.Liver_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Kidney_2_Testis_4() {

            // ensembl Id
            string comparison = "Kidney_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Kidney_path, Datasets.Testis_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Kidney_2_Testis()
        {

            // ensembl id
            string comparison = "Kidney_2_Testis";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);
                
                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Kidney_path, Datasets.Testis_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

        public static void Testis_2_Liver_4() {

            // ensembl Id
            string comparison = "Testis_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);

            string trueCloseFile = string.Format("{0}/trueClose.csv", directoryName);
            string trueFarFile = string.Format("{0}/trueFar.csv", directoryName);
            string falseCloseFile = string.Format("{0}/falseClose.csv", directoryName);
            string falseFarFile = string.Format("{0}/falseFar.csv", directoryName);

            Directory.CreateDirectory(directoryName);

            if (!File.Exists(trueCloseFile) | 
                !File.Exists(trueFarFile) |
                !File.Exists(falseCloseFile) |
                !File.Exists(falseFarFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                (List<Goldstandard> trueCloseList, List<Goldstandard> trueFarList, List<Goldstandard> falseCloseList, List<Goldstandard> falseFarList) = Methods.compareFilesEnsemblIdBlockingComparator(Datasets.Testis_path, Datasets.Liver_path);
                
                Methods.createOuput(trueCloseFile, trueCloseList);
                Methods.createOuput(trueFarFile, trueFarList);

                Methods.createOuput(falseCloseFile, falseCloseList);
                Methods.createOuput(falseFarFile, falseFarList);

            }

        }
        public static void Testis_2_Liver()
        {

            // ensembl id
            string comparison = "Testis_2_Liver";
            string directoryName = string.Format("{0}/data/output/DI1/{1}", Environment.CurrentDirectory, comparison);
            string trueFile = string.Format("{0}/true.csv", directoryName);
            string falseFile = string.Format("{0}/false.csv", directoryName);

            if (!File.Exists(trueFile) | !File.Exists(falseFile))
            {

                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

                Directory.CreateDirectory(directoryName);

                (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Testis_path, Datasets.Liver_path, 1, Methods.EnsemblId);
                
                Methods.createOuput(trueFile, trueList);
                Methods.createOuput(falseFile, falseList);

            }

        }

    }
    
}