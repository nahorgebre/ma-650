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
        public string recordId = string.Empty;
        public string geneId = string.Empty;
        public string geneName = string.Empty;
        public string geneDescription = string.Empty;
        public string disagreement = string.Empty;
        public string call = string.Empty;
        public string ncbiId = string.Empty;

        [XmlArrayAttribute("associatedDiseases")]
        public List<AssociatedDisease> associatedDiseases;

        [XmlArrayAttribute("publicationMentions")]
        public List<PublicationMention> publicationMentions;

        [XmlArrayAttribute("patentMentions")]
        public List<PatentMention> patentMentions;
    }

    [XmlType("associatedDisease")]
    public class AssociatedDisease
    {
        public string diseaseIdUMLS = string.Empty;
        public string diseaseName = string.Empty;
        public string diseaseSpecificityIndex = string.Empty;
        public string diseasePleiotropyIndex = string.Empty;
        public string diseaseTypeDisGeNET = string.Empty;
        public string diseaseClassMeSH = string.Empty;
        public string diseaseSemanticTypeUMLS = string.Empty;
        public string associationScore = string.Empty;
        public string evidenceIndex = string.Empty;
        public string yearInitialReport = string.Empty;
        public string yearFinalReport = string.Empty;
        public string pmid = string.Empty;
        public string source = string.Empty;
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
    }
}
