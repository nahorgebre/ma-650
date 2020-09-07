using System.Collections.Generic;

namespace Goldstandard
{
    class Goldstandard
    {
        public string dataset1_id;
        public string dataset2_id;
        public string value;
    }

    public class Gene
    {
        public string recordId;
        public string ensemblId;
        public List<string> geneNameList;
        public string ncbiId;
    }

    public class PubMedPublication
    {
        public string id = string.Empty;
        public string pmid = string.Empty;
    }
}
