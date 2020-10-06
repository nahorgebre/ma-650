using System.Collections.Generic;

namespace GoldstandardCreation
{
    class Publication
    {
        public static void run() {
            gene2pubtatorcentral_2_PubMedDate();
        }
        
        public static void gene2pubtatorcentral_2_PubMedDate() {
            (List<Goldstandard> trueList, List<Goldstandard> falseList) = Methods.comparePmId(Datasets.gene2pubtatorcentral_path, Datasets.PubMedDate_path);
            Methods.createOuput("gene2pubtatorcentral_2_PubMedDate", "true.csv", trueList);
            Methods.createOuput("gene2pubtatorcentral_2_PubMedDate", "false.csv", falseList);
        }
    }
}