using DataTranslation;
using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        dataTranslationHeart();
        dataTranslationBrain();
        dataTranslationCerebellum();
        dataTranslationKidney();
        dataTranslationLiver();
        dataTranslationTestis();
        dataTranslationGeneDiseaseAssociations();
        //dataTranslationPublicationMentions();
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