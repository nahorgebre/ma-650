using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PrepareGoldStandard
{

    class Program
    {

        static void Main(string[] args)
        {

            // ---- test

            /*
            string text = "A compound comprising a target cell-specific portion and human NAD(P)H:quinone reductase 2 )NQO2) or a variant or fragment or fusion or derivative thereof which has substantially the same activity as NQO2 towards a given prodrug, or a polynucleotide encoding said NQO2 or said variant or fragment or fusion or derivative. A recombinant polynucleotide comprising a target cell-specific promoter operably linked to a polynucleotide encoding human NAD(P)H:quinone reductase 2 (NQO2) or a variant or fragment or fusion or derivative thereof which has substantially the same activity as NQO2 towards a given prodrug. The compounds and polynucleotides are useful in a method of treating a patient in conjunction with a suitable prodrug. A method of treating a human patient with a target cell to be destroyed wherein the target cell expresses NQO2 the method comprising administering to the patient a prodrug which is converted to a substantially cytotoxic drug by the action of NQO2 and nicotinamide riboside (reduced) (NRH) or an analogue thereof which can pass reducing equivalents to NQO2.";

            List<GeneMention> geneMentionList = new List<GeneMention>();

            GeneMention g1 = new GeneMention() { geneName = "NQO2", startIndex = "92", endIndex = "96" };
            geneMentionList.Add(g1);

            GeneMention g2 = new GeneMention() { geneName = "NQO2", startIndex = "200", endIndex = "204" };
            geneMentionList.Add(g2);

            GeneMention g3 = new GeneMention() { geneName = "human NAD(P)H:quinone reductase 2", startIndex = "57", endIndex = "90" };
            geneMentionList.Add(g3);

            GeneMention g4 = new GeneMention() { geneName = "human NAD(P)H:quinone reductase 2", startIndex = "439", endIndex = "472" };
            geneMentionList.Add(g4);


            Console.WriteLine(addBIOannotations(text, geneMentionList));
            */
            // ----

            /*
                        US6867231	A	1082	1086	NQO2	ABBREVIATION	P16083
            US6867231	A	200	204	NQO2	ABBREVIATION	P16083
            US6867231	A	264	268	NQO2	ABBREVIATION	P16083
            US6867231	A	439	472	human NAD(P)H:quinone reductase 2	FULL_NAME	P16083
            US6867231	A	474	478	NQO2	ABBREVIATION	P16083
            US6867231	A	57	90	human NAD(P)H:quinone reductase 2	FULL_NAME	P16083
            US6867231	A	582	586	NQO2	ABBREVIATION	P16083
            US6867231	A	837	841	NQO2	ABBREVIATION	P16083
            US6867231	A	92	96	NQO2	ABBREVIATION	P16083
            US6867231	A	973	977	NQO2	ABBREVIATION	P16083
            */

            DataPreparation.run();

            FlairDataPreparation.run();

            //AWSupload.run();

        }

    }

}