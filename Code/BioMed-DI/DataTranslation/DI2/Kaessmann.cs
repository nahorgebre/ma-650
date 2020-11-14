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

            //List<Gene> gene_list = parseXml(file, "Kaessmann_{0}_rid");

            List<Gene> gene_list = Parser.parseGene(file, "Kaessmann_{0}_rid");

            Methods.createXmlGene(gene_list: gene_list, fileName: "Kaessmann_dt.xml", directory: "data/output/DI2");
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

                    // ncbiId
                    String ncbiId = string.Empty;
                    reader.ReadToFollowing("ncbiId");
                    ncbiId = reader.ReadElementContentAsString();
                    gene.ncbiId = ncbiId;

                    // geneDescriptions
                    String geneDescriptions = string.Empty;
                    reader.ReadToFollowing("geneDescriptions");
                    geneDescriptions = reader.ReadElementContentAsString();
                    gene.geneDescriptions = geneDescriptions;

                    // geneNames
                    String geneNames = string.Empty;
                    reader.ReadToFollowing("geneNames");
                    geneNames = reader.ReadElementContentAsString();
                    gene.geneNames = geneNames;

                    // organs
                    reader.ReadToFollowing("organs"); 
                    XmlReader organsInner = reader.ReadSubtree();
                    while (organsInner.Read())
                    {

                        String xml = "<organs>" + organsInner.ReadInnerXml() + "</organs>";

                        List<Organ> organList = Parser.parseOrgan(xml);

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

    }

}