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

            List<Gene> gene_list = extractXml(file);

            foreach (Gene geneItem in gene_list)
            {
                
                foreach (GeneName geneNameItem in geneItem.geneNames)
                {
                    
                    Console.WriteLine("Name: " + geneNameItem.name);

                }

            }

            Methods.createXml(gene_list: gene_list, fileName: "Kaessmann_dt.xml", directory: "data/output/DI2");
            //Methods.createTsv(gene_list: gene_list, fileName: "Kaessmann_dt.tsv", directory: string.Format("{0}/data/input/DI2/", Environment.CurrentDirectory) );

        }

        public static List<Gene> extractXml(FileInfo file) {

            List<Gene> geneList = new List<Gene>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file.FullName);

            int counter = 1;

            XmlNodeList geneNodeList = doc.DocumentElement.SelectNodes("/genes/gene");
            foreach (XmlNode geneNode in geneNodeList)
            {

                Gene gene = new Gene();

                gene.recordId = string.Format("Kaessmann_{0}_rid", counter);

                String ensemblId = (geneNode?.SelectSingleNode("ensemblId").InnerText ?? null);
                gene.ensemblId = ensemblId;

                String ncbiId = (geneNode?.SelectSingleNode("ncbiId").InnerText ?? null);
                gene.ncbiId = ncbiId;

                // geneDescriptions
                List<GeneDescription> geneDescriptionList = new List<GeneDescription>();

                XmlNodeList geneDescriptionXmlNodeList = geneNode.SelectNodes("/geneDescriptions/geneDescriptions");
                foreach (XmlNode geneDescription in geneDescriptionXmlNodeList)
                {

                    GeneDescription geneDescriptionItem = new GeneDescription();
                    String description = (geneDescription?.SelectSingleNode("description").InnerText ?? null);
                    geneDescriptionItem.description = description;

                    geneDescriptionList.Add(geneDescriptionItem);

                }

                gene.geneDescriptions = geneDescriptionList;


                // geneNames
                List<GeneName> geneNameList = new List<GeneName>();
              
                XmlNodeList geneNameXmlNodeList = geneNode.SelectNodes("/geneNames/geneNames");
                foreach (XmlNode geneName in geneNameXmlNodeList)
                {

                    GeneName geneNameItem = new GeneName();
                    String name = (geneName?.SelectSingleNode("name").InnerText ?? null);
                    geneNameItem.name = name;

                    geneNameList.Add(geneNameItem);
            
                }

                gene.geneNames = geneNameList;


                // organs
                List<Organ> organList = new List<Organ>();
    
                XmlNodeList organXmlNodeList = geneNode.SelectNodes("/organs/organs");
                foreach (XmlNode organ in organXmlNodeList)
                {

                    Organ organItem = new Organ();

                    String organName = (organ?.SelectSingleNode("organName").InnerText ?? null);
                    organItem.organName = organName;

                    String disagreement = (organ?.SelectSingleNode("disagreement").InnerText ?? null);
                    organItem.disagreement = disagreement;

                    String probEqualOrthoAdj = (organ?.SelectSingleNode("probEqualOrthoAdj").InnerText ?? null);
                    organItem.probEqualOrthoAdj = probEqualOrthoAdj;

                    String call = (organ?.SelectSingleNode("call").InnerText ?? null);
                    organItem.call = call;

                    organList.Add(organItem);

                }

                gene.organs = organList; 
                

                geneList.Add(gene);

                counter++;
                          
            }

            return geneList;

        }

    }

}