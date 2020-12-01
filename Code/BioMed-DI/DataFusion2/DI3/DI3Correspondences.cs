using System;
using System.IO;
using System.Collections.Generic;

namespace DataFusion2
{
    class DI3Correspondences
    {


        public static List<FileInfo> di3correspondences = new List<FileInfo> {

            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_1/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_2/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_3/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_4/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_5/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_6/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_7/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_8/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_9/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_10/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_11/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_12/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_13/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_14/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_15/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_16/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_17/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_18/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_19/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_20/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_21/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_22/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_23/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_24/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_25/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_26/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_27/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_28/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_29/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_30/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_31/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_32/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_33/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_34/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_35/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_36/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_37/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_38/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_39/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_40/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_41/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_42/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_43/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_44/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_45/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_46/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_47/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_48/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_49/correspondences.csv"),
            new FileInfo(Environment.CurrentDirectory + "/data/correspondences/DI3/kaessmannDiseaseAssociations_2_gene2pubtatorcentral_50/correspondences.csv")

        };


    }

}