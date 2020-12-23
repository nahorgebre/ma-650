using System.Collections.Generic;
using System.Xml.Serialization;

namespace EnrichFusedDataset
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

        public string overallCall = string.Empty;

        public string overallDiseaseAssociation = string.Empty;

        public string firstPublicationYear = string.Empty;

        public string frequencyPatent = string.Empty;

        public string frequencyPatentTitle = string.Empty;

        public string frequencyPatentAbstract = string.Empty;

        public string frequencyPatentDescription = string.Empty;

        public string frequencyPatentClaims = string.Empty;

        
        [XmlArrayItem("organ")]
        public List<Organ> organs = new List<Organ>();


        [XmlArrayItem("diseaseAssociation")]
        public List<GeneDiseaseAssociation> diseaseAssociations = new List<GeneDiseaseAssociation>();


        [XmlArrayItem("publicationMention")]
        public List<GenePublicationMention> publicationMentions = new List<GenePublicationMention>();


        [XmlArrayItem("patentMention")]
        public List<GenePatentMention> patentMentions = new List<GenePatentMention>();

    }


    public class Organ
    {

        public string organName;

        public string disagreement;

        public string probEqualOrthoAdj;

        public string call;  

    }


    public class GeneDiseaseAssociation
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


    public class GenePublicationMention
    {

        public string pmId;

        public string ressource;

        public string year;

    }


    public class GenePatentMention
    {

        public string patentId;

        public string patentDate;

        public string patentChapter;

        public string patentClaimsCount;

    }


}