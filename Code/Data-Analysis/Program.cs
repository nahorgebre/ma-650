using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnrichFusedDataset
{

    class Program
    {

        static void Main(string[] args)
        {

            Exercise2.run();

            /*

            foreach (String parameter in args)
            {

                if (parameter.Equals("stat"))
                {
                    
                    PatentTextMiningStatistics.run();

                    DiseaseAssociationStatistics.run();

                }

            }

            EnrichDataset.run();

            DiseaseAssociationsAnalysis.run();

            */

            //PatentAnalysis.run();

            //AIM_TimeDependentOutput.run();

            //AIM_PatentingActivity.run();

            //ExTab2.run();


        }

    }

}