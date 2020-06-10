using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataTranslation
{
    public class generalMethods
    {
        public static List<Gene> createList(int begin, int end, List<Gene> source)
        {
            List<Gene> genes_list = new List<Gene>();
            for (int i = begin; i < end; i++)
            {
                genes_list.Add(source[i]);
            }
            return genes_list;
        }

        public static void createXml(List<Gene> gene_list, string targetFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Genes));
            TextWriter writer = new StreamWriter(targetFileName + ".xml");

            Genes genes = new Genes();
            genes.gene = gene_list;
            serializer.Serialize(writer, genes);
            writer.Close();
        }

        public void validateXmlFile(string filepath)
        {
            Console.WriteLine("Start validating XML file: " + filepath);
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                string path = System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
                path = path.Substring(0, path.LastIndexOf("\\"));
                settings.Schemas.Add("http://www.w3.org/2001/XMLSchema", path + @"\targetSchema\heart.xsd");
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(filepath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                document.Validate(eventHandler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning: {0}", e.Message);
                    break;
                default:
                    Console.WriteLine("XML file does fulfill the requirements of the Schema.");
                    break;
            }
        }

        public static string getProjectDirectory()
        {
            string path = Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }
    }

    public class brainMethods
    {
        // Brain.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Brain_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Brain\Brain.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Brain_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[3];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Brain\Brain_dt");
        }

        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_brain_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Brain\mart_export_brain.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_brain_" + counter;
                    gene.geneId = values[0];

                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneName = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Brain\mart_export_brain_dt");
        }
    }

    public class cerebellumMethods
    {
        // Cerebellum.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Cerebellum_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Cerebellum\Cerebellum.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Cerebellum_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[3];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Cerebellum\Cerebellum_dt");
        }
        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_cerebellum_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Cerebellum\mart_export_cerebellum.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_cerebellum_" + counter;
                    gene.geneId = values[0];

                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneName = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Cerebellum\mart_export_cerebellum_dt");
        }
    }

    public class heartMethods
    {
        // heart.csv; 0-geneId; 1-disagreement; 2-call
        public static void Heart_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();
 
            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Heart\Heart.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Heart_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[2];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Heart\Heart_dt");
        }
        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_heart_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Heart\mart_export_heart.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_heart_" + counter;
                    gene.geneId = values[0];

                    gene.geneName = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneDescription = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Heart\mart_export_heart_dt");
        }
        // ncbi; 0-ncbi; 1-geneId; 2-geneName
        public static void Heart_Ensembl_NCBI_Crosswalk_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Heart\Heart_Ensembl_NCBI_Crosswalk.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Heart_Ensembl_NCBI_Crosswalk_" + counter;
                    gene.ncbiId = values[0];
                    gene.geneId = values[1];
                    gene.geneName = values[2];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Heart\Heart_Ensembl_NCBI_Crosswalk_dt");
        }
    }

    public class kidneyMethods
    {
        // Kidney.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Kidney_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Kidney\Kidney.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Kidney_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[3];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Kidney\Kidney_dt");
        }
        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_kidney_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Kidney\mart_export_kidney.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_kidney_" + counter;
                    gene.geneId = values[0];

                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneName = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Kidney\mart_export_kidney_dt");
        }
    }

    public class liverMetods
    {
        // liver.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Liver_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Liver\Liver.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Liver_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[3];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Liver\Liver_dt");
        }
        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_liver_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Liver\mart_export_liver.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_liver_" + counter;
                    gene.geneId = values[0];

                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneName = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Liver\mart_export_liver_dt");
        }
    }

    public class testisMethods
    {
        // testis.csv; 0-geneId; 1-disagreement; 2-prob_equal_ortho_adj; 3-call
        public static void Testis_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Testis\Testis.csv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "Testis_" + counter;
                    gene.geneId = values[0];
                    gene.disagreement = values[1];
                    gene.call = values[3];

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Liver\Testis_dt");
        }
        // mart.txt; 0-geneId; 1-geneDescription; 2-geneName
        public static void mart_export_testis_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Testis\mart_export_testis.txt"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "mart_export_testis_" + counter;
                    gene.geneId = values[0];

                    gene.geneDescription = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    gene.geneName = line.Substring(line.LastIndexOf(",") + 1);

                    //List<Disease> diseases_list = new List<Disease>();
                    //Disease disease = new Disease();
                    //diseases_list.Add(disease);
                    //gene.diseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Liver\mart_export_testis_dt");
        }
    }

    public class geneDiseaseAssociationsMethods
    {
        public static void all_gene_disease_pmid_associations_dt()
        {
            List<Gene> genes_list = new List<Gene>();

            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Gene-Disease-Associations\all_gene_disease_pmid_associations.tsv"))
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
                    gene.recordId = "gene_disease_pmid_associations_" + counter;
                    gene.geneName = values[1];


                    List<AssociatedDisease> diseases_list = new List<AssociatedDisease>();
                    AssociatedDisease disease = new AssociatedDisease();
                    disease.diseaseIdUMLS = values[4];
                    disease.diseaseName = values[5];
                    disease.diseaseSpecificityIndex = values[2];
                    disease.diseasePleiotropyIndex = values[3];
                    disease.diseaseTypeDisGeNET = values[6];
                    disease.diseaseClassMeSH = values[7];
                    disease.diseaseSemanticTypeUMLS = values[8];
                    disease.associationScore = values[9];
                    disease.evidenceIndex = values[10];
                    disease.yearInitialReport = values[11];
                    disease.yearFinalReport = values[12];
                    disease.pmid = values[13];
                    disease.source = values[14];
                    diseases_list.Add(disease);

                    gene.associatedDiseases = diseases_list;

                    genes_list.Add(gene);

                    counter++;
                }
            }
                       
            createFiles(genes_list);
            createReadOnlyFiles(genes_list);
            createSingleFile(genes_list);
        }

        public static void createFiles(List<Gene> genes_list)
        {
            int length = genes_list.Count;
            int partition = length / 25;

            List<Gene> genes_list_1 = new List<Gene>();
            genes_list_1 = generalMethods.createList(0, partition, genes_list);
            List<Gene> genes_list_2 = new List<Gene>();
            genes_list_2 = generalMethods.createList(partition, partition * 2, genes_list);
            List<Gene> genes_list_3 = new List<Gene>();
            genes_list_3 = generalMethods.createList(partition * 2, partition * 3, genes_list);
            List<Gene> genes_list_4 = new List<Gene>();
            genes_list_4 = generalMethods.createList(partition * 3, partition * 4, genes_list);
            List<Gene> genes_list_5 = new List<Gene>();
            genes_list_5 = generalMethods.createList(partition * 4, partition * 5, genes_list);
            List<Gene> genes_list_6 = new List<Gene>();
            genes_list_6 = generalMethods.createList(partition * 5, partition * 6, genes_list);
            List<Gene> genes_list_7 = new List<Gene>();
            genes_list_7 = generalMethods.createList(partition * 6, partition * 7, genes_list);
            List<Gene> genes_list_8 = new List<Gene>();
            genes_list_8 = generalMethods.createList(partition * 7, partition * 8, genes_list);
            List<Gene> genes_list_9 = new List<Gene>();
            genes_list_9 = generalMethods.createList(partition * 8, partition * 9, genes_list);
            List<Gene> genes_list_10 = new List<Gene>();
            genes_list_10 = generalMethods.createList(partition * 9, partition * 10, genes_list);
            List<Gene> genes_list_11 = new List<Gene>();
            genes_list_11 = generalMethods.createList(partition * 10, partition * 11, genes_list);
            List<Gene> genes_list_12 = new List<Gene>();
            genes_list_12 = generalMethods.createList(partition * 11, partition * 12, genes_list);
            List<Gene> genes_list_13 = new List<Gene>();
            genes_list_13 = generalMethods.createList(partition * 12, partition * 13, genes_list);
            List<Gene> genes_list_14 = new List<Gene>();
            genes_list_14 = generalMethods.createList(partition * 13, partition * 14, genes_list);
            List<Gene> genes_list_15 = new List<Gene>();
            genes_list_15 = generalMethods.createList(partition * 14, partition * 15, genes_list);
            List<Gene> genes_list_16 = new List<Gene>();
            genes_list_16 = generalMethods.createList(partition * 15, partition * 16, genes_list);
            List<Gene> genes_list_17 = new List<Gene>();
            genes_list_17 = generalMethods.createList(partition * 16, partition * 17, genes_list);
            List<Gene> genes_list_18 = new List<Gene>();
            genes_list_18 = generalMethods.createList(partition * 17, partition * 18, genes_list);
            List<Gene> genes_list_19 = new List<Gene>();
            genes_list_19 = generalMethods.createList(partition * 18, partition * 19, genes_list);
            List<Gene> genes_list_20 = new List<Gene>();
            genes_list_20 = generalMethods.createList(partition * 19, partition * 20, genes_list);
            List<Gene> genes_list_21 = new List<Gene>();
            genes_list_21 = generalMethods.createList(partition * 20, partition * 21, genes_list);
            List<Gene> genes_list_22 = new List<Gene>();
            genes_list_22 = generalMethods.createList(partition * 21, partition * 22, genes_list);
            List<Gene> genes_list_23 = new List<Gene>();
            genes_list_23 = generalMethods.createList(partition * 22, partition * 23, genes_list);
            List<Gene> genes_list_24 = new List<Gene>();
            genes_list_24 = generalMethods.createList(partition * 23, partition * 24, genes_list);
            List<Gene> genes_list_25 = new List<Gene>();
            genes_list_25 = generalMethods.createList(partition * 24, length, genes_list);

            generalMethods.createXml(genes_list_1, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_1");
            generalMethods.createXml(genes_list_2, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_2");
            generalMethods.createXml(genes_list_3, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_3");
            generalMethods.createXml(genes_list_4, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_4");
            generalMethods.createXml(genes_list_5, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_5");
            generalMethods.createXml(genes_list_6, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_6");
            generalMethods.createXml(genes_list_7, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_7");
            generalMethods.createXml(genes_list_8, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_8");
            generalMethods.createXml(genes_list_9, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_9");
            generalMethods.createXml(genes_list_10, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_10");
            generalMethods.createXml(genes_list_11, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_11");
            generalMethods.createXml(genes_list_12, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_12");
            generalMethods.createXml(genes_list_13, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_13");
            generalMethods.createXml(genes_list_14, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_14");
            generalMethods.createXml(genes_list_15, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_15");
            generalMethods.createXml(genes_list_16, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_16");
            generalMethods.createXml(genes_list_17, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_17");
            generalMethods.createXml(genes_list_18, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_18");
            generalMethods.createXml(genes_list_19, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_19");
            generalMethods.createXml(genes_list_20, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_20");
            generalMethods.createXml(genes_list_21, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_21");
            generalMethods.createXml(genes_list_22, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_22");
            generalMethods.createXml(genes_list_23, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_23");
            generalMethods.createXml(genes_list_24, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_24");
            generalMethods.createXml(genes_list_25, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt_25");
        }

        public static void createSingleFile(List<Gene> genes_list)
        {
            generalMethods.createXml(genes_list, @"Gene-Disease-Associations\all_gene_disease_pmid_associations_dt");
        }

        public static void createReadOnlyFiles(List<Gene> genes_list)
        {
            int length = genes_list.Count;
            int partition = length / 4;

            List<Gene> genes_list_1 = new List<Gene>();
            genes_list_1 = generalMethods.createList(0, partition, genes_list);
            List<Gene> genes_list_2 = new List<Gene>();
            genes_list_2 = generalMethods.createList(partition, partition * 2, genes_list);
            List<Gene> genes_list_3 = new List<Gene>();
            genes_list_3 = generalMethods.createList(partition * 2, partition * 3, genes_list);
            List<Gene> genes_list_4 = new List<Gene>();
            genes_list_4 = generalMethods.createList(partition * 3, length, genes_list);

            generalMethods.createXml(genes_list_1, @"Gene-Disease-Associations\gene_disease_associations_read_only_1");
            generalMethods.createXml(genes_list_2, @"Gene-Disease-Associations\gene_disease_associations_read_only_2");
            generalMethods.createXml(genes_list_3, @"Gene-Disease-Associations\gene_disease_associations_read_only_3");
            generalMethods.createXml(genes_list_4, @"Gene-Disease-Associations\gene_disease_associations_read_only_4");
        }
    }

    public class publicationMentionsMethods
    {
        public static void publicationMentions_dt()
        {
            Genes genes = new Genes();
            List<Gene> genes_list = new List<Gene>();
 
            using (var reader = new StreamReader(generalMethods.getProjectDirectory() + @"\data\Publication-Mentions\gene2pubtatorcentral.tsv"))
            {
                reader.ReadLine();
                int counter = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    Gene gene = new Gene();
                    gene.recordId = "PublicationMentions_" + counter;
                    
                    List<PublicationMention> publicationMentions_list = new List<PublicationMention>();
                    PublicationMention publicationMention = new PublicationMention();
                    publicationMention.pmid = values[0];
                    publicationMentions_list.Add(publicationMention);
                    gene.publicationMentions = publicationMentions_list;

                    gene.ncbiId = values[2];
                    gene.geneName = values[3];

                    genes_list.Add(gene);

                    counter++;
                }
            }
            generalMethods.createXml(genes_list, @"Publication-Mentions\gene2pubtatorcentral_dt");
        }
    }
}
