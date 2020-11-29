using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataFusion2
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

        public ensemblId ensemblId = new ensemblId();

        public ncbiId ncbiId = new ncbiId();

        public geneNames geneNames = new geneNames();

        public geneDescriptions geneDescriptions = new geneDescriptions();

        
        [XmlArrayItem("organ")]
        [XmlAttribute("id")]
        public List<Organ> organs = new List<Organ>();


        [XmlArrayItem("diseaseAssociation")]
        public List<GeneDiseaseAssociation> diseaseAssociations = new List<GeneDiseaseAssociation>();


        [XmlArrayItem("publicationMention")]
        public List<GenePublicationMention> publicationMentions = new List<GenePublicationMention>();


        [XmlArrayItem("patentMention")]
        public List<GenePatentMention> patentMentions = new List<GenePatentMention>();

    }


    public class ensemblId
    {

        [XmlAttribute]
        public string provenance;

        [XmlText]
        public string value;

    }


    public class ncbiId
    {

        [XmlAttribute]
        public string provenance;

        [XmlText]
        public string value;

    }


    public class geneNames
    {

        [XmlAttribute]
        public string provenance;

        [XmlText]
        public string value;

    }


    public class geneDescriptions
    {

        [XmlAttribute]
        public string provenance;

        [XmlText]
        public string value;

    }


    public class Organ
    {

        [XmlAttribute]
        public string provenance;
        
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

        public string patentClaimsCount;

    }


}