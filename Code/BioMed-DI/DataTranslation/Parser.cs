using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class Parser
    {

        public static List<Organ> parseOrgan(String xml)
        {

            List<Organ> organList = new List<Organ>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/organs/organ");

            foreach (XmlNode node in NodeList)
            {

                Organ organItem = new Organ();

                if(checkIfNodeExist(node, "organName"))
                {

                    organItem.organName = (node?.SelectSingleNode("organName").InnerText ?? null);

                }

                if(checkIfNodeExist(node, "disagreement"))
                {

                    organItem.disagreement = (node?.SelectSingleNode("disagreement").InnerText ?? null);

                }

                if(checkIfNodeExist(node, "probEqualOrthoAdj"))
                {

                    organItem.probEqualOrthoAdj = (node?.SelectSingleNode("probEqualOrthoAdj").InnerText ?? null);

                }

                if(checkIfNodeExist(node, "call"))
                {

                    organItem.call = (node?.SelectSingleNode("call").InnerText ?? null);

                }

                organList.Add(organItem);

            }
            
            return organList;

        }

        public static List<DiseaseAssociation> parseDiseaseAssociation(String xml)
        {

            List<Organ> diseaseAssociationList = new List<Organ>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/organs/organ");

            foreach (XmlNode node in NodeList)
            {
            
            }
        }

        public static List<GenePublicationMention> parsePublicationMention(String xml)
        {

        }

        public static List<GenePatentMention> parsePatentMention(String xml)
        {
            
        }

        public static bool checkIfNodeExist(XmlNode node, String xpath)
        {

            bool status = true;

            var langNode = node.SelectSingleNode(xpath);

            if(langNode==null)
            {

                status = false;

            }

            return status;

        }

    }

}