using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTranslation
{  
    [XmlRoot("genes")]
    public class Genes
    {
        [XmlElement("gene")]
        public List<Gene> gene;

        public static void createTargetSchema()
        {
            List<Gene> geneList = new List<Gene>();

            Gene gene = new Gene();
    	    gene.recordId = string.Empty;
            gene.ensemblId = string.Empty;
            gene.ncbiId = string.Empty;

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = string.Empty;
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

            List<GeneDescription> geneDescriptionList = new List<GeneDescription>();
            GeneDescription geneDescription = new GeneDescription();
            geneDescription.description = string.Empty;
            geneDescriptionList.Add(geneDescription);
            gene.geneDescriptions = geneDescriptionList;

            List<Organ> organList = new List<Organ>();
            Organ organ = new Organ();
            organ.organName = string.Empty;
            organ.call = string.Empty;
            organ.disagreement = string.Empty;
            organ.probEqualOrthoAdj = string.Empty;
            organList.Add(organ);
            gene.organs = organList;

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            DiseaseAssociation diseaseAssociation = new DiseaseAssociation();
            diseaseAssociation.diseaseIdUMLS = string.Empty;
            diseaseAssociation.diseaseName = string.Empty;
            diseaseAssociation.diseaseSpecificityIndex = string.Empty;
            diseaseAssociation.diseasePleiotropyIndex = string.Empty;
            diseaseAssociation.diseaseTypeDisGeNET = string.Empty;
            diseaseAssociation.diseaseClassMeSH = string.Empty;
            diseaseAssociation.diseaseSemanticTypeUMLS = string.Empty;
            diseaseAssociation.associationScore = string.Empty;
            diseaseAssociation.evidenceIndex = string.Empty;
            diseaseAssociation.yearInitialReport = string.Empty;
            diseaseAssociation.yearFinalReport = string.Empty;
            diseaseAssociation.pmId = string.Empty;
            diseaseAssociation.source = string.Empty;
            diseaseAssociationList.Add(diseaseAssociation);
            gene.diseaseAssociations = diseaseAssociationList;
            
            List<PatentMention> patentMentionList = new List<PatentMention>();
            PatentMention patentMention = new PatentMention();
            patentMention.patentId = string.Empty;
            patentMention.patentClaimsCount = string.Empty;
            patentMention.patentDate = string.Empty;
            patentMentionList.Add(patentMention);
            gene.patentMentions = patentMentionList;

            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            PublicationMention publicationMention = new PublicationMention();
            publicationMention.pmid = string.Empty;
            publicationMention.ressource = string.Empty;
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            geneList.Add(gene);

            Methods.createXml(gene_list: geneList, fileName: "TargetSchema.xml", directory: "data/output");
        }

    }

    public class Gene
    {
        public string recordId;
        public string ensemblId;
        public string ncbiId;

        [XmlArrayItem("geneNames")]
        public List<GeneName> geneNames;

        [XmlArrayItem("geneDescriptions")]
        public List<GeneDescription> geneDescriptions;

        [XmlArrayItem("organs")]
        public List<Organ> organs;

        [XmlArrayAttribute("diseaseAssociations")]
        public List<DiseaseAssociation> diseaseAssociations;

        [XmlArrayAttribute("publicationMentions")]
        public List<PublicationMention> publicationMentions;

        [XmlArrayAttribute("patentMentions")]
        public List<PatentMention> patentMentions;
    }

    [XmlType("organ")]
    public class Organ
    {
        public string organName;
        public string disagreement;
        public string probEqualOrthoAdj;
        public string call;  
    }

    [XmlType("geneName")]
    public class GeneName 
    {
        public string name;
    }

    [XmlType("geneDescription")]
    public class GeneDescription
    {
        public string description;
    }

    [XmlType("diseaseAssociation")]
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
    }

    [XmlType("publicationMention")]
    public class PublicationMention
    {
        public string pmid;
        public string ressource;
        public string year;
    }

    [XmlType("patentMention")]
    public class PatentMention
    {
        public string patentId;
        public string patentDate;
        public string patentClaimsCount;
    }
}
