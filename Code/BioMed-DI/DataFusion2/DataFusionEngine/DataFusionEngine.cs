using System;
using System.Collections.Generic;

namespace DataFusion2
{
    class DataFusionEngine
    {

        public static List<Gene> fuseRecords(Dictionary<string, HashSet<string>> keyDictionary, Dictionary<string, Gene> di1datasets)
        {

            List<Gene> fusedRecords = new List<Gene>();

            foreach (KeyValuePair<string, HashSet<string>> dictionaryItem in keyDictionary)
            {

                Gene gene = new Gene();

                gene.recordId = dictionaryItem.Key;

                List<Gene> unfusedGeneItems = new List<Gene>();

                foreach (string dictionaryRecordId in dictionaryItem.Value)
                {

                    Gene di1datasetsGene = di1datasets[dictionaryRecordId];

                    unfusedGeneItems.Add(di1datasetsGene);

                }


                Gene fusedGeneItem = fuseGeneItems(unfusedGeneItems);


                gene.ensemblId = fusedGeneItem.ensemblId;

                gene.ncbiId = fusedGeneItem.ncbiId;

                gene.geneNames = fusedGeneItem.geneNames;

                gene.geneDescriptions = fusedGeneItem.geneDescriptions;

                gene.organs = fusedGeneItem.organs;

                gene.diseaseAssociations = fusedGeneItem.diseaseAssociations;

                gene.publicationMentions = fusedGeneItem.publicationMentions;

                gene.patentMentions = fusedGeneItem.patentMentions;


                fusedRecords.Add(gene);

            }

            return fusedRecords;

        }


        public static Gene fuseGeneItems(List<Gene> unfusedGeneItems)
        {

            Gene fusedGeneItem = new Gene();


            List<XMLElement> unfusedEnsemblIdList = new List<XMLElement>();

            List<XMLElement> unfusedNcbiIdList = new List<XMLElement>();

            List<XMLElement> unfusedGeneNameList = new List<XMLElement>();

            List<XMLElement> unfusedGeneDescriptionList = new List<XMLElement>();

            List<Organ> unfusedOrganList = new List<Organ>();

            List<GeneDiseaseAssociation> unfusedDiseaseAssociationList = new List<GeneDiseaseAssociation>();

            List<GenePublicationMention> unfusedPublicationMentionList = new List<GenePublicationMention>();

            List<GenePatentMention> unfusedPatentMentionList = new List<GenePatentMention>();


            foreach (Gene unfusedGeneItem in unfusedGeneItems)
            {

                // Ensembl ID

                XMLElement ensemblId = new XMLElement();

                ensemblId.value = unfusedGeneItem.ensemblId.value;

                ensemblId.provenance = unfusedGeneItem.recordId;

                unfusedEnsemblIdList.Add(ensemblId);


                // NCBI ID

                XMLElement ncbiId = new XMLElement();

                ncbiId.value = unfusedGeneItem.ncbiId.value;

                ncbiId.provenance = unfusedGeneItem.recordId;

                unfusedNcbiIdList.Add(ncbiId);


                // Gene Name

                XMLElement geneNames = new XMLElement();

                geneNames.value = unfusedGeneItem.geneNames.value;

                geneNames.provenance = unfusedGeneItem.recordId;

                unfusedGeneNameList.Add(geneNames);


                // Gene Description

                XMLElement geneDescriptions = new XMLElement();

                geneDescriptions.value = unfusedGeneItem.geneNames.value;

                geneDescriptions.provenance = unfusedGeneItem.recordId;

                unfusedGeneDescriptionList.Add(geneDescriptions);


                unfusedOrganList.AddRange(unfusedGeneItem.organs);

                unfusedDiseaseAssociationList.AddRange(unfusedGeneItem.diseaseAssociations);

                unfusedPublicationMentionList.AddRange(unfusedGeneItem.publicationMentions);

                unfusedPatentMentionList.AddRange(unfusedGeneItem.patentMentions);

            }



            fusedGeneItem.ensemblId.value = EnsemblIdFuser.fuse(unfusedEnsemblIdList).value;

            fusedGeneItem.ensemblId.provenance = EnsemblIdFuser.fuse(unfusedEnsemblIdList).provenance;


            fusedGeneItem.ncbiId.value = NcbiIdFuser.fuse(unfusedNcbiIdList).value;

            fusedGeneItem.ncbiId.provenance = NcbiIdFuser.fuse(unfusedNcbiIdList).provenance;


            fusedGeneItem.geneNames.value = GeneNamesFuser.fuse(unfusedGeneNameList).value;

            fusedGeneItem.geneNames.provenance = GeneNamesFuser.fuse(unfusedGeneNameList).provenance;


            fusedGeneItem.geneDescriptions.value = GeneDescriptionsFuser.fuse(unfusedGeneDescriptionList).value;

            fusedGeneItem.geneDescriptions.provenance = GeneDescriptionsFuser.fuse(unfusedGeneDescriptionList).provenance;


            fusedGeneItem.organs = OrganFuser.fuse(unfusedOrganList);

            fusedGeneItem.diseaseAssociations = unfusedDiseaseAssociationList;

            fusedGeneItem.publicationMentions = unfusedPublicationMentionList;

            fusedGeneItem.patentMentions = unfusedPatentMentionList;


            return fusedGeneItem;

        }


        public static XMLElement fuseRecordAttributes(List<XMLElement> recordItemList)
        {

            Dictionary<string, HashSet<string>> xmlElementHashSet = new Dictionary<string, HashSet<string>>();

            foreach (XMLElement item in recordItemList)
            {

                if (!string.IsNullOrEmpty(item.value))
                {

                    if (item.value.Contains('|'))
                    {

                        string[] values = item.value.Split('|');

                        foreach (string valueItem in values)
                        {

                            string elementValue = valueItem;

                            string elementProvenance = item.provenance;

                            if (!xmlElementHashSet.ContainsKey(elementValue))
                            {

                                xmlElementHashSet.Add(elementValue, new HashSet<string> { elementProvenance });

                            }
                            else
                            {

                                HashSet<string> elementProvenanceHashSet = xmlElementHashSet[elementValue];

                                elementProvenanceHashSet.Add(elementProvenance);

                                xmlElementHashSet[elementValue] = elementProvenanceHashSet;

                            }

                        }

                    }
                    else
                    {

                        string elementValue = item.value;

                        string elementProvenance = item.provenance;

                        if (!xmlElementHashSet.ContainsKey(elementValue))
                        {

                            xmlElementHashSet.Add(elementValue, new HashSet<string> { elementProvenance });

                        }
                        else
                        {

                            HashSet<string> elementProvenanceHashSet = xmlElementHashSet[elementValue];

                            elementProvenanceHashSet.Add(elementProvenance);

                            xmlElementHashSet[elementValue] = elementProvenanceHashSet;

                        }

                    }

                }

            }


            XMLElement returnValue = new XMLElement();

            returnValue.value = string.Empty;

            returnValue.provenance = string.Empty;

            foreach (KeyValuePair<string, HashSet<string>> item in xmlElementHashSet)
            {

                if (!returnValue.value.Equals(string.Empty))
                {

                    returnValue.value = returnValue.value + '|' + item.Key;

                }
                else
                {

                    returnValue.value = item.Key;

                }

                if (!returnValue.provenance.Equals(string.Empty))
                {

                    returnValue.provenance = returnValue.provenance + "+" + string.Join('+', item.Value);

                }
                else
                {

                    returnValue.provenance = string.Join('+', item.Value);

                }

            }

            return returnValue;

        }

        public static string fuseStringRecordAttributes(List<string> recordItemList)
        {

            string recordItems = string.Join('|', recordItemList);

            HashSet<string> recordItemHashSet = new HashSet<string>();

            foreach (string recordItem in recordItems.Split('|'))
            {

                if (!recordItem.Trim().Equals(string.Empty))
                {

                    string adjustedRecordItem = recordItem;

                    if (recordItem.Contains('|'))
                    {

                        adjustedRecordItem = adjustedRecordItem.Remove('|');

                    }

                    recordItemHashSet.Add(adjustedRecordItem);

                }

            }

            recordItems = string.Join('|', recordItemHashSet);

            return recordItems;

        }

    }

}