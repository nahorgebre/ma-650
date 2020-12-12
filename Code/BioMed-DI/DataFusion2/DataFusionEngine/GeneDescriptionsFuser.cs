using System;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{
    class GeneDescriptionsFuser
    {

        public static XMLElement fuse(List<XMLElement> geneDescriptionsList)
        {

            return DataFusionEngine.fuseRecordAttributes(geneDescriptionsList);

        }

    }

}