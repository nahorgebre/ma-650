using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    public class DI1
    {

        public static string inputDirectory = Environment.CurrentDirectory + "/data/input/DI1";

        public static string outputDirectory = Environment.CurrentDirectory + "/data/output/DI1";

        public static void runDataTranslation()
        {

            List<Gene> gene_list = new List<Gene>();

            Dictionary<string, KaessmannContent> kaessmannDictionary = KaessmannInputDatasets.getKaessmannDictionary();

            int counter = 0;

            foreach (var kaessmannDictionaryItem in kaessmannDictionary)
            {

                Gene gene = new Gene();

                gene.recordId = string.Format("DI1_{0}_rid", counter);

                counter ++;

                gene.ensemblId = kaessmannDictionaryItem.Value.ensemblId;
                gene.geneNames = kaessmannDictionaryItem.Value.geneNames;
                gene.geneDescriptions = kaessmannDictionaryItem.Value.geneDescriptions;
                gene.ncbiId = kaessmannDictionaryItem.Value.ncbiId;

                List<Organ> organ_list = new List<Organ>();

                if (string.IsNullOrEmpty(kaessmannDictionaryItem.Value.brain_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.brain;

                    organ.call = kaessmannDictionaryItem.Value.brain_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.brain_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.brain_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                if (!string.IsNullOrEmpty(kaessmannDictionaryItem.Value.cerebellum_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.cerebellum;

                    organ.call = kaessmannDictionaryItem.Value.cerebellum_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.cerebellum_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.cerebellum_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                if (!string.IsNullOrEmpty(kaessmannDictionaryItem.Value.heart_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.heart;

                    organ.call = kaessmannDictionaryItem.Value.heart_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.heart_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.heart_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                if (!string.IsNullOrEmpty(kaessmannDictionaryItem.Value.kidney_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.kidney;

                    organ.call = kaessmannDictionaryItem.Value.kidney_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.kidney_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.kidney_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                if (!string.IsNullOrEmpty(kaessmannDictionaryItem.Value.liver_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.liver;

                    organ.call = kaessmannDictionaryItem.Value.liver_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.liver_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.liver_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                if (!string.IsNullOrEmpty(kaessmannDictionaryItem.Value.testis_call))
                {

                    Organ organ = new Organ();

                    organ.organName = OrganNames.testis;

                    organ.call = kaessmannDictionaryItem.Value.testis_call;
                    organ.disagreement = kaessmannDictionaryItem.Value.testis_disagreement;
                    organ.probEqualOrthoAdj = kaessmannDictionaryItem.Value.testis_probEqualOrthoAdj;

                    organ_list.Add(organ);

                }

                gene.organs = organ_list;

                gene_list.Add(gene);

            }

            Output.createXml(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/DI1_dt.xml"));

            Output.createTsv(gene_list: gene_list, file: new FileInfo(DI1.outputDirectory + "/DI1_dt.tsv"));

        }

    }

}