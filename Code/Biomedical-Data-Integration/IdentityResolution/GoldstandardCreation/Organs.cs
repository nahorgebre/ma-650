using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Organs
    {

        public static void run() {
            Heart_2_Brain();
            Heart_2_Cerebellum();
            Heart_2_Kidney();
            Heart_2_Liver();
            Heart_2_Testis();
        }

        public static void Heart_2_Brain() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Brain_path, 1);
            Methods.createOuput("Heart_2_Brain", "true.csv", trueList);
            Methods.createOuput("Heart_2_Brain", "false.csv", falseList);
        }

        public static void Heart_2_Cerebellum() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Cerebellum_path, 1);
            Methods.createOuput("Heart_2_Cerebellum", "true.csv", trueList);
            Methods.createOuput("Heart_2_Cerebellum", "false.csv", falseList);
        }

        public static void Heart_2_Kidney() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Kidney_path, 1);
            Methods.createOuput("Heart_2_Kidney", "true.csv", trueList);
            Methods.createOuput("Heart_2_Kidney", "false.csv", falseList);
        }
    
        public static void Heart_2_Liver() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Liver_path, 1);
            Methods.createOuput("Heart_2_Liver", "true.csv", trueList);
            Methods.createOuput("Heart_2_Liver", "false.csv", falseList);
        }

        public static void Heart_2_Testis() {
            // ensembl id
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.compareFiles(Datasets.Heart_path, Datasets.Testis_path, 1);
            Methods.createOuput("Heart_2_Testis", "true.csv", trueList);
            Methods.createOuput("Heart_2_Testis", "false.csv", falseList);
        }

    }
}