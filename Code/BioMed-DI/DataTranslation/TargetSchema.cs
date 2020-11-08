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

        public string ncbiId;

        public string geneNames;

        public string geneDescriptions;

        
        [XmlArrayItem("organs")]
        public List<Organ> organs;


        [XmlArrayAttribute("diseaseAssociations")]
        public List<DiseaseAssociation> diseaseAssociations;


        [XmlArrayAttribute("publicationMentions")]
        public List<GenePublicationMention> publicationMentions;


        [XmlArrayAttribute("patentMentions")]
        public List<GenePatentMention> patentMentions;

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


    [XmlRoot("publications")]
    public class Publications
    {

        [XmlElement("publication")]
        public List<Publication> publication;

    }

    public class Publication
    {

        public string recordId;
        
        public string pmId;
        
        public string geneNames;

        public string ncbiId;

        public string ressource;

        public string year;       

    }


    // delete this later
    public class GeneDescription
    {
        public string description;
    }
    public class GeneName 
    {
        public string name;
    }


}