using System;
using System.IO;
using System.Collections.Generic;

namespace PrepareGoldStandard
{

    class Datasets
    {

        public static FileInfo patNum = new FileInfo(Environment.CurrentDirectory + "/data/input/PatNum/US_Patents_1985_2016_313392.csv");


        public static FileInfo gs1_text = new FileInfo(Environment.CurrentDirectory + "/data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_patents_development_text.txt");

        public static FileInfo gs2_text = new FileInfo(Environment.CurrentDirectory + "/data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_patents_train_text.txt");

        public static List<FileInfo> gs_text = new List<FileInfo>() { gs1_text, gs2_text };

        
        public static FileInfo gs2_entity = new FileInfo(Environment.CurrentDirectory + "/data/input/CHEMDNERgoldstandard/gpro_training_set_v02/chemdner_gpro_gold_standard_train_v02.tsv");

        public static FileInfo gs1_entity = new FileInfo(Environment.CurrentDirectory + "/data/input/CHEMDNERgoldstandard/gpro_development_set/chemdner_gpro_gold_standard_development.tsv");

        public static List<FileInfo> gs_entity = new List<FileInfo>() { gs1_entity, gs2_entity };
        

    }

}