namespace DataTranslation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //createTargetSchema();
            Heart.runDataTranslation();
            Brain.runDataTranslation();
            Cerebellum.runDataTranslation();
            Kidney.runDataTranslation();
            Liver.runDataTranslation();
            Testis.runDataTranslation();
            GeneDiseaseAssociations.runDataTranslation();
            Publication.runDataTranslation();
            AWSupload.run();
        }
    }
}