using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class Kaessmann
    {

        public static void runDataTranslation()
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/input/DI2/kaessmann-fused.xml", Environment.CurrentDirectory));

            List<Gene> gene_list = parseXml(file, "Kaessmann_{0}_rid");

            /*
            foreach (Gene geneItem in gene_list)
            {
                
                foreach (GeneName geneNameItem in geneItem.geneNames)
                {

                    Console.WriteLine("Name: " + geneNameItem.name);

                }

            }
            */

            Methods.createXml(gene_list: gene_list, fileName: "Kaessmann_dt.xml", directory: "data/output/DI2");
            //Methods.createTsv(gene_list: gene_list, fileName: "Kaessmann_dt.tsv", directory: string.Format("{0}/data/input/DI2/", Environment.CurrentDirectory) );

        }

        public static List<Gene> parseXml(FileInfo file, String recordIdPattern)
        {

            List<Gene> geneList = new List<Gene>();

            int counter = 1;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;

            using (XmlReader reader = XmlReader.Create(file.FullName, settings))
            {
                while (reader.ReadToFollowing("gene"))
                {

                    Gene gene = new Gene();

                    gene.recordId = string.Format("Kaessmann_{0}_rid", counter);

                    // ensemblId
                    String ensemblId = string.Empty;
                    reader.ReadToFollowing("ensemblId");
                    ensemblId = reader.ReadElementContentAsString();

                    gene.ensemblId = ensemblId;


                    // ncbiId
                    String ncbiId = string.Empty;
                    reader.ReadToFollowing("ncbiId");
                    ncbiId = reader.ReadElementContentAsString();

                    gene.ncbiId = ncbiId;


                    // geneDescriptions
                    reader.ReadToFollowing("geneDescriptions"); 
                    XmlReader geneDescriptionsInner = reader.ReadSubtree();
                    while (geneDescriptionsInner.Read())
                    {
                    }


                    // geneNames
                    List<GeneName> geneNameList = new List<GeneName>();

                    reader.ReadToFollowing("geneNames"); 
                    XmlReader geneNamesInner = reader.ReadSubtree();
                    while (geneNamesInner.Read())
                    {

                        Console.WriteLine(geneNamesInner.ReadInnerXml());

                        /*                
                        if (geneNamesInner.HasValue)
                        {

                            geneNamesInner.ReadToFollowing("geneName");
                            XmlReader geneNameInner = geneNamesInner.ReadSubtree();
                            while (geneNameInner.Read())
                            {

                                Console.WriteLine(geneNameInner.ReadInnerXml());

                                //geneNameList.Add(parseGeneName(geneNameInner.ReadInnerXml()));

                            }

                        }
                        */

                    }

                    gene.geneNames = geneNameList;


                    // organs
                    List<Organ> organList = new List<Organ>();

                    reader.ReadToFollowing("organs"); 
                    XmlReader organsInner = reader.ReadSubtree();
                    while (organsInner.Read())
                    {

                        Console.WriteLine(organsInner.ReadInnerXml());

                        /*
                        if (organsInner.HasValue)
                        {

                            organsInner.ReadToFollowing("organ");
                            XmlReader organInner = organsInner.ReadSubtree();
                            while (organInner.Read())
                            {

                                Console.WriteLine(organInner.ReadInnerXml());

                                //organList.Add(parseOrgan(organInner.ReadInnerXml()));

                            }

                        }
                        */
                        
                    }

                    gene.organs = organList;
                    

                    // publicationMentions
                    reader.ReadToFollowing("publicationMentions"); 
                    XmlReader publicationMentionsInner = reader.ReadSubtree();
                    while (publicationMentionsInner.Read())
                    {
                    }

                    // patentMentions
                    reader.ReadToFollowing("patentMentions"); 
                    XmlReader patentMentionsInner = reader.ReadSubtree();
                    while (patentMentionsInner.Read())
                    {
                    }

                    // diseaseAssociations
                    reader.ReadToFollowing("diseaseAssociations"); 
                    XmlReader diseaseAssociationsInner = reader.ReadSubtree();
                    while (diseaseAssociationsInner.Read())
                    {
                    }

                    geneList.Add(gene);

                    counter++;

                }

            }

            return geneList;

        }

        public static GeneName parseGeneName(String Xml)
        {

            GeneName geneNameItem = new GeneName();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Xml);

            XmlNode geneNameNode = doc.DocumentElement.SelectSingleNode("geneName");
            
            String name = (geneNameNode?.SelectSingleNode("/geneName/name").InnerText ?? null);
            geneNameItem.name = name;

            Console.WriteLine(name);
        

            return geneNameItem;

        }

        public static Organ parseOrgan(String Xml)
        {

            Organ organItem = new Organ();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Xml);

            XmlNode organNode = doc.DocumentElement.SelectSingleNode("organ");

            String organName = (organNode?.SelectSingleNode("organName").InnerText ?? null);
            organItem.organName = organName;

            String disagreement = (organNode?.SelectSingleNode("disagreement").InnerText ?? null);
            organItem.disagreement = disagreement;

            String probEqualOrthoAdj = (organNode?.SelectSingleNode("probEqualOrthoAdj").InnerText ?? null);
            organItem.probEqualOrthoAdj = probEqualOrthoAdj;

            String call = (organNode?.SelectSingleNode("call").InnerText ?? null);
            organItem.call = call;

            return organItem;

        }

        public static List<Gene> extractXml(FileInfo file) {

            List<Gene> geneList = new List<Gene>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file.FullName);

            int counter = 1;

            XmlNodeList geneNodeList = doc.DocumentElement.SelectNodes("/genes/gene");
            foreach (XmlNode geneNode in geneNodeList)
            {

                Gene gene = new Gene();

                gene.recordId = string.Format("Kaessmann_{0}_rid", counter);

                String ensemblId = (geneNode?.SelectSingleNode("ensemblId").InnerText ?? null);
                gene.ensemblId = ensemblId;

                String ncbiId = (geneNode?.SelectSingleNode("ncbiId").InnerText ?? null);
                gene.ncbiId = ncbiId;

                // geneDescriptions
                List<GeneDescription> geneDescriptionList = new List<GeneDescription>();

                XmlNodeList geneDescriptionXmlNodeList = geneNode.SelectNodes("/geneDescriptions/geneDescriptions");
                foreach (XmlNode geneDescription in geneDescriptionXmlNodeList)
                {

                    GeneDescription geneDescriptionItem = new GeneDescription();
                    String description = (geneDescription?.SelectSingleNode("description").InnerText ?? null);
                    geneDescriptionItem.description = description;

                    geneDescriptionList.Add(geneDescriptionItem);

                }

                gene.geneDescriptions = geneDescriptionList;


                // geneNames
                List<GeneName> geneNameList = new List<GeneName>();
              
                XmlNodeList geneNameXmlNodeList = geneNode.SelectNodes("/geneNames/geneNames");
                foreach (XmlNode geneName in geneNameXmlNodeList)
                {

                    GeneName geneNameItem = new GeneName();
                    String name = (geneName?.SelectSingleNode("name").InnerText ?? null);
                    geneNameItem.name = name;

                    geneNameList.Add(geneNameItem);
            
                }

                gene.geneNames = geneNameList;


                // organs
                List<Organ> organList = new List<Organ>();
    
                XmlNodeList organXmlNodeList = geneNode.SelectNodes("/organs/organs");
                foreach (XmlNode organ in organXmlNodeList)
                {

                    Organ organItem = new Organ();

                    String organName = (organ?.SelectSingleNode("organName").InnerText ?? null);
                    organItem.organName = organName;

                    String disagreement = (organ?.SelectSingleNode("disagreement").InnerText ?? null);
                    organItem.disagreement = disagreement;

                    String probEqualOrthoAdj = (organ?.SelectSingleNode("probEqualOrthoAdj").InnerText ?? null);
                    organItem.probEqualOrthoAdj = probEqualOrthoAdj;

                    String call = (organ?.SelectSingleNode("call").InnerText ?? null);
                    organItem.call = call;

                    organList.Add(organItem);

                }

                gene.organs = organList; 
                

                geneList.Add(gene);

                counter++;
                          
            }

            return geneList;

        }

    }

}