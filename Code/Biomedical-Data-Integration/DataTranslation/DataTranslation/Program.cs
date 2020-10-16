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

            /*
            Heart.runDataTranslation();
            Brain.runDataTranslation();
            Cerebellum.runDataTranslation();
            Kidney.runDataTranslation();
            Liver.runDataTranslation();
            Testis.runDataTranslation();
            GeneDiseaseAssociations.runDataTranslation();
            */

            Publication.runDataTranslation();
            AWSupload.run();
            
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