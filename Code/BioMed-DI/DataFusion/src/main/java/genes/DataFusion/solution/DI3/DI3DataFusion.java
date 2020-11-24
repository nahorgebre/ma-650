package genes.DataFusion.solution.DI3;

// Winter
import de.uni_mannheim.informatik.dws.winter.datafusion.CorrespondenceSet;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionEngine;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionEvaluator;
import de.uni_mannheim.informatik.dws.winter.datafusion.DataFusionStrategy;
import de.uni_mannheim.informatik.dws.winter.model.DataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleDataSet;
import de.uni_mannheim.informatik.dws.winter.model.FusibleHashedDataSet;
import de.uni_mannheim.informatik.dws.winter.model.RecordGroupFactory;
import de.uni_mannheim.informatik.dws.winter.model.defaultmodel.Attribute;
import de.uni_mannheim.informatik.dws.winter.utils.WinterLogManager;
import genes.DataFusion.model.Gene.Gene;

public class DI3DataFusion {

    //private static final Logger logger = WinterLogManager.activateLogger("trace");

    public static void main( String[] args ) throws Exception {

        // load the data into FusibleDataSet
        System.out.println("*\n*\tLoading datasets\n*");

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_1 = DI3Datasets.gene2pubtatorcentral(1);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_2 = DI3Datasets.gene2pubtatorcentral(2);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_3 = DI3Datasets.gene2pubtatorcentral(3);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_4 = DI3Datasets.gene2pubtatorcentral(4);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_5 = DI3Datasets.gene2pubtatorcentral(5);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_6 = DI3Datasets.gene2pubtatorcentral(6);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_7 = DI3Datasets.gene2pubtatorcentral(7);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_8 = DI3Datasets.gene2pubtatorcentral(8);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_9 = DI3Datasets.gene2pubtatorcentral(9);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_10 = DI3Datasets.gene2pubtatorcentral(10);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_11 = DI3Datasets.gene2pubtatorcentral(11);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_12 = DI3Datasets.gene2pubtatorcentral(12);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_13 = DI3Datasets.gene2pubtatorcentral(13);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_14 = DI3Datasets.gene2pubtatorcentral(14);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_15 = DI3Datasets.gene2pubtatorcentral(15);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_16 = DI3Datasets.gene2pubtatorcentral(16);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_17 = DI3Datasets.gene2pubtatorcentral(17);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_18 = DI3Datasets.gene2pubtatorcentral(18);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_19 = DI3Datasets.gene2pubtatorcentral(19);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_20 = DI3Datasets.gene2pubtatorcentral(20);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_21 = DI3Datasets.gene2pubtatorcentral(21);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_22 = DI3Datasets.gene2pubtatorcentral(22);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_23 = DI3Datasets.gene2pubtatorcentral(23);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_24 = DI3Datasets.gene2pubtatorcentral(24);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_25 = DI3Datasets.gene2pubtatorcentral(25);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_26 = DI3Datasets.gene2pubtatorcentral(26);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_27 = DI3Datasets.gene2pubtatorcentral(27);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_28 = DI3Datasets.gene2pubtatorcentral(28);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_29 = DI3Datasets.gene2pubtatorcentral(29);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_30 = DI3Datasets.gene2pubtatorcentral(30);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_31 = DI3Datasets.gene2pubtatorcentral(31);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_32 = DI3Datasets.gene2pubtatorcentral(32);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_33 = DI3Datasets.gene2pubtatorcentral(33);
        
        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_34 = DI3Datasets.gene2pubtatorcentral(34);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_35 = DI3Datasets.gene2pubtatorcentral(35);
        
        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_36 = DI3Datasets.gene2pubtatorcentral(36);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_37 = DI3Datasets.gene2pubtatorcentral(37);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_38 = DI3Datasets.gene2pubtatorcentral(38);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_39 = DI3Datasets.gene2pubtatorcentral(39);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_40 = DI3Datasets.gene2pubtatorcentral(40);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_41 = DI3Datasets.gene2pubtatorcentral(41);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_42 = DI3Datasets.gene2pubtatorcentral(42);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_43 = DI3Datasets.gene2pubtatorcentral(43);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_44 = DI3Datasets.gene2pubtatorcentral(44);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_45 = DI3Datasets.gene2pubtatorcentral(45);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_46 = DI3Datasets.gene2pubtatorcentral(46);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_47 = DI3Datasets.gene2pubtatorcentral(47);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_48 = DI3Datasets.gene2pubtatorcentral(48);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_49 = DI3Datasets.gene2pubtatorcentral(49);

        FusibleDataSet<Gene, Attribute> gene2pubtatorcentral_50 = DI3Datasets.gene2pubtatorcentral(50);

        System.out.println("All files loaded!");

        

    }
    
}
