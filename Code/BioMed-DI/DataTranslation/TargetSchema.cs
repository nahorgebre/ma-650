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

        public string ensemblId = string.Empty;

        public string ncbiId = string.Empty;

        public string geneNames = string.Empty;

        public string geneDescriptions = string.Empty;

        
        [XmlArrayItem("organs")]
        public List<Organ> organs = new List<Organ>();


        [XmlArrayAttribute("diseaseAssociations")]
        public List<DiseaseAssociation> diseaseAssociations = new List<DiseaseAssociation>();


        [XmlArrayAttribute("publicationMentions")]
        public List<GenePublicationMention> publicationMentions = new List<GenePublicationMention>();


        [XmlArrayAttribute("patentMentions")]
        public List<GenePatentMention> patentMentions = new List<GenePatentMention>();

    }


    [XmlType("organ")]
    public class Organ
    {

        public string organName;

        public string disagreement;

        public string probEqualOrthoAdj;

        public string call;  

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
    public class GenePublicationMention
    {

        public string pmId;

        public string ressource;

        public string year;

    }


    [XmlType("patentMention")]
    public class GenePatentMention
    {

        public string patentId;

        public string patentDate;

        public string patentClaimsCount;

    }

}