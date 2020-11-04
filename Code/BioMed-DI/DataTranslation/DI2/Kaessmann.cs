using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace DataTranslation
{

    public class Kaessmann
    {

        public static void runDataTranslation()
        {

            FileInfo file = new FileInfo(string.Format("{0}/data/input/DI2/kaessmann-fused.xml", Environment.CurrentDirectory));

            List<Gene> gene_list = parseXml(file, "Kaessmann_{0}_rid");

            Methods.createXml(gene_list: gene_list, fileName: "Kaessmann_dt.xml", directory: "data/output/DI2");
            Methods.createTsv(gene_list: gene_list, fileName: "Kaessmann_dt.tsv", directory: "data/output/DI2");

        }

        public static List<Gene> parseXml(FileInfo file, String recordIdPattern)
        {

            List<Gene> geneList = new List<Gene>();

            int counter = 1;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;

            using (XmlReader reader = XmlReader.Create(file.FullName, settings))
            {
                while (reader.ReadToFollowing("gene"))
                {

                    Gene gene = new Gene();

                    gene.recordId = string.Format("Kaessmann_{0}_rid", counter);     

                    // ensemblId
                    String ensemblId = string.Empty;
                    reader.ReadToFollowing("ensemblId");
                    ensemblId = reader.ReadElementContentAsString();

                    gene.ensemblId = ensemblId;

                    Console.WriteLine("Ensembl Id: " + gene.ensemblId);


                    // ncbiId
                    String ncbiId = string.Empty;
                    reader.ReadToFollowing("ncbiId");
                    ncbiId = reader.ReadElementContentAsString();

                    gene.ncbiId = ncbiId;


                    // geneDescriptions
                    reader.ReadToFollowing("geneDescriptions"); 
                    XmlReader geneDescriptionsInner = reader.ReadSubtree();
                    while (geneDescriptionsInner.Read())
                    {
                    }


                    // geneNames
                    reader.ReadToFollowing("geneNames"); 
                    XmlReader geneNamesInner = reader.ReadSubtree();
                    while (geneNamesInner.Read())
                    {

                        String xml = "<geneNames>" + geneNamesInner.ReadInnerXml() + "</geneNames>";

                        List<GeneName> geneNameList = parseGeneName(xml);

                        gene.geneNames = string.Join("|", geneNameList);

                    }


                    // organs
                    reader.ReadToFollowing("organs"); 
                    XmlReader organsInner = reader.ReadSubtree();
                    while (organsInner.Read())
                    {

                        String xml = "<organs>" + organsInner.ReadInnerXml() + "</organs>";

                        List<Organ> organList = parseOrgan(xml);

                        gene.organs = organList;
                        
                    }
                    

                    // publicationMentions
                    reader.ReadToFollowing("publicationMentions"); 
                    XmlReader publicationMentionsInner = reader.ReadSubtree();
                    while (publicationMentionsInner.Read())
                    {
                    }

                    // patentMentions
                    reader.ReadToFollowing("patentMentions"); 
                    XmlReader patentMentionsInner = reader.ReadSubtree();
                    while (patentMentionsInner.Read())
                    {
                    }

                    // diseaseAssociations
                    reader.ReadToFollowing("diseaseAssociations"); 
                    XmlReader diseaseAssociationsInner = reader.ReadSubtree();
                    while (diseaseAssociationsInner.Read())
                    {
                    }

                    geneList.Add(gene);

                    counter++;

                }

            }

            return geneList;

        }

        public static List<GeneName> parseGeneName(String xml)
        {

            List<GeneName> geneNameList = new List<GeneName>();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xml);

            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("/geneNames/geneName");

            foreach (XmlNode node in NodeList)
            {

                GeneName geneName = new GeneName();

                if(checkIfNodeExist(node, "name"))
                {

                    geneName.name = (node?.SelectSingleNode("name").InnerText ?? null);

                }

                geneNameList.Add(geneName);

            }

            return geneNameList;

        }

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