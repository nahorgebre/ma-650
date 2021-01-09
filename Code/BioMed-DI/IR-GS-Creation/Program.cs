using System;
using System.IO;

namespace IR_GS_Creation
{

    class Program
    {

        static void Main(string[] args)
        {

            AWSlistingContents.getS3ObjectList("DI1");

            AWSlistingContents.getS3ObjectList("DI2");

            AWSlistingContents.getS3ObjectList("DI3");


            foreach (String parameter in args)
            {

                if (parameter.Equals("DI1"))
                {
                    
                    DI1.run("Heart_2_Brain", DI1Datasets.Heart_dt, DI1Datasets.Brain_dt);
                    
                    DI1.run("Heart_2_Cerebellum", DI1Datasets.Heart_dt, DI1Datasets.Cerebellum_dt);
                    
                    DI1.run("Heart_2_Kidney", DI1Datasets.Heart_dt, DI1Datasets.Kidney_dt);
                    
                    DI1.run("Heart_2_Liver", DI1Datasets.Heart_dt, DI1Datasets.Liver_dt);
                    
                    DI1.run("Heart_2_Testis", DI1Datasets.Heart_dt, DI1Datasets.Testis_dt);
                    
                    DI1.run("Heart_2_Heart_Ensembl_NCBI_Crosswalk", DI1Datasets.Heart_dt, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
                    
                    DI1.run("mart_export_heart_2_Heart_Ensembl_NCBI_Crosswalk", DI1Datasets.mart_export_heart_dt, DI1Datasets.Heart_Ensembl_NCBI_Crosswalk_dt);
                    
                    DI1.run("Cerebellum_2_Brain", DI1Datasets.Cerebellum_dt, DI1Datasets.Brain_dt);
                    
                    DI1.run("Cerebellum_2_Kidney", DI1Datasets.Cerebellum_dt, DI1Datasets.Kidney_dt);
                    
                    DI1.run("Cerebellum_2_Liver", DI1Datasets.Cerebellum_dt, DI1Datasets.Liver_dt);
                    
                    DI1.run("Cerebellum_2_Testis", DI1Datasets.Cerebellum_dt, DI1Datasets.Testis_dt);
                    
                    DI1.run("Cerebellum_2_mart_export_cerebellum", DI1Datasets.Cerebellum_dt, DI1Datasets.mart_export_cerebellum_dt);
                    
                    DI1.run("Brain_2_Kidney", DI1Datasets.Brain_dt, DI1Datasets.Kidney_dt);
                    
                    DI1.run("Brain_2_Liver", DI1Datasets.Brain_dt, DI1Datasets.Liver_dt);
                    
                    DI1.run("Brain_2_Testis", DI1Datasets.Brain_dt, DI1Datasets.Testis_dt);
                    
                    DI1.run("Brain_2_mart_export_brain", DI1Datasets.Brain_dt, DI1Datasets.mart_export_brain_dt);

                    DI1.run("Kidney_2_Liver", DI1Datasets.Kidney_dt, DI1Datasets.Liver_dt);
                    
                    DI1.run("Kidney_2_Testis", DI1Datasets.Kidney_dt, DI1Datasets.Testis_dt);
                    
                    DI1.run("Kidney_2_mart_export_kidney", DI1Datasets.Kidney_dt, DI1Datasets.mart_export_kidney_dt);

                    DI1.run("Testis_2_Liver", DI1Datasets.Testis_dt, DI1Datasets.Liver_dt);
                    
                    DI1.run("Liver_2_mart_export_liver", DI1Datasets.Liver_dt, DI1Datasets.mart_export_liver_dt);
                    
                    DI1.run("Testis_2_mart_export_testis", DI1Datasets.Testis_dt, DI1Datasets.mart_export_testis_dt);

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                }
                else if (parameter.Equals("DI2"))
                {

                    DI2.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                } 
                else if (parameter.Equals("DI3"))
                {

                    DI3.run();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    Output.createOutputWithCornerCases(outputDirectory);

                    AWSupload.run(outputDirectory, parameter);

                }
                else if (parameter.Equals("DI4"))
                {

                    //DI4.runAbstract();

                    DI4.runTitle();

                    DirectoryInfo outputDirectory = new DirectoryInfo(string.Format("{0}/data/output/{1}", Environment.CurrentDirectory, parameter));

                    AWSupload.run(outputDirectory, parameter);

                }

            }

        }

    }

}