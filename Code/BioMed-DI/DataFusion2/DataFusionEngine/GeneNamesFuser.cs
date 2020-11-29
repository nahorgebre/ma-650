using System;
using System.Linq;
using System.Collections.Generic;

namespace DataFusion2
{
    
    class GeneNamesFuser
    {

        public static XMLElement fuse(List<XMLElement> geneNameList)
        {

            return DataFusionEngine.fuseRecordAttributes(geneNameList);

        }

    }

}