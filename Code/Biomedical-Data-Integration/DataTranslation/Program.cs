using DataTranslation;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataTranslation
{
    public class Program
    {
        public static void Main()
        {
            createTargetSchema();
            runDataTranslation();
        }

        public static void createTargetSchema()
        {
            List<Gene> geneList = new List<Gene>();

            Gene gene = new Gene();
    	    gene.recordId = string.Empty;
            gene.ensemblId = string.Empty;
            gene.geneDescription = string.Empty;
            gene.disagreement = string.Empty;
            gene.probEqualOrthoAdj = string.Empty;
            gene.call = string.Empty;
            gene.ncbiId = string.Empty;

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = string.Empty;
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

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
            publicationMention.pmid = string.Empty;
            publicationMention.ressource = string.Empty;
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            geneList.Add(gene);

            Methods.createXml(gene_list: geneList, fileName: "TargetSchema.xml", directory: "data/output");
        }

        public static void runDataTranslation()
        {
            dataTranslationHeart();
            dataTranslationBrain();
            dataTranslationCerebellum();
            dataTranslationKidney();
            dataTranslationLiver();
            dataTranslationTestis();
            dataTranslationGeneDiseaseAssociations();
            dataTranslationPublicationMentions();
            AWSupload.run();
        }

        public static void dataTranslationHeart() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Heart.heartOutputDirectory));  
            Heart.Heart_dt();     
            Heart.mart_export_heart_dt();
            Heart.Heart_Ensembl_NCBI_Crosswalk_dt();
        }

        public static void dataTranslationBrain() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Brain.brainOutputDirectory)); 
            Brain.Brain_dt();
            Brain.mart_export_brain_dt();
        }

        public static void dataTranslationCerebellum() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Cerebellum.cerebellumOutputDirectory)); 
            Cerebellum.Cerebellum_dt();
            Cerebellum.mart_export_cerebellum_dt();
        }

        public static void dataTranslationKidney() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Kidney.kidneyOutputDirectory)); 
            Kidney.Kidney_dt();
            Kidney.mart_export_kidney_dt();
        }

        public static void dataTranslationLiver() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Liver.liverOutputDirectory)); 
            Liver.Liver_dt();
            Liver.mart_export_liver_dt();
        }

        public static void dataTranslationTestis() 
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Testis.testisOutputDirectory)); 
            Testis.Testis_dt();
            Testis.mart_export_testis_dt();
        }

        public static void dataTranslationGeneDiseaseAssociations()
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, GeneDiseaseAssociations.geneDiseaseAssociationsOutputDirectory)); 
            GeneDiseaseAssociations.all_gene_disease_pmid_associations_dt();
        }

        public static void dataTranslationPublicationMentions()
        {
            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, Gene2Pubtatorcentral.gene2PubtatorcentralOutputDirectory)); 
            Gene2Pubtatorcentral.gene2pubtatorcentral_dt();
        }
    }
}