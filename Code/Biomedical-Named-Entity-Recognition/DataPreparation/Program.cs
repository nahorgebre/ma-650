namespace Data_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
           TargetPatentNumber.getPatentNumbersByYear();

           CreateTrainTextDatasets.run();
           CreateTestTextDatasets.run();
        }

    }
}
