using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTranslation
{  
    public class TargetSchema2
    {

        public static void createTargetSchema()
        {
            List<Gene> geneList = new List<Gene>();

            geneList.Add(gene1());
            geneList.Add(gene2());
            geneList.Add(gene3());

            Methods.createXml(gene_list: geneList, fileName: "TargetSchema.xml", directory: "data/output");
        }

        public static Gene gene1() {
            
            Gene gene = new Gene();
    	    gene.recordId = "test1";
            gene.ensemblId = "test1";
            gene.ncbiId = "test1";

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = "test1";
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

            List<GeneDescription> geneDescriptionList = new List<GeneDescription>();
            GeneDescription geneDescription = new GeneDescription();
            geneDescription.description = "test1";
            geneDescriptionList.Add(geneDescription);
            gene.geneDescriptions = geneDescriptionList;

            List<Organ> organList = new List<Organ>();
            Organ organ = new Organ();
            organ.organName = "test1";
            organ.call = "test1";
            organ.disagreement = "test1";
            organ.probEqualOrthoAdj = "test1";
            organList.Add(organ);
            gene.organs = organList;

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            DiseaseAssociation diseaseAssociation = new DiseaseAssociation();
            diseaseAssociation.diseaseIdUMLS = "test1";
            diseaseAssociation.diseaseName = "test1";
            diseaseAssociation.diseaseSpecificityIndex = "test1";
            diseaseAssociation.diseasePleiotropyIndex = "test1";
            diseaseAssociation.diseaseTypeDisGeNET = "test1";
            diseaseAssociation.diseaseClassMeSH = "test1";
            diseaseAssociation.diseaseSemanticTypeUMLS = "test1";
            diseaseAssociation.associationScore = "test1";
            diseaseAssociation.evidenceIndex = "test1";
            diseaseAssociation.yearInitialReport = "test1";
            diseaseAssociation.yearFinalReport = "test1";
            diseaseAssociation.pmId = "test1";
            diseaseAssociation.source = "test1";
            diseaseAssociationList.Add(diseaseAssociation);
            gene.diseaseAssociations = diseaseAssociationList;
            
            List<PatentMention> patentMentionList = new List<PatentMention>();
            PatentMention patentMention = new PatentMention();
            patentMention.patentId = "test1";
            patentMention.patentClaimsCount = "test1";
            patentMention.patentDate = "test1";
            patentMentionList.Add(patentMention);
            gene.patentMentions = patentMentionList;

            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            PublicationMention publicationMention = new PublicationMention();
            publicationMention.pmid = "test1";
            publicationMention.ressource = "test1";
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            return gene;
        }

        public static Gene gene2() {
            
            Gene gene = new Gene();
    	    gene.recordId = "test2";
            gene.ensemblId = "test2";
            gene.ncbiId = "test2";

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = "test2";
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

            List<GeneDescription> geneDescriptionList = new List<GeneDescription>();
            GeneDescription geneDescription = new GeneDescription();
            geneDescription.description = "test2";
            geneDescriptionList.Add(geneDescription);
            gene.geneDescriptions = geneDescriptionList;

            List<Organ> organList = new List<Organ>();
            Organ organ = new Organ();
            organ.organName = "test2";
            organ.call = "test2";
            organ.disagreement = "test2";
            organ.probEqualOrthoAdj = "test2";
            organList.Add(organ);
            gene.organs = organList;

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            DiseaseAssociation diseaseAssociation = new DiseaseAssociation();
            diseaseAssociation.diseaseIdUMLS = "test2";
            diseaseAssociation.diseaseName = "test2";
            diseaseAssociation.diseaseSpecificityIndex = "test2";
            diseaseAssociation.diseasePleiotropyIndex = "test2";
            diseaseAssociation.diseaseTypeDisGeNET = "test2";
            diseaseAssociation.diseaseClassMeSH = "test2";
            diseaseAssociation.diseaseSemanticTypeUMLS = "test2";
            diseaseAssociation.associationScore = "test2";
            diseaseAssociation.evidenceIndex = "test2";
            diseaseAssociation.yearInitialReport = "test2";
            diseaseAssociation.yearFinalReport = "test2";
            diseaseAssociation.pmId = "test2";
            diseaseAssociation.source = "test2";
            diseaseAssociationList.Add(diseaseAssociation);
            gene.diseaseAssociations = diseaseAssociationList;
            
            List<PatentMention> patentMentionList = new List<PatentMention>();
            PatentMention patentMention = new PatentMention();
            patentMention.patentId = "test2";
            patentMention.patentClaimsCount = "test2";
            patentMention.patentDate = "test2";
            patentMentionList.Add(patentMention);
            gene.patentMentions = patentMentionList;

            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            PublicationMention publicationMention = new PublicationMention();
            publicationMention.pmid = "test2";
            publicationMention.ressource = "test2";
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            return gene;
        }

        public static Gene gene3() {
            
            Gene gene = new Gene();
    	    gene.recordId = "test3";
            gene.ensemblId = "test3";
            gene.ncbiId = "test3";

            List<GeneName> geneNameList = new List<GeneName>();
            GeneName GeneName = new GeneName();
            GeneName.name = "test3";
            geneNameList.Add(GeneName);
            gene.geneNames = geneNameList;

            List<GeneDescription> geneDescriptionList = new List<GeneDescription>();
            GeneDescription geneDescription = new GeneDescription();
            geneDescription.description = "test3";
            geneDescriptionList.Add(geneDescription);
            gene.geneDescriptions = geneDescriptionList;

            List<Organ> organList = new List<Organ>();
            Organ organ = new Organ();
            organ.organName = "test3";
            organ.call = "test3";
            organ.disagreement = "test3";
            organ.probEqualOrthoAdj = "test3";
            organList.Add(organ);
            gene.organs = organList;

            List<DiseaseAssociation> diseaseAssociationList = new List<DiseaseAssociation>();
            DiseaseAssociation diseaseAssociation = new DiseaseAssociation();
            diseaseAssociation.diseaseIdUMLS = "test3";
            diseaseAssociation.diseaseName = "test3";
            diseaseAssociation.diseaseSpecificityIndex = "test3";
            diseaseAssociation.diseasePleiotropyIndex = "test3";
            diseaseAssociation.diseaseTypeDisGeNET = "test3";
            diseaseAssociation.diseaseClassMeSH = "test3";
            diseaseAssociation.diseaseSemanticTypeUMLS = "test3";
            diseaseAssociation.associationScore = "test3";
            diseaseAssociation.evidenceIndex = "test3";
            diseaseAssociation.yearInitialReport = "test3";
            diseaseAssociation.yearFinalReport = "test3";
            diseaseAssociation.pmId = "test3";
            diseaseAssociation.source = "test3";
            diseaseAssociationList.Add(diseaseAssociation);
            gene.diseaseAssociations = diseaseAssociationList;
            
            List<PatentMention> patentMentionList = new List<PatentMention>();
            PatentMention patentMention = new PatentMention();
            patentMention.patentId = "test3";
            patentMention.patentClaimsCount = "test3";
            patentMention.patentDate = "test3";
            patentMentionList.Add(patentMention);
            gene.patentMentions = patentMentionList;

            List<PublicationMention> publicationMentionList = new List<PublicationMention>();
            PublicationMention publicationMention = new PublicationMention();
            publicationMention.pmid = "test3";
            publicationMention.ressource = "test3";
            publicationMentionList.Add(publicationMention);
            gene.publicationMentions = publicationMentionList;

            return gene;
        }

    }

}
