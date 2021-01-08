using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion
{

    class NcbiIdFuser
    {

        public static XMLElement fuse(List<XMLElement> ncbiIdList)
        {

            return DataFusionEngine.fuseRecordAttributes(ncbiIdList);

        }

    }

}