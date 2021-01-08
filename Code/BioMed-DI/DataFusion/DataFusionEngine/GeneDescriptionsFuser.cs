using System;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion
{
    class GeneDescriptionsFuser
    {

        public static XMLElement fuse(List<XMLElement> geneDescriptionsList)
        {

            return DataFusionEngine.fuseRecordAttributes(geneDescriptionsList);

        }

    }

}