using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFusion
{

    class OrganFuser
    {

        public static List<Organ> fuse(List<Organ> organList)
        {

            List<Organ> newOrganList = new List<Organ>();

            foreach (Organ organ in organList)
            {

                //organ.provenance = "test";

                newOrganList.Add(organ);
                
            }

            return newOrganList;

        }

    }

}