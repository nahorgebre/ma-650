using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace Analysis
{

    public class Parser
    {

        public static Gene getGeneItem(XmlReader reader)
        {


            Gene gene = new Gene();


            reader.ReadToFollowing("recordId");

            String recordId = reader.ReadElementContentAsString().Trim();

            gene.recordId = recordId;


            reader.ReadToFollowing("ensemblId");

            String ensemblId = reader.ReadElementContentAsString().Trim();

            if (!ensemblId.Equals(string.Empty))
            {

                gene.ensemblId = ensemblId;

            }



            reader.ReadToFollowing("ncbiId");

            String ncbiId = reader.ReadElementContentAsString().Trim();

            if (!ncbiId.Equals(string.Empty))
            {

                gene.ncbiId = ncbiId;

            }



            reader.ReadToFollowing("geneDescriptions");

            String geneDescriptions = reader.ReadElementContentAsString().Trim();

            if (!geneDescriptions.Equals(string.Empty))
            {

                gene.geneDescriptions = geneDescriptions;

            }



            reader.ReadToFollowing("geneNames");

            string geneNames = reader.ReadInnerXml();

            if (!geneNames.Equals(string.Empty))
            {

                gene.geneNames = geneNames;

            }



            reader.ReadToFollowing("organs");

            string organs = reader.ReadInnerXml();

            if (!organs.Equals(string.Empty))
            {

                List<Organ> geneOrgansList = Parser.parseOrgan("<organs>" + organs + "</organs>");

                gene.organs = geneOrgansList;

            }



            reader.ReadToFollowing("diseaseAssociations");

            string diseaseAssociations = reader.ReadInnerXml();

            if (!diseaseAssociations.Equals(string.Empty))
            {

                List<DiseaseAssociation> geneDiseaseAssociationsList = Parser.parseDiseaseAssociation("<diseaseAssociations>" + diseaseAssociations + "</diseaseAssociations>");

                gene.diseaseAssociations = geneDiseaseAssociationsList;

            }



            reader.ReadToFollowing("publicationMentions");

            string publicationMentions = reader.ReadInnerXml();

            if (!publicationMentions.Equals(string.Empty))
            {

                List<GenePublicationMention> genePublicationMentionsList = Parser.parsePublicationMention("<publicationMentions>" + publicationMentions + "</publicationMentions>");

                gene.publicationMentions = genePublicationMentionsList;

            }



            reader.ReadToFollowing("patentMentions");

            string patentMentions = reader.ReadInnerXml();

            if (!patentMentions.Equals(string.Empty))
            {

                List<GenePatentMention> genePatentMentionsList = Parser.parsePatentMention("<patentMentions>" + patentMentions + "</patentMentions>");

                gene.patentMentions = genePatentMentionsList;

            }


            return gene;

        }


        public static List<Gene> parseGene(FileInfo xmlFile)
        {

            List<Gene> geneList = new List<Gene>();

            XmlReaderSettings settings = new XmlReaderSettings();

            settings.DtdProcessing = DtdProcessing.Parse;

            Console.WriteLine(xmlFile.Name);

            using var reader = XmlReader.Create(xmlFile.FullName, settings);

            do
            {

                Gene gene = getGeneItem(reader);

                geneList.Add(gene);

            } while (reader.ReadToFollowing("gene"));

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

            return organItemsAnalysis(organList);

        }

        public static List<Organ> organItemsAnalysis(List<Organ> organList)
        {

            string BrainCall = "N/A";
            string CerebellumCall = "N/A";
            string HeartCall = "N/A";
            string LiverCall = "N/A";
            string KidneyCall = "N/A";
            string TestisCall = "N/A";

            bool BrainExists = false;
            bool CerebellumExists = false;
            bool HeartExists = false;
            bool LiverExists = false;
            bool KidneyExists = false;
            bool TestisExists = false;

            foreach (Organ organItem in organList)
            {
                if (organItem.organName.Equals("brain"))
                {
                    BrainCall = Methods.getExpression(organItem.call);
                    organItem.call = BrainCall;

                    BrainExists = true;
                }
                else if (organItem.organName.Equals("cerebellum"))
                {
                    CerebellumCall = Methods.getExpression(organItem.call);
                    organItem.call = CerebellumCall;

                    CerebellumExists = true;
                }
                else if (organItem.organName.Equals("heart"))
                {
                    HeartCall = Methods.getExpression(organItem.call);
                    organItem.call = HeartCall;

                    HeartExists = true;
                }
                else if (organItem.organName.Equals("liver"))
                {
                    LiverCall = Methods.getExpression(organItem.call);
                    organItem.call = LiverCall;

                    LiverExists = true;
                }
                else if (organItem.organName.Equals("kidney"))
                {
                    KidneyCall = Methods.getExpression(organItem.call);
                    organItem.call = KidneyCall;

                    KidneyExists = true;
                }
                else if (organItem.organName.Equals("testis"))
                {
                    TestisCall = Methods.getExpression(organItem.call);
                    organItem.call = TestisCall;

                    TestisExists = true;
                }
            }
            
            if (BrainExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "brain";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (CerebellumExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "cerebellum";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (HeartExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "heart";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (LiverExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "liver";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (KidneyExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "kidney";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (TestisExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "testis";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }
            
            List<string> expressionList = new List<string>();
            expressionList.Add(BrainCall);
            expressionList.Add(CerebellumCall);
            expressionList.Add(HeartCall);
            expressionList.Add(LiverCall);
            expressionList.Add(KidneyCall);
            expressionList.Add(TestisCall);

            Organ overallExpression = new Organ();
            overallExpression.organName = "overallExpression";
            overallExpression.call = Methods.getOverallExpression(expressionList);
            organList.Add(overallExpression);

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