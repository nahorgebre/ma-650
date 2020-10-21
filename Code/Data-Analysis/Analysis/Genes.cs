using System.Collections.Generic;
using System.Xml;

namespace Analysis
{
    public class Genes
    {
        public static List<Gene> getGenes(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/genes/gene");

            List<Gene> geneList = new List<Gene>();

            foreach (XmlNode node in nodes)
            {
                Gene gene = new Gene();
                gene.ensemblId = node.SelectSingleNode("ensemblId").InnerText;
                gene.ncbiId = node.SelectSingleNode("ncbiId").InnerText;

                gene.descriptions = GeneDescription.getDescriptionList(node.SelectSingleNode("geneDescriptions").ChildNodes);
                gene.organs = Organ.getOrganList(node.SelectSingleNode("organs").ChildNodes);
                gene.geneNames = GeneName.getGeneNameList(node.SelectSingleNode("geneNames").ChildNodes);
                gene.patentMentions = PatentMention.getPatentMentionList(node.SelectSingleNode("patentMentions").ChildNodes);
                gene.publicationMentions = PublicationMention.getPublicationMentionList(node.SelectSingleNode("publicationMentions").ChildNodes);
                gene.diseaseAssociations = DiseaseAssociation.getDiseaseAssociationList(node.SelectSingleNode("diseaseAssociations").ChildNodes);

                geneList.Add(gene);
            }

            return geneList;
        }


    }

    public class Gene 
    {
        public string ensemblId;
        public string ncbiId;
        public List<Organ> organs;
        public List<GeneDescription> descriptions;
        public List<GeneName> geneNames;
        public List<DiseaseAssociation> diseaseAssociations;
        public List<PublicationMention> publicationMentions;
        public List<PatentMention> patentMentions;
    }

    public class GeneDescription
    {
        public string description;

        public static List<GeneDescription> getDescriptionList (XmlNodeList childNodes)
        {

            List<GeneDescription> descriptionList = new List<GeneDescription>();
            foreach(XmlNode node in childNodes)
            {

                GeneDescription geneDescription = new GeneDescription();

                geneDescription.description = node.SelectSingleNode("description").InnerText;

                descriptionList.Add(geneDescription);
            }

            return descriptionList;
        }
    }

    public class Organ
    {
        public string organName;
        public string disagreement;
        public string probEqualOrthoAdj;
        public string call;

        public static List<Organ> getOrganList (XmlNodeList childNodes)
        {
            List<Organ> organList = new List<Organ>();
            foreach(XmlNode node in childNodes)
            {
                Organ organ = new Organ();

                if (node.SelectSingleNode("organName")!=null)
                {
                    organ.organName = node.SelectSingleNode("organName").InnerText;
                }

                if (node.SelectSingleNode("disagreement")!=null)
                {
                    organ.disagreement = node.SelectSingleNode("disagreement").InnerText;
                }

                if (node.SelectSingleNode("probEqualOrthoAdj")!=null)
                {
                    organ.probEqualOrthoAdj = node.SelectSingleNode("probEqualOrthoAdj").InnerText;
                }

                if (node.SelectSingleNode("call")!=null)
                {
                    organ.call = node.SelectSingleNode("call").InnerText;
                } 

                organList.Add(organ);
            }

            return organList;
        }
    }

    public class GeneName 
    {
        public string name;

        public static List<GeneName> getGeneNameList (XmlNodeList childNodes)
        {
            List<GeneName> geneNameList = new List<GeneName>();
            foreach(XmlNode node in childNodes)
            {
                GeneName geneName = new GeneName();

                geneName.name = node.SelectSingleNode("name").InnerText;

                geneNameList.Add(geneName);
            }

            return geneNameList;
        }
    }

    public class DiseaseAssociation
    {
        public string diseaseIdUMLS;
        public string diseaseName;
        public string diseaseSpecificityIndex;
        public string diseasePleiotropyIndex;
        public string diseaseTypeDisGeNET;
        public string diseaseClassMeSH;
        public string diseaseSemanticTypeUMLS;
        public string associationScore;
        public string evidenceIndex;
        public string yearInitialReport;
        public string yearFinalReport;
        public string pmId;
        public string source;

        public static List<DiseaseAssociation> getDiseaseAssociationList (XmlNodeList childNodes)
        {
            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            foreach(XmlNode node in childNodes)
            {
                DiseaseAssociation diseaseAssociation = new DiseaseAssociation();

                diseaseAssociation.diseaseIdUMLS = node.SelectSingleNode("diseaseIdUMLS").InnerText;
                diseaseAssociation.diseaseName = node.SelectSingleNode("diseaseName").InnerText;
                diseaseAssociation.diseaseSpecificityIndex = node.SelectSingleNode("diseaseSpecificityIndex").InnerText;
                diseaseAssociation.diseasePleiotropyIndex = node.SelectSingleNode("diseasePleiotropyIndex").InnerText;
                diseaseAssociation.diseaseTypeDisGeNET = node.SelectSingleNode("diseaseTypeDisGeNET").InnerText;
                diseaseAssociation.diseaseClassMeSH = node.SelectSingleNode("diseaseClassMeSH").InnerText;
                diseaseAssociation.diseaseSemanticTypeUMLS = node.SelectSingleNode("diseaseSemanticTypeUMLS").InnerText;
                diseaseAssociation.associationScore = node.SelectSingleNode("associationScore").InnerText;
                diseaseAssociation.evidenceIndex = node.SelectSingleNode("evidenceIndex").InnerText;
                diseaseAssociation.yearInitialReport = node.SelectSingleNode("yearInitialReport").InnerText;
                diseaseAssociation.yearFinalReport = node.SelectSingleNode("yearFinalReport").InnerText;
                diseaseAssociation.pmId = node.SelectSingleNode("pmId").InnerText;
                diseaseAssociation.source = node.SelectSingleNode("source").InnerText;

                diseaseAssociationList.Add(diseaseAssociation);
            }

            return diseaseAssociationList;
        }

    }

    public class PublicationMention
    {
        public string pmid;
        public string ressource;

        public static List<PublicationMention> getPublicationMentionList (XmlNodeList childNodes)
        {
            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            foreach(XmlNode node in childNodes)
            {
                PublicationMention publicationMention = new PublicationMention();

                publicationMention.pmid = node.SelectSingleNode("pmid").InnerText;
                publicationMention.ressource = node.SelectSingleNode("ressource").InnerText;

                publicationMentionList.Add(publicationMention);
            }

            return publicationMentionList;
        }
    }

    public class PatentMention
    {
        public string patentId;
        public string patentDate;
        public string patentClaimsCount;

        public static List<PatentMention> getPatentMentionList (XmlNodeList childNodes)
        {
            List<PatentMention> patentMentionList = new List<PatentMention>();
            foreach(XmlNode node in childNodes)
            {
                PatentMention patentMention = new PatentMention();

                patentMention.patentId = node.SelectSingleNode("patentId").InnerText;
                patentMention.patentDate = node.SelectSingleNode("patentDate").InnerText;
                patentMention.patentClaimsCount = node.SelectSingleNode("patentClaimsCount").InnerText;

                patentMentionList.Add(patentMention);
            }

            return patentMentionList;
        }

    }

}