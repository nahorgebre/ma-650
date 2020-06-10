using DataTranslation;
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
        dataTranslationPublicationMentions();
    }

    public static void dataTranslationHeart() {
        Directory.CreateDirectory("Heart");
        heartMethods.Heart_dt();     
        heartMethods.mart_export_heart_dt();
        heartMethods.Heart_Ensembl_NCBI_Crosswalk_dt();
    }

    public static void dataTranslationBrain() {
        Directory.CreateDirectory("Brain");
        brainMethods.Brain_dt();
        brainMethods.mart_export_brain_dt();
    }

    public static void dataTranslationCerebellum() {
        Directory.CreateDirectory("Cerebellum");
        cerebellumMethods.Cerebellum_dt();
        cerebellumMethods.mart_export_cerebellum_dt();
    }

    public static void dataTranslationKidney() {
        Directory.CreateDirectory("Kidney");
        kidneyMethods.Kidney_dt();
        kidneyMethods.mart_export_kidney_dt();
    }

    public static void dataTranslationLiver() {
        Directory.CreateDirectory("Liver");
        liverMetods.Liver_dt();
        liverMetods.mart_export_liver_dt();
    }

    public static void dataTranslationTestis() {
        Directory.CreateDirectory("Testis");
        testisMethods.Testis_dt();
        testisMethods.mart_export_testis_dt();
    }

    public static void dataTranslationGeneDiseaseAssociations()
    {
        Directory.CreateDirectory("Gene-Disease-Associations");
        geneDiseaseAssociationsMethods.all_gene_disease_pmid_associations_dt();
    }

    public static void dataTranslationPublicationMentions()
    {
        Directory.CreateDirectory("Publication-Mentions");
        publicationMentionsMethods.publicationMentions_dt();
    }
}