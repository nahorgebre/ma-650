using System;
using System.Collections.Generic;
using System.Text;

namespace CovertXmlCsv
{
    public class Gene
    {
        public string geneId = "";
        public string geneName = "";
        public string geneDescription = "";
        public string disagreement = "";
        public string call = "";
        public string ncbiId = "";
        public string dsi = "";
        public string dpi = "";
        public List<Disease> diseases;
    }

    public class Disease
    {
        public string diseaseId = "";
        public string diseaseName = "";
        public string diseaseType = "";
        public string diseaseClass = "";
        public string diseaseSemanticType = "";
        public string score = "";
        public string ei = "";
        public string yearInitial = "";
        public string yearFinal = "";
        public string pmid = "";
        public string source = "";
    }
}
