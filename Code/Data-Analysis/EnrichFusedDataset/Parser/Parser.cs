using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    public class Parser
    {

        public static List<Gene> getGeneList(FileInfo xmlFile)
        {

            List<Gene> geneList = new List<Gene>();


            XmlReaderSettings settings = new XmlReaderSettings();

            settings.DtdProcessing = DtdProcessing.Parse;


            using (XmlReader reader = XmlReader.Create(xmlFile.FullName, settings))
            {

                while (reader.ReadToFollowing("gene"))
                {

                    Gene gene = new Gene();


                    reader.ReadToFollowing("recordId");

                    string recordId = reader.ReadElementContentAsString().Trim();

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


                    reader.ReadToFollowing("geneNames");

                    string geneNames = reader.ReadElementContentAsString().Trim();

                    if (!geneNames.Equals(string.Empty))
                    {

                        gene.geneNames = geneNames;

                    }


                    reader.ReadToFollowing("geneDescriptions");

                    String geneDescriptions = reader.ReadElementContentAsString().Trim();

                    if (!geneDescriptions.Equals(string.Empty))
                    {

                        gene.geneDescriptions = geneDescriptions;

                    }


                    reader.ReadToFollowing("overallCall");

                    String overallCall = reader.ReadElementContentAsString().Trim();

                    if (!overallCall.Equals(string.Empty))
                    {

                        gene.overallCall = overallCall;

                    }


                    reader.ReadToFollowing("overallDiseaseAssociation");

                    String overallDiseaseAssociation = reader.ReadElementContentAsString().Trim();

                    if (!overallDiseaseAssociation.Equals(string.Empty))
                    {

                        gene.overallDiseaseAssociation = overallDiseaseAssociation;

                    }


                    reader.ReadToFollowing("firstPublicationYear");

                    String firstPublicationYear = reader.ReadElementContentAsString().Trim();

                    if (!firstPublicationYear.Equals(string.Empty))
                    {

                        gene.firstPublicationYear = firstPublicationYear;

                    }


                    reader.ReadToFollowing("frequencyPatent");

                    String frequencyPatent = reader.ReadElementContentAsString().Trim();

                    if (!frequencyPatent.Equals(string.Empty))
                    {

                        gene.frequencyPatent = frequencyPatent;

                    }


                    reader.ReadToFollowing("frequencyPatentTitle");

                    String frequencyPatentTitle = reader.ReadElementContentAsString().Trim();

                    if (!frequencyPatentTitle.Equals(string.Empty))
                    {

                        gene.frequencyPatentTitle = frequencyPatentTitle;

                    }


                    reader.ReadToFollowing("frequencyPatentAbstract");

                    String frequencyPatentAbstract = reader.ReadElementContentAsString().Trim();

                    if (!frequencyPatentAbstract.Equals(string.Empty))
                    {

                        gene.frequencyPatentAbstract = frequencyPatentAbstract;

                    }


                    reader.ReadToFollowing("frequencyPatentDescription");

                    String frequencyPatentDescription = reader.ReadElementContentAsString().Trim();

                    if (!frequencyPatentDescription.Equals(string.Empty))
                    {

                        gene.frequencyPatentDescription = frequencyPatentDescription;

                    }


                    reader.ReadToFollowing("frequencyPatentClaims");

                    String frequencyPatentClaims = reader.ReadElementContentAsString().Trim();

                    if (!frequencyPatentClaims.Equals(string.Empty))
                    {

                        gene.frequencyPatentClaims = frequencyPatentClaims;

                    }


                    // Organs

                    List<Organ> organList = new List<Organ>();

                    if (reader.ReadToFollowing("organs"))
                    {

                        string xml = "<organs>" + reader.ReadInnerXml() + "</organs>";

                        organList = parseOrgan(xml);

                    }

                    gene.organs = organList;


                    // Disease Associations

                    List<GeneDiseaseAssociation> diseaseAssociationList = new List<GeneDiseaseAssociation>();

                    if (reader.ReadToFollowing("diseaseAssociations"))
                    {

                        string xml = "<diseaseAssociations>" + reader.ReadInnerXml() + "</diseaseAssociations>";

                        diseaseAssociationList = parseDiseaseAssociation(xml);

                    }

                    gene.diseaseAssociations = diseaseAssociationList;


                    // Publication Mentions

                    List<GenePublicationMention> publicationMentionList = new List<GenePublicationMention>();

                    if (reader.ReadToFollowing("publicationMentions"))
                    {

                        string xml = "<publicationMentions>" + reader.ReadInnerXml() + "</publicationMentions>";

                        publicationMentionList = parsePublicationMention(xml);

                    }

                    gene.publicationMentions = publicationMentionList;


                    // PatentMentions

                    List<GenePatentMention> patentMentionList = new List<GenePatentMention>();

                    if (reader.ReadToFollowing("patentMentions"))
                    {

                        string xml = "<patentMentions>" + reader.ReadInnerXml() + "</patentMentions>";

                        patentMentionList = parsePatentMention(xml);

                    }

                    gene.patentMentions = patentMentionList;


                    geneList.Add(gene);


                }

            }

            return Parser.adjustRecordId(geneList, "AN_{0}_rid");

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


        public static List<GeneDiseaseAssociation> parseDiseaseAssociation(String xml)
        {

            List<GeneDiseaseAssociation> diseaseAssociationList = new List<GeneDiseaseAssociation>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/diseaseAssociations/diseaseAssociation");

            foreach (XmlNode node in NodeList)
            {

                GeneDiseaseAssociation diseaseAssociation = new GeneDiseaseAssociation();

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


        public static List<Gene> adjustRecordId(List<Gene> geneList, string recordIdPattern)
        {

            List<Gene> adjustedGeneList = new List<Gene>();

            int counter = 1;

            foreach (Gene item in geneList)
            {
                
                item.recordId = string.Format(recordIdPattern, counter);

                adjustedGeneList.Add(item);

                counter ++;

            }

            return adjustedGeneList;

        }

    }

}