using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace CovertXmlCsv
{
    class Program
    {
      
        static void Main(string[] args)
        {
            createCsv(@"\data\fused-heart.xml", "fused-heart.csv");
            createCsv(@"\data\fused-brain.xml", "fused-brain.csv");
            createCsv(@"\data\fused-cerebellum.xml", "fused-cerebellum.csv");
            createCsv(@"\data\fused-kidney.xml", "fused-kidney.csv");
            createCsv(@"\data\fused-liver.xml", "fused-liver.csv");
            createCsv(@"\data\fused-testis.xml", "fused-testis.csv");            
        }

        public static void createCsv(string sourcePath, string fileName)
        {
            var csv = new StringBuilder();

            List<string> firstLine = new List<string>();
            firstLine.Add("geneId");
            firstLine.Add("geneName");
            firstLine.Add("geneDescription");
            firstLine.Add("disagreement");
            firstLine.Add("call");
            firstLine.Add("ncbiId");
            firstLine.Add("dsi");
            firstLine.Add("dpi");
            firstLine.Add("diseaseId");
            firstLine.Add("diseaseName");
            firstLine.Add("diseaseType");
            firstLine.Add("diseaseClass");
            firstLine.Add("diseaseSemanticType");
            firstLine.Add("score");
            firstLine.Add("ei");
            firstLine.Add("yearInitial");
            firstLine.Add("yearFinal");
            firstLine.Add("pmid");
            firstLine.Add("source");

            csv.AppendLine(getLine(firstLine));

            List<Gene> glist = getGenes(getProjectDirectory() + sourcePath);

            foreach (Gene g in glist)
            {
                foreach (Disease d in g.diseases)
                {
                    List<string> recordLine = new List<string>();
                    recordLine.Add(g.geneId);
                    recordLine.Add(g.geneName);
                    recordLine.Add(g.geneDescription);
                    recordLine.Add(g.disagreement);
                    recordLine.Add(g.call);
                    recordLine.Add(g.ncbiId);
                    recordLine.Add(g.dsi);
                    recordLine.Add(g.dpi);
                    recordLine.Add(d.diseaseId);
                    recordLine.Add(d.diseaseName);
                    recordLine.Add(d.diseaseType);
                    recordLine.Add(d.diseaseClass);
                    recordLine.Add(d.diseaseSemanticType);
                    recordLine.Add(d.score);
                    recordLine.Add(d.ei);
                    recordLine.Add(d.yearInitial);
                    recordLine.Add(d.yearFinal);
                    recordLine.Add(d.pmid);
                    recordLine.Add(d.source);

                    csv.AppendLine(getLine(recordLine));
                }
            }
            File.WriteAllText(fileName, csv.ToString());
        }

        public static string getLine(List<string> list)
        {
            string line = "";
            foreach(String item in list)
            {
                if(!item.Equals(list[list.Count-1]))
                {
                    line = String.Concat(line, item.Replace(",", ";").Replace("\"", "") + ",");
                } else
                {
                    line = String.Concat(line, item.Replace(",", ";").Replace("\"", ""));
                }
            }
            return line;
        }

        public static List<Gene> getGenes(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/genes/gene");

            List<Gene> glist = new List<Gene>();

            foreach (XmlNode node in nodes)
            {
                Gene g = new Gene();
                g.geneId = node.SelectSingleNode("geneId").InnerText;
                g.geneName = node.SelectSingleNode("geneName").InnerText;
                g.geneDescription = node.SelectSingleNode("geneDescription").InnerText;
                g.disagreement = node.SelectSingleNode("disagreement").InnerText;
                g.call = node.SelectSingleNode("call").InnerText;
                g.ncbiId = node.SelectSingleNode("ncbiId").InnerText;
                g.dsi = node.SelectSingleNode("dsi").InnerText;
                g.dpi = node.SelectSingleNode("dpi").InnerText;
                g.diseases = getDiseases(node.SelectSingleNode("diseases").ChildNodes);
                glist.Add(g);
            }

            return glist;
        }

        public static List<Disease> getDiseases(XmlNodeList childNodes)
        {
            List<Disease> dlist = new List<Disease>();
            foreach(XmlNode node in childNodes)
            {
                Disease d = new Disease();
                d.diseaseId = node.SelectSingleNode("diseaseId").InnerText;
                d.diseaseName = node.SelectSingleNode("diseaseName").InnerText;
                d.diseaseType = node.SelectSingleNode("diseaseType").InnerText;
                d.diseaseClass = node.SelectSingleNode("diseaseClass").InnerText;
                d.diseaseSemanticType = node.SelectSingleNode("diseaseSemanticType").InnerText;
                d.score = node.SelectSingleNode("score").InnerText;
                d.ei = node.SelectSingleNode("ei").InnerText;
                d.yearInitial = node.SelectSingleNode("yearInitial").InnerText;
                d.yearFinal = node.SelectSingleNode("yearFinal").InnerText;
                d.pmid = node.SelectSingleNode("pmid").InnerText;
                d.source = node.SelectSingleNode("source").InnerText;                
                dlist.Add(d);
            }

            return dlist;
        }

        public static string getProjectDirectory()
        {
            string path = System.Environment.CurrentDirectory.Substring(0, System.Environment.CurrentDirectory.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }
    }
}
