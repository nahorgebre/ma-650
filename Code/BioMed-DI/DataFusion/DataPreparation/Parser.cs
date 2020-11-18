using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataPreparation
{

    public class Parser
    {

        public static Dictionary<string, bool> getRecordIdList(FileInfo recordIdListFile)
        {

            Dictionary<string, bool> recordIdList = new Dictionary<string, bool>();

            using (StreamReader sr = new StreamReader(recordIdListFile.FullName))
            {

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine().Trim();

                    recordIdList.Add(line, true);

                }

            }

            return recordIdList;

        }

        public static Gene getGeneItem(XmlReader reader)
        {


            Gene gene = new Gene();

            
            reader.ReadToFollowing("recordId");

            String recordId = reader.ReadElementContentAsString().Trim();

            gene.recordId = recordId;


            reader.ReadToFollowing("ensemblId");

            if (reader.HasValue)
            {

                String ensemblId = reader.ReadElementContentAsString().Trim();

                if (!ensemblId.Equals(string.Empty))
                {

                    gene.ensemblId = ensemblId;

                }

            }


            reader.ReadToFollowing("ncbiId");

            if (reader.HasValue)
            {

                String ncbiId = reader.ReadElementContentAsString().Trim();

                if (!ncbiId.Equals(string.Empty))
                {

                    gene.ncbiId = ncbiId;

                }

            }


            reader.ReadToFollowing("geneDescriptions");

            if (reader.HasValue)
            {

                String geneDescriptions = reader.ReadElementContentAsString().Trim();

                if (!geneDescriptions.Equals(string.Empty))
                {

                    gene.geneDescriptions = geneDescriptions;

                }

            }


            reader.ReadToFollowing("geneNames");

            if (reader.HasValue)
            {

                String geneNames = reader.ReadElementContentAsString().Trim();

                if (!geneNames.Equals(string.Empty))
                {

                    gene.geneNames = geneNames;

                }

            }


            reader.ReadToFollowing("organs");

            if (reader.HasValue)
            {

                XmlReader organsInner = reader.ReadSubtree();

                while (organsInner.Read())
                {

                    String xml = "<organs>" + organsInner.ReadInnerXml() + "</organs>";

                    List<Organ> organList = Parser.parseOrgan(xml);

                    gene.organs = organList;

                }

            }


            reader.ReadToFollowing("diseaseAssociations");

            if (reader.HasValue)
            {

                XmlReader diseaseAssociationsInner = reader.ReadSubtree();

                while (diseaseAssociationsInner.Read())
                {

                    String xml = "<diseaseAssociations>" + diseaseAssociationsInner.ReadInnerXml() + "</diseaseAssociations>";

                    List<DiseaseAssociation> geneDiseaseAssociationsList = Parser.parseDiseaseAssociation(xml);

                    gene.diseaseAssociations = geneDiseaseAssociationsList;

                }

            }


            reader.ReadToFollowing("publicationMentions");

            if (reader.HasValue)
            {

                XmlReader publicationMentionsInner = reader.ReadSubtree();

                while (publicationMentionsInner.Read())
                {

                    String xml = "<publicationMentions>" + publicationMentionsInner.ReadInnerXml() + "</publicationMentions>";

                    List<GenePublicationMention> genePublicationMentionList = Parser.parsePublicationMention(xml);

                    gene.publicationMentions = genePublicationMentionList;

                }

            }


            reader.ReadToFollowing("patentMentions");

            if (reader.HasValue)
            {

                XmlReader patentMentionsInner = reader.ReadSubtree();

                while (patentMentionsInner.Read())
                {

                    String xml = "<patentMentions>" + patentMentionsInner.ReadInnerXml() + "</patentMentions>";

                    List<GenePatentMention> genePatentMentionList = Parser.parsePatentMention(xml);

                    gene.patentMentions = genePatentMentionList;

                }

            }


            return gene;

        }


        public static List<Gene> parseGene(FileInfo xmlFile, FileInfo recordIdListFile)
        {

            Dictionary<string, bool> recordIdList = getRecordIdList(recordIdListFile);

            List<Gene> geneList = new List<Gene>();

            XmlReaderSettings settings = new XmlReaderSettings();

            settings.DtdProcessing = DtdProcessing.Parse;

            Console.WriteLine(xmlFile.Name);

            int counterTrue = 0;

            int counter = 0;

            using (XmlReader reader = XmlReader.Create(xmlFile.FullName, settings))
            {

                while (reader.ReadToFollowing("gene"))
                {

                    Gene gene = new Gene();

                    reader.ReadToFollowing("recordId");
                    String recordId = reader.ReadElementContentAsString().Trim();
                    gene.recordId = recordId;

                    /*
                    reader.ReadToFollowing("ensemblId");
                    if (reader.HasValue)
                    {
                        String ensemblId = reader.ReadElementContentAsString().Trim();
                        if (!ensemblId.Equals(string.Empty))
                        {
                            gene.ensemblId = ensemblId;
                        }
                    }
                    */ 



                    
                    if (recordIdList.ContainsKey(gene.recordId))
                    {
                        counterTrue++;

                        geneList.Add(gene);

                    }
                    

                    counter++;

                }

            }

            Console.WriteLine("Counter: " + counter);

            Console.WriteLine("Counter True: " + counterTrue);

            Console.WriteLine("Gene List Size: " + geneList.Count);

            return geneList;

        }


        public static List<Organ> parseOrgan(String xml)
        {

            List<Organ> organList = new List<Organ>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/organs/organ");

            foreach (XmlNode node in NodeList)
            {

                Organ organItem = new Organ();

                if (checkIfNodeExist(node, "organName"))
                {

                    organItem.organName = (node?.SelectSingleNode("organName").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "disagreement"))
                {

                    organItem.disagreement = (node?.SelectSingleNode("disagreement").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "probEqualOrthoAdj"))
                {

                    organItem.probEqualOrthoAdj = (node?.SelectSingleNode("probEqualOrthoAdj").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "call"))
                {

                    organItem.call = (node?.SelectSingleNode("call").InnerText ?? null);

                }

                organList.Add(organItem);

            }

            return organList;

        }


        public static List<DiseaseAssociation> parseDiseaseAssociation(String xml)
        {

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/diseaseAssociations/diseaseAssociation");

            foreach (XmlNode node in NodeList)
            {

                DiseaseAssociation diseaseAssociation = new DiseaseAssociation();

                if (checkIfNodeExist(node, "diseaseIdUMLS"))
                {

                    diseaseAssociation.diseaseIdUMLS = (node?.SelectSingleNode("diseaseIdUMLS").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseaseName"))
                {

                    diseaseAssociation.diseaseName = (node?.SelectSingleNode("diseaseName").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseaseSpecificityIndex"))
                {

                    diseaseAssociation.diseaseSpecificityIndex = (node?.SelectSingleNode("diseaseSpecificityIndex").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseasePleiotropyIndex"))
                {

                    diseaseAssociation.diseasePleiotropyIndex = (node?.SelectSingleNode("diseasePleiotropyIndex").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseaseTypeDisGeNET"))
                {

                    diseaseAssociation.diseaseTypeDisGeNET = (node?.SelectSingleNode("diseaseTypeDisGeNET").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseaseClassMeSH"))
                {

                    diseaseAssociation.diseaseClassMeSH = (node?.SelectSingleNode("diseaseClassMeSH").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "diseaseSemanticTypeUMLS"))
                {

                    diseaseAssociation.diseaseSemanticTypeUMLS = (node?.SelectSingleNode("diseaseSemanticTypeUMLS").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "associationScore"))
                {

                    diseaseAssociation.associationScore = (node?.SelectSingleNode("associationScore").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "evidenceIndex"))
                {

                    diseaseAssociation.evidenceIndex = (node?.SelectSingleNode("evidenceIndex").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "yearInitialReport"))
                {

                    diseaseAssociation.yearInitialReport = (node?.SelectSingleNode("yearInitialReport").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "yearFinalReport"))
                {

                    diseaseAssociation.yearFinalReport = (node?.SelectSingleNode("yearFinalReport").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "pmId"))
                {

                    diseaseAssociation.pmId = (node?.SelectSingleNode("pmId").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "source"))
                {

                    diseaseAssociation.source = (node?.SelectSingleNode("source").InnerText ?? null);

                }

                diseaseAssociationList.Add(diseaseAssociation);

            }

            return diseaseAssociationList;

        }


        public static List<GenePublicationMention> parsePublicationMention(String xml)
        {

            List<GenePublicationMention> genePublicationMentionList = new List<GenePublicationMention>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/publicationMentions/publicationMention");

            foreach (XmlNode node in NodeList)
            {

                GenePublicationMention genePublicationMention = new GenePublicationMention();

                if (checkIfNodeExist(node, "pmId"))
                {

                    genePublicationMention.pmId = (node?.SelectSingleNode("pmId").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "year"))
                {

                    genePublicationMention.year = (node?.SelectSingleNode("year").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "ressource"))
                {

                    genePublicationMention.ressource = (node?.SelectSingleNode("ressource").InnerText ?? null);

                }

                genePublicationMentionList.Add(genePublicationMention);

            }

            return genePublicationMentionList;

        }


        public static List<GenePatentMention> parsePatentMention(String xml)
        {

            List<GenePatentMention> genePatentMentionList = new List<GenePatentMention>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/patentMentions/patentMention");

            foreach (XmlNode node in NodeList)
            {

                GenePatentMention genePatentMention = new GenePatentMention();

                if (checkIfNodeExist(node, "patentId"))
                {

                    genePatentMention.patentId = (node?.SelectSingleNode("patentId").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "patentDate"))
                {

                    genePatentMention.patentDate = (node?.SelectSingleNode("patentDate").InnerText ?? null);

                }

                if (checkIfNodeExist(node, "patentClaimsCount"))
                {

                    genePatentMention.patentClaimsCount = (node?.SelectSingleNode("patentClaimsCount").InnerText ?? null);

                }

            }

            return genePatentMentionList;

        }


        public static bool checkIfNodeExist(XmlNode node, String xpath)
        {

            bool status = true;

            var langNode = node.SelectSingleNode(xpath);

            if (langNode == null)
            {

                status = false;

            }

            return status;

        }


    }

}