using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTranslation
{  
    [XmlRoot("genes")]
    public class Genes
    {
        [XmlElement("gene")]
        public List<Gene> gene;
    }

    public class Gene
    {
        public string recordId;
        public string ensemblId;

        [XmlArrayItem("geneNames")]
        public List<GeneName> geneNames;

        public string geneDescription;
        public string disagreement;
        public string probEqualOrthoAdj;
        public string call;
        public string ncbiId;

        [XmlArrayAttribute("diseaseAssociations")]
        public List<DiseaseAssociation> diseaseAssociations;

        [XmlArrayAttribute("publicationMentions")]
        public List<PublicationMention> publicationMentions;

        [XmlArrayAttribute("patentMentions")]
        public List<PatentMention> patentMentions;
    }

    [XmlType("geneName")]
    public class GeneName 
    {
        public string name;
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
        public string pmid = string.Empty;
        public string ressource = string.Empty;
    }

    [XmlType("patentMention")]
    public class PatentMention
    {
        public string patentId = string.Empty;
        public string patentDate = string.Empty;
        public string patentClaimsCount	= string.Empty;
    }
}
