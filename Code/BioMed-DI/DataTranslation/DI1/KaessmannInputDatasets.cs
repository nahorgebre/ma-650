using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{

    class KaessmannInputDatasets
    {

        public static Dictionary<string, KaessmannContent> getKaessmannDictionary()
        {

            Dictionary<string, KaessmannContent> kaessmannDictionary = new Dictionary<string, KaessmannContent>();

            // Brain.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Brain.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];

                    string disagreement = values[1];

                    string probEqualOrthoAdj = values[2];

                    string call = values[3];


                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.brain_call = call;
                        kaessmann.brain_probEqualOrthoAdj = probEqualOrthoAdj;
                        kaessmann.brain_disagreement = disagreement;
                        kaessmann.ensemblId = ensemblId;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent() { 
                            ensemblId = ensemblId, 
                            brain_disagreement = disagreement, 
                            brain_probEqualOrthoAdj = probEqualOrthoAdj, 
                            brain_call = call });

                    }

                }

            }

            // mart_export_brain.txt           
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_brain.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneDescriptions = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );
                    string geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Cerebellum.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Cerebellum.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string disagreement = values[1];
                    string probEqualOrthoAdj = values[2];
                    string call = values[3];


                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.cerebellum_call = call;
                        kaessmann.cerebellum_probEqualOrthoAdj = probEqualOrthoAdj;
                        kaessmann.cerebellum_disagreement = disagreement;
                        kaessmann.ensemblId = ensemblId;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent() { 
                            ensemblId = ensemblId, 
                            cerebellum_disagreement = disagreement, 
                            cerebellum_probEqualOrthoAdj = probEqualOrthoAdj, 
                            cerebellum_call = call });

                    }

                }

            }

            // mart_export_cerebellum.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_cerebellum.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneDescriptions = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );
                    string geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Heart.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Heart.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string disagreement = values[1];

                    string call = values[2];

                    
                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.heart_call = call;
                        kaessmann.heart_disagreement = disagreement;
                        kaessmann.ensemblId = ensemblId;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId, 
                            heart_disagreement = disagreement, 
                            heart_call = call });

                    }

                }

            }

            // mart_export_heart.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_heart.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneDescriptions = line.Substring(line.LastIndexOf(",") + 1);
                    string geneNames = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Heart_Ensembl_NCBI_Crosswalk.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/Heart_Ensembl_NCBI_Crosswalk.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ncbiId = values[0];
                    string ensemblId = values[1];
                    string geneNames = values[2];

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.ncbiId = ncbiId;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            ncbiId = ncbiId,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Kidney.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Kidney.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string disagreement = values[1];
                    string probEqualOrthoAdj = values[2];
                    string call = values[3];


                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.kidney_call = call;
                        kaessmann.kidney_probEqualOrthoAdj = probEqualOrthoAdj;
                        kaessmann.kidney_disagreement = disagreement;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId, 
                            kidney_disagreement = disagreement, 
                            kidney_probEqualOrthoAdj = probEqualOrthoAdj, 
                            kidney_call = call });

                    }

                }

            }

            // mart_export_kidney.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_kidney.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneDescriptions = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );
                    string geneNames = line.Substring(line.LastIndexOf(",") + 1);

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Liver.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Liver.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string disagreement = values[1];
                    string probEqualOrthoAdj = values[2];
                    string call = values[3];


                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.liver_call = call;
                        kaessmann.liver_probEqualOrthoAdj = probEqualOrthoAdj;
                        kaessmann.liver_disagreement = disagreement;
                        kaessmann.ensemblId = ensemblId;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId, 
                            liver_disagreement = disagreement, 
                            liver_probEqualOrthoAdj = probEqualOrthoAdj, 
                            liver_call = call });

                    }

                }

            }

            // mart_export_liver.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_liver.txt"))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneNames = line.Substring(line.LastIndexOf(",") + 1);
                    string geneDescriptions = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            // Testis.csv
            using (var reader = new StreamReader(DI1.inputDirectory + "/Testis.csv"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string disagreement = values[1];
                    string probEqualOrthoAdj = values[2];
                    string call = values[3];


                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];

                        kaessmann.testis_call = call;
                        kaessmann.testis_probEqualOrthoAdj = probEqualOrthoAdj;
                        kaessmann.testis_disagreement = disagreement;
                        kaessmann.ensemblId = ensemblId;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId, 
                            testis_disagreement = disagreement, 
                            testis_probEqualOrthoAdj = probEqualOrthoAdj, 
                            testis_call = call });

                    }

                }

            }

            // mart_export_testis.txt
            using (var reader = new StreamReader(DI1.inputDirectory + "/mart_export_testis.txt"))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    String[] values = line.Split(',');

                    string ensemblId = values[0];
                    string geneNames = line.Substring(line.LastIndexOf(",") + 1);
                    //string geneDescriptions = (line.Substring(line.IndexOf(",") + 1)).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(","));
                    string geneDescriptions = ( line.Substring(line.IndexOf(",") + 1) ).Substring(0, line.Substring(line.IndexOf(",") + 1).LastIndexOf(",") );

                    if (kaessmannDictionary.ContainsKey(ensemblId))
                    {

                        KaessmannContent kaessmann = kaessmannDictionary[ensemblId];
                        kaessmann.geneDescriptions = geneDescriptions;
                        kaessmann.geneNames = geneNames;

                        kaessmannDictionary[ensemblId] = kaessmann;

                    }
                    else
                    {

                        kaessmannDictionary.Add(ensemblId, new KaessmannContent(){ 
                            ensemblId = ensemblId,
                            geneDescriptions = geneDescriptions,
                            geneNames = geneNames
                        });

                    }

                }

            }

            return kaessmannDictionary;

        }

    }

}