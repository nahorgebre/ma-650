using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataTranslation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            DI1.runDataTranslation();
            
            DI2.runDataTranslation();

            //GeneDiseaseAssociations.runDataTranslation();

            AWSupload.run();

            /*
            for (int i = 36; i <= 100; i++)
            {
                string listElement = "List<Gene> gene_list_" + i + " = new List<Gene>();";

                string elseIfElement = "else if (counter <= partitionSize * " + i + ")" + Environment.NewLine + 
                                        "{" + Environment.NewLine + 
                                        "gene.recordId = string.Format(\"gene2pubtatorcentral_{0}_{1}_rid\", " + i + ".ToString(), counter);" + Environment.NewLine + 
                                        "gene_list_" + i + ".Add(gene);" + Environment.NewLine + 
                                        "}";

                string saveElement = "Methods.createXml(gene_list: gene_list_" + i + ", fileName: \"gene2pubtatorcentral_" + i + "_dt.xml\", directory: gene2PubtatorcentralOutputDirectory);" + Environment.NewLine + 
                                        "Methods.createTsv(gene_list: gene_list_" + i + ", fileName: \"gene2pubtatorcentral_" + i + "_dt.tsv\", directory: gene2PubtatorcentralOutputDirectory);" + Environment.NewLine;

                Console.WriteLine(saveElement);
            }
            */
        }
 
        public static void createEmptyTargetSchema()
        {
            List<Gene> geneList = new List<Gene>();

            Gene gene = new Gene();
    	    gene.recordId = string.Empty;
            gene.ensemblId = string.Empty;
            gene.ncbiId = string.Empty;

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = string.Empty;
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

            List<GeneDescription> geneDescriptionList = new List<GeneDescription>();
            GeneDescription geneDescription = new GeneDescription();
            geneDescription.description = string.Empty;
            geneDescriptionList.Add(geneDescription);
            gene.geneDescriptions = geneDescriptionList;

            List<Organ> organList = new List<Organ>();
            Organ organ = new Organ();
            organ.organName = string.Empty;
            organ.call = string.Empty;
            organ.disagreement = string.Empty;
            organ.probEqualOrthoAdj = string.Empty;
            organList.Add(organ);
            gene.organs = organList;

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            DiseaseAssociation diseaseAssociation = new DiseaseAssociation();
            diseaseAssociation.diseaseIdUMLS = string.Empty;
            diseaseAssociation.diseaseName = string.Empty;
            diseaseAssociation.diseaseSpecificityIndex = string.Empty;
            diseaseAssociation.diseasePleiotropyIndex = string.Empty;
            diseaseAssociation.diseaseTypeDisGeNET = string.Empty;
            diseaseAssociation.diseaseClassMeSH = string.Empty;
            diseaseAssociation.diseaseSemanticTypeUMLS = string.Empty;
            diseaseAssociation.associationScore = string.Empty;
            diseaseAssociation.evidenceIndex = string.Empty;
            diseaseAssociation.yearInitialReport = string.Empty;
            diseaseAssociation.yearFinalReport = string.Empty;
            diseaseAssociation.pmId = string.Empty;
            diseaseAssociation.source = string.Empty;
            diseaseAssociationList.Add(diseaseAssociation);
            gene.diseaseAssociations = diseaseAssociationList;
            
            List<PatentMention> patentMentionList = new List<PatentMention>();
            PatentMention patentMention = new PatentMention();
            patentMention.patentId = string.Empty;
            patentMention.patentClaimsCount = string.Empty;
            patentMention.patentDate = string.Empty;
            patentMentionList.Add(patentMention);
            gene.patentMentions = patentMentionList;

            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            PublicationMention publicationMention = new PublicationMention();
            publicationMention.pmId = string.Empty;
            publicationMention.ressource = string.Empty;
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            geneList.Add(gene);

            Methods.createXml(gene_list: geneList, fileName: "TargetSchema.xml", directory: "data/output");
        }

    }
}