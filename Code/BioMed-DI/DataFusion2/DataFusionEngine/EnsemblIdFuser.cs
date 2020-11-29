using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion2
{

    class EnsemblIdFuser
    {

        public static XMLElement fuse(List<XMLElement> ensemblIdList)
        {

            return DataFusionEngine.fuseRecordAttributes(ensemblIdList);

        }

    }

}