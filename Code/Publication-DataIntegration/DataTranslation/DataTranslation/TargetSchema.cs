using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTranslation
{  
    [XmlRoot("publications")]
    public class Publications
    {
        [XmlElement("publication")]
        public List<Publication> publication;
    }

    public class Publication
    {
        public string id = string.Empty;
        public string pmid = string.Empty;
        [XmlArrayAttribute("genes")]
        public List<Gene> genes;
        [XmlArrayAttribute("projects")]
        public List<Project> projects;
    }

    [XmlType("project")]
    public class Project
    {
        public string projectId = string.Empty;
    }

    [XmlType("gene")]
    public class Gene
    {
        public string ncbiId = string.Empty;
        [XmlElement("geneNames")]
        public List<GeneName> geneNames;
    }

    public class GeneName
    {
        public string geneName = string.Empty;
    }
}
