using System;
using System.IO;
using System.Collections.Generic;

namespace EnrichFusedDataset
{
    class Ex1
    {

        public static List<Gene> run (List<Gene> geneList)
        {

            foreach (Gene geneItem in geneList)
            {

                (List<Organ> organList, string overallCall) = organItemsAnalysis(geneItem.organs);

                geneItem.organs = organList;

                geneItem.overallCall = overallCall;
                
            }


            return geneList;
        }

        
        public static (List<Organ>, string) organItemsAnalysis(List<Organ> organList)
        {

            string BrainCall = "N/A";
            string CerebellumCall = "N/A";
            string HeartCall = "N/A";
            string LiverCall = "N/A";
            string KidneyCall = "N/A";
            string TestisCall = "N/A";

            bool BrainExists = false;
            bool CerebellumExists = false;
            bool HeartExists = false;
            bool LiverExists = false;
            bool KidneyExists = false;
            bool TestisExists = false;

            foreach (Organ organItem in organList)
            {
                if (organItem.organName.Equals("brain"))
                {
                    BrainCall = getExpression(organItem.call);
                    organItem.call = BrainCall;

                    BrainExists = true;
                }
                else if (organItem.organName.Equals("cerebellum"))
                {
                    CerebellumCall = getExpression(organItem.call);
                    organItem.call = CerebellumCall;

                    CerebellumExists = true;
                }
                else if (organItem.organName.Equals("heart"))
                {
                    HeartCall = getExpression(organItem.call);
                    organItem.call = HeartCall;

                    HeartExists = true;
                }
                else if (organItem.organName.Equals("liver"))
                {
                    LiverCall = getExpression(organItem.call);
                    organItem.call = LiverCall;

                    LiverExists = true;
                }
                else if (organItem.organName.Equals("kidney"))
                {
                    KidneyCall = getExpression(organItem.call);
                    organItem.call = KidneyCall;

                    KidneyExists = true;
                }
                else if (organItem.organName.Equals("testis"))
                {
                    TestisCall = getExpression(organItem.call);
                    organItem.call = TestisCall;

                    TestisExists = true;
                }
            }
            
            if (BrainExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "brain";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (CerebellumExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "cerebellum";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (HeartExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "heart";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (LiverExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "liver";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (KidneyExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "kidney";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }

            if (TestisExists == false)
            {
                Organ newOrganItem = new Organ();
                newOrganItem.organName = "testis";
                newOrganItem.call = "N/A";
                organList.Add(newOrganItem);
            }
            
            List<string> expressionList = new List<string>();
            expressionList.Add(BrainCall);
            expressionList.Add(CerebellumCall);
            expressionList.Add(HeartCall);
            expressionList.Add(LiverCall);
            expressionList.Add(KidneyCall);
            expressionList.Add(TestisCall);

            return (organList, getOverallExpression(expressionList));
        }

        public static string getExpression(string input)
        {

            string returnValue = "N/A";
            if (input.Equals("Different"))
            {
                returnValue = "0";
            }
            else if (input.Equals("Same"))
            {
                returnValue = "1";
            }

            return returnValue;

        }

        public static string getOverallExpression(List<string> expressionList)
        {
            string returnValue = string.Empty;
            
            bool contains1 = false;
            bool contains0 = false;

            
            foreach (string expression in expressionList)
            {
                if (expression.Equals("0"))
                {
                    contains0 = true;
                }
                else if (expression.Equals("1"))
                {
                    contains1 = true;
                }
            }

            if (contains0 == true)
            {
                if (contains1 == true)
                {
                    returnValue = "N/A";
                }            
            }

            if (contains0 == true)
            {
                if (contains1 == false)
                {
                    returnValue = "0";
                }         
            }

            if (contains0 == false)
            {
                if (contains1 == true)
                {
                   returnValue = "1"; 
                }            
            }

            return returnValue;
        }

    }

}