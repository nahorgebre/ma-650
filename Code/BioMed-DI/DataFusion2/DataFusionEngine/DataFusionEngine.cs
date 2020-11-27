using System;
using System.Collections.Generic;

namespace DataFusion2
{
    class DataFusionEngine
    {

        public static Dictionary<string, string> getKeyDictionary(List<Tuple<string, string>> correspondences)
        {

            Dictionary<string, SortedSet<string>> keyDictionaryCollection = new Dictionary<string, SortedSet<string>>();

            foreach (Tuple<string, string> correspondenceItem in correspondences)
            {
                
                string recordId1 = correspondenceItem.Item1;

                string recordId2 = correspondenceItem.Item2;

                
                if (keyDictionaryCollection.ContainsKey(recordId1))
                {
                    
                    SortedSet<string> recordIdCollection = keyDictionaryCollection[recordId1];

                    recordIdCollection.Add(recordId1);
                    
                    recordIdCollection.Add(recordId2);

                    keyDictionaryCollection[recordId1] = recordIdCollection;

                }
                else
                {

                    SortedSet<string> recordIdCollection = new SortedSet<string>();

                    recordIdCollection.Add(recordId1);

                    recordIdCollection.Add(recordId2);

                    keyDictionaryCollection.Add(recordId1, recordIdCollection);

                }


                if (keyDictionaryCollection.ContainsKey(recordId2))
                {

                    SortedSet<string> recordIdCollection = keyDictionaryCollection[recordId2];
                    
                    recordIdCollection.Add(recordId1);

                    recordIdCollection.Add(recordId2);

                    keyDictionaryCollection[recordId2] = recordIdCollection;
                    
                }
                else
                {

                    SortedSet<string> recordIdCollection = new SortedSet<string>();

                    recordIdCollection.Add(recordId1);

                    recordIdCollection.Add(recordId2);

                    keyDictionaryCollection.Add(recordId2, recordIdCollection);

                }


            }

            Dictionary<string, string> keyDictionaryString = new Dictionary<string, string>();

            foreach(KeyValuePair<string, SortedSet<string>> entry in keyDictionaryCollection)
            {

                string key = entry.Key;

                var line = string.Join('+', entry.Value);

                keyDictionaryString.Add(key, line);

            }

            return keyDictionaryString;

        }


        public static Dictionary<string, HashSet<Gene>> getUnfusedRecords(Dictionary<string, Gene> datasets, Dictionary<string, string> keyDictionary)
        {

            Dictionary<string, HashSet<Gene>> unfusedRecords = new Dictionary<string, HashSet<Gene>>();

            foreach(KeyValuePair<string, Gene> entry in datasets)
            {

                string datasetRecordId = entry.Key;

                Gene datasetGene = entry.Value;
                

                if (keyDictionary.ContainsKey(datasetRecordId))
                {

                    string fusedRecordId = keyDictionary[datasetRecordId];
                    
                    if (unfusedRecords.ContainsKey(fusedRecordId))
                    {

                        HashSet<Gene> geneHashSet = unfusedRecords[fusedRecordId];

                        geneHashSet.Add(datasetGene);

                        unfusedRecords[fusedRecordId] = geneHashSet;
                        
                    }
                    else
                    {

                        HashSet<Gene> geneHashSet = new HashSet<Gene>();

                        unfusedRecords.Add(fusedRecordId, geneHashSet);

                    }

                }

            }

            return unfusedRecords;

        }


        public static List<Gene> fuseRecords(Dictionary<string, HashSet<Gene>> unfusedRecords) {

            List<Gene> fusedRecords = new List<Gene>();

            foreach (KeyValuePair<string, HashSet<Gene>> item in unfusedRecords)
            {

                string recordId = item.Key;

                HashSet<Gene> geneHashSet = item.Value;

                
                Gene newGene = new Gene();

                newGene.recordId = recordId;


                List<string> ensemblIdList = new List<string>();

                List<string> ncbiIdList = new List<string>();

                List<string> geneNameList = new List<string>();

                List<string> geneDescriptionList = new List<string>();

                List<Organ> organList = new List<Organ>();

                List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();

                List<GenePublicationMention> publicationMentionList = new List<GenePublicationMention>();

                List<GenePatentMention> patentMentionList = new List<GenePatentMention>();


                foreach (Gene gene in geneHashSet)
                {
                    
                    string ensemblId = gene.ensemblId;

                    Console.WriteLine("Ensembl Id: " + ensemblId);

                    ensemblIdList.Add(ensemblId);


                    string ncbiId = gene.ncbiId;

                    Console.WriteLine("Ncbi Id: " + ncbiId);

                    ncbiIdList.Add(gene.ncbiId);


                    string geneNames = gene.geneNames;

                    Console.WriteLine("Gene Names: " + geneNames);

                    geneNameList.Add(gene.geneNames);


                    string geneDescriptions = gene.geneDescriptions;

                    Console.WriteLine("Gene Descriptions: " + geneDescriptions);

                    geneDescriptionList.Add(geneDescriptions);
                    

                    organList.AddRange(gene.organs);

                    diseaseAssociationList.AddRange(gene.diseaseAssociations);

                    publicationMentionList.AddRange(gene.publicationMentions);

                    patentMentionList.AddRange(gene.patentMentions);

                }


                newGene.ensemblId = EnsemblIdFuser.fuse(ensemblIdList);

                newGene.ncbiId = NcbiIdFuser.fuse(ncbiIdList);

                newGene.geneNames = GeneNamesFuser.fuse(geneNameList);

                newGene.geneDescriptions = GeneDescriptionsFuser.fuse(geneDescriptionList);

                newGene.organs = organList;

                newGene.diseaseAssociations = diseaseAssociationList;

                newGene.publicationMentions = publicationMentionList;

                newGene.patentMentions = patentMentionList;


                fusedRecords.Add(newGene);
                
            }

            return fusedRecords;

        }
    
    }

}