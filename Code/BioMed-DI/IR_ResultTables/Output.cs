using System;
using System.IO;
using System.Collections.Generic;

namespace IR_ResultTables
{

    class Output
    {

        public static void createTeXFileResult1_2(List<Result1> result1List, FileInfo outputFile)
        {

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine("\\begin{footnotesize}");

                sw.WriteLine(@"\begin{longtable}{l|l|l|l|l|l|l}");

                sw.WriteLine(@"\caption{Blocking Evaluation - " + outputFile.Directory.Name + @"\label{tab:blocking" + outputFile.Directory.Name + @"}}\\");

                //sw.WriteLine(@"\hline");

                sw.WriteLine("\\textbf{Datasets} & \\textbf{\\vtop{\\hbox{\\strut Matching}\\hbox{\\strut Rule}}} & \\textbf{Blocker} & \\textbf{\\vtop{\\hbox{\\strut Blocked}\\hbox{\\strut Pairs}}} & \\textbf{\\vtop{\\hbox{\\strut Reduction}\\hbox{\\strut Ratio}}} & \\textbf{Time} & \\textbf{\\vtop{\\hbox{\\strut Correspon-}\\hbox{\\strut dences}}} \\\\");

                sw.WriteLine(@"\hline");

                sw.WriteLine(@"\endhead");

                //sw.WriteLine(@"\hline");

                sw.WriteLine(@"\endfoot");

                foreach (Result1 result1Item in result1List)
                {

                    sw.WriteLine(result1Item.Datasets + " & " + result1Item.MatchingRule + " & " + result1Item.BlockingAlgorithm + " & " + result1Item.BlockedPairs + " & " + result1Item.ReductionRatio + " & " + result1Item.RunTime + " & " + result1Item.Correspondences + " \\\\" + " \\hline");
                             
                }

                sw.WriteLine(@"\end{longtable}");

                sw.WriteLine("\\end{footnotesize}");

            }

        }

        public static void createTeXFileResult1(List<Result1> result1List, FileInfo outputFile)
        {

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine("\\begin{table}[!ht]");

                sw.WriteLine("\\centering");

                sw.WriteLine("\\setlength\\extrarowheight{2pt}");

                sw.WriteLine("\\begin{footnotesize}");

                sw.WriteLine("\\begin{tabularx}{\\textwidth}{|l|l|l|l|l|l|l|}");

                sw.WriteLine("\\hline");

                sw.WriteLine("\\textbf{Datasets} & \\textbf{\\vtop{\\hbox{\\strut Matching}\\hbox{\\strut Rule}}} & \\textbf{Blocking Algorithm} & \\textbf{\\vtop{\\hbox{\\strut Blocked}\\hbox{\\strut Pairs}}} & \\textbf{\\vtop{\\hbox{\\strut Reduction}\\hbox{\\strut Ratio}}} & \\textbf{Run Time} & \\textbf{\\vtop{\\hbox{\\strut Correspon-}\\hbox{\\strut dences}}} \\\\");

            

                sw.WriteLine("\\hline");

                foreach (Result1 result1Item in result1List)
                {

                    sw.WriteLine(result1Item.Datasets + " & " + result1Item.MatchingRule + " & " + result1Item.BlockingAlgorithm + " & " + result1Item.BlockedPairs + " & " + result1Item.ReductionRatio + " & " + result1Item.RunTime + " & " + result1Item.Correspondences + " \\\\" + " \\hline");
                             
                }

                sw.WriteLine("\\hline");

                sw.WriteLine("\\end{tabularx}");

                sw.WriteLine("\\end{footnotesize}");

                sw.WriteLine("\\caption{Identity Resolution Evaluation Measures}");

                sw.WriteLine("\\end{table}");
            
            }

        }

        public static void createTsvFileResult1(List<Result1> result1List, FileInfo outputFile)
        {

            outputFile.Directory.Create();

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                var delimiter = "\t";

                List<string> firstLineContent = new List<string>()
                {

                    "Datasets",

                    "Matching Rule",

                    "Blocking Algorithm",

                    "Blocked Pairs",

                    "Reduction Ratio",

                    "Run Time",

                    "Correspondences"
                    
                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Result1 result1Item in result1List)
                {

                    List<string> lineContent = new List<string>()
                    {

                        result1Item.Datasets,

                        result1Item.MatchingRule,

                        result1Item.BlockingAlgorithm,

                        result1Item.BlockedPairs,

                        result1Item.ReductionRatio,

                        result1Item.RunTime,

                        result1Item.Correspondences

                    };

                    var line = string.Join(delimiter, lineContent);

                    sw.WriteLine(line);
         
                }

            }

        }

        public static void createTeXFileResult2_1(List<Result2> result2List, FileInfo outputFile)
        {

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine("\\begin{footnotesize}");

                sw.WriteLine(@"\begin{longtable}{l|l|l|l|l|l|l|l}");

                sw.WriteLine(@"\caption{Matching Rule Evaluation - " + outputFile.Directory.Name + @"\label{tab:matching" + outputFile.Directory.Name + @"}}\\");

                //sw.WriteLine(@"\hline");

                sw.WriteLine("\\textbf{Datasets} & \\textbf{\\vtop{\\hbox{\\strut Matching}\\hbox{\\strut Rule}}} & \\textbf{Blocker} & \\textbf{Precision} & \\textbf{Recall} & \\textbf{F1} & \\textbf{Time} & \\textbf{\\vtop{\\hbox{\\strut Correspon-}\\hbox{\\strut dences}}} \\\\");

                sw.WriteLine(@"\hline");

                sw.WriteLine(@"\endhead");

                //sw.WriteLine(@"\hline");

                sw.WriteLine(@"\endfoot");

                foreach (Result2 result2Item in result2List)
                {

                    sw.WriteLine(result2Item.Datasets + " & " + result2Item.MatchingRule + " & " + result2Item.Blocker + " & " + result2Item.Precision + " & " +  result2Item.Recall + " & " + result2Item.F1 + " & " + result2Item.Time + " & " + result2Item.Correspondences + " \\\\" + " \\hline");
                             
                }

                sw.WriteLine(@"\end{longtable}");

                sw.WriteLine("\\end{footnotesize}");

            }

        }

        public static void createTeXFileResult2(List<Result2> result2List, FileInfo outputFile)
        {

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                sw.WriteLine("\\begin{table}[!ht]");

                sw.WriteLine("\\centering");

                sw.WriteLine("\\setlength\\extrarowheight{2pt}");

                sw.WriteLine("\\begin{footnotesize}");

                sw.WriteLine("\\begin{tabularx}{\\textwidth}{|l|l|l|l|l|l|l|}");

                sw.WriteLine("\\hline");

                sw.WriteLine("\\textbf{Datasets} & \\textbf{Matching Rule} & \\textbf{Blocker} & \\textbf{Precision} & \\textbf{Recall} & \\textbf{F1} & \\textbf{Correspondences} & \\textbf{Time} & \\\\");

                sw.WriteLine("\\hline");

                foreach (Result2 result2Item in result2List)
                {

                    sw.WriteLine(result2Item.Datasets + " & " + result2Item.MatchingRule + " & " + result2Item.Blocker + " & " + result2Item.Precision + " & " +  result2Item.Recall + " & " + result2Item.F1 + " & " + result2Item.Correspondences + " & " + result2Item.Time + " \\\\" + " \\hline");
                    
                }

                sw.WriteLine("\\hline");

                sw.WriteLine("\\end{tabularx}");

                sw.WriteLine("\\end{footnotesize}");

                sw.WriteLine("\\caption{Identity Resolution Evaluation Measures}");

                sw.WriteLine("\\end{table}");
            
            }

        }

        public static void createTsvFileResult2(List<Result2> result2List, FileInfo outputFile)
        {

            outputFile.Directory.Create();

            using (StreamWriter sw = new StreamWriter(outputFile.FullName))
            {

                var delimiter = "\t";

                List<string> firstLineContent = new List<string>()
                {

                    "Datasets",

                    "Matching Rule",

                    "Blocker",

                    "Precision",

                    "Recall",

                    "F1",

                    "Time",

                    "Correspondences"

                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);

                foreach (Result2 result2Item in result2List)
                {

                    List<string> lineContent = new List<string>()
                    {

                        result2Item.Datasets,

                        result2Item.MatchingRule,

                        result2Item.Blocker,

                        result2Item.Precision,

                        result2Item.Recall,

                        result2Item.F1,

                        result2Item.Time,

                        result2Item.Correspondences

                    };

                    var line = string.Join(delimiter, lineContent);
                    
                    sw.WriteLine(line);
         
                }

            }
            
        }

    }

}