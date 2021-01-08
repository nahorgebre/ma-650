using System;
using System.IO;
using System.Collections.Generic;

namespace DataTranslation
{
    public class Test
    {

        public static void runDataTranslation()
        {

            FileInfo testFile = new FileInfo(Environment.CurrentDirectory + "/data/output/test/test.xml");

            List<Gene> gene_list = new List<Gene>(){

            new Gene(){
                recordId = "test",
                ensemblId = "test",
                ncbiId = "test",
                geneNames = "test",
                geneDescriptions = "test",
                overallCall = "test",
                overallDiseaseAssociation = "test",
                firstPublicationYear = "test",
                frequencyPatent = "test",
                frequencyPatentTitle = "test",
                frequencyPatentAbstract = "test",
                frequencyPatentDescription = "test",
                frequencyPatentClaims = "test",

                organs = new List<Organ>(){
                    new Organ(){
                        organName = "test",
                        disagreement = "test",
                        probEqualOrthoAdj = "test",
                        call = "test"
                    }
                },

                diseaseAssociations = new List<GeneDiseaseAssociation>(){
                    new GeneDiseaseAssociation(){
                        diseaseIdUMLS = "test",
                        diseaseName = "test",
                        diseaseSpecificityIndex = "test",
                        diseasePleiotropyIndex = "test",
                        diseaseTypeDisGeNET = "test",
                        diseaseClassMeSH = "test",
                        diseaseSemanticTypeUMLS = "test",
                        associationScore = "test",
                        evidenceIndex = "test",
                        yearInitialReport = "test",
                        yearFinalReport = "test",
                        pmId = "test",
                        source = "test",
                        associatedNcbiId = "test"
                    }
                },

                publicationMentions = new List<GenePublicationMention>(){
                    new GenePublicationMention(){
                        pmId = "test",
                        ressource = "test",
                        year = "test",
                        associatedNcbiId = "test",
                        associatedOrgan = "test"
                    }
                },

                patentMentions = new List<GenePatentMention>(){
                    new GenePatentMention(){
                        patentId = "test",
                        patentDate = "test",
                        patentChapter = "test",
                        patentClaimsCount = "test"
                    }
                }

            }

            };

            Output.createXml(gene_list, testFile);

        }

    }

}