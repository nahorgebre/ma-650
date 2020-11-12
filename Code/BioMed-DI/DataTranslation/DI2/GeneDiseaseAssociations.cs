using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{
    public class GeneDiseaseAssociations
    {
        public static void runDataTranslation()
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, DI2.outputDirectory)); 
            GeneDiseaseAssociations.all_gene_disease_pmid_associations_dt();
        }

        public static void all_gene_disease_pmid_associations_dt()
        {
            List<Gene> gene_list = new List<Gene>();

            using (var reader = new StreamReader(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, DI2.inputDirectory, "all_gene_disease_pmid_associations.tsv")))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split('\t');

                    // 0 - geneId 
                    // 1 - geneSymbol  
                    // 2 - DSI 
                    // 3 - DPI 
                    // 4 - diseaseId 
                    // 5 - diseaseName
                    // 6 - diseaseType
                    // 7 - diseaseClass    
                    // 8 - diseaseSemanticType 
                    // 9 - score   
                    // 10 - EI 
                    // 11 - YearInitial 
                    // 12 - YearFinal
                    // 13 - pmid    
                    // 14 - source

                    Gene gene = new Gene();
                    gene.recordId = string.Format("gene_disease_pmid_associations_{0}_rid", counter);

                    string ncbiId = values[0].Trim();
                    if (!ncbiId.Equals(string.Empty))
                    {
                        gene.ncbiId = ncbiId;
                    }
                    string name = values[1].Trim();
                    if (!name.Equals(string.Empty))
                    {
                        List<GeneName> geneNameList = new List<GeneName>();
                        GeneName GeneName = new GeneName();
                        GeneName.name = name;
                        geneNameList.Add(GeneName);
                        //gene.geneNames = geneNameList;
                    }

                    List<DiseaseAssociation> diseases_list = new List<DiseaseAssociation>();
                    DiseaseAssociation disease = new DiseaseAssociation();

                    string diseaseIdUMLS = values[4].Trim();
                    if (!diseaseIdUMLS.Equals(string.Empty))
                    {
                        disease.diseaseIdUMLS = diseaseIdUMLS;
                    }
                    
                    string diseaseName = values[5].Trim();
                    if (!diseaseName.Equals(string.Empty));
                    {
                        disease.diseaseName = diseaseName;
                    }
                    
                    string diseaseSpecificityIndex = values[2].Trim();
                    if (!diseaseSpecificityIndex.Equals(string.Empty))
                    {
                        disease.diseaseSpecificityIndex = diseaseSpecificityIndex;
                    }
                    
                    string diseasePleiotropyIndex = values[3].Trim();
                    if (!diseasePleiotropyIndex.Equals(string.Empty))
                    {
                        disease.diseasePleiotropyIndex = diseasePleiotropyIndex;
                    }
                    
                    string diseaseTypeDisGeNET = values[6].Trim();
                    if (!diseaseTypeDisGeNET.Equals(string.Empty))
                    {
                        disease.diseaseTypeDisGeNET = diseaseTypeDisGeNET;
                    }

                    string diseaseClassMeSH = values[7].Trim();
                    if (!diseaseClassMeSH.Equals(string.Empty))
                    {
                        disease.diseaseClassMeSH = diseaseClassMeSH;
                    }
                    
                    string diseaseSemanticTypeUMLS = values[8].Trim();
                    if (!diseaseSemanticTypeUMLS.Equals(string.Empty))
                    {
                        disease.diseaseSemanticTypeUMLS = diseaseSemanticTypeUMLS;
                    }
                    
                    string associationScore = values[9].Trim();
                    if (!associationScore.Equals(string.Empty))
                    {
                        disease.associationScore = associationScore;
                    }
                    
                    string evidenceIndex = values[10].Trim();
                    if (!evidenceIndex.Equals(string.Empty))
                    {
                        disease.evidenceIndex = evidenceIndex;
                    }
                    
                    string yearInitialReport = values[11].Trim();
                    if (!yearInitialReport.Equals(string.Empty))
                    {
                       disease.yearInitialReport = yearInitialReport;
                    }
                    
                    string yearFinalReport = values[12].Trim();
                    if (!yearFinalReport.Equals(string.Empty))
                    {
                        disease.yearFinalReport = yearFinalReport;
                    }
                    
                    string pmId = values[13].Trim();
                    if (!pmId.Equals(string.Empty))
                    {
                        disease.pmId = pmId;
                    }
                    
                    string source = values[14].Trim();
                    if (!source.Equals(string.Empty))
                    {
                        disease.source = source;
                    }
                    
                    diseases_list.Add(disease);

                    gene.diseaseAssociations = diseases_list;

                    gene_list.Add(gene);

                    counter++;
                }
            }
            Methods.createXmlGene(gene_list: gene_list, fileName: "all_gene_disease_pmid_associations_dt.xml", directory: DI2.outputDirectory);
            Methods.createTsv(gene_list: gene_list, fileName: "all_gene_disease_pmid_associations_dt.tsv", directory: DI2.outputDirectory);
        }

    }
}