using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PrepareGoldStandard
{

    class FlairDataPreparation
    {

        public static FileInfo inputAbstractTestText = new FileInfo(Environment.CurrentDirectory + "/data/output/test_abstract.txt");

        public static FileInfo inputAbstractTestEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/test_entity_abstract.txt");

        public static FileInfo inputAbstractTrainText = new FileInfo(Environment.CurrentDirectory + "/data/output/train_abstract.txt");

        public static FileInfo inputAbstractTrainEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_abstract.txt");


        public static FileInfo inputTitleTestText = new FileInfo(Environment.CurrentDirectory + "/data/output/test_title.txt");

        public static FileInfo inputTitleTestEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/");

        public static FileInfo inputTitleTrainText = new FileInfo(Environment.CurrentDirectory + "/data/output/train_title.txt");

        public static FileInfo inputTitleTrainEntity = new FileInfo(Environment.CurrentDirectory + "/data/output/train_entity_title.txt");


        public static FileInfo outputTitleTrainFlair = new FileInfo(Environment.CurrentDirectory + "/data/output/trainFlairTitle.txt");

        public static FileInfo outputAbstractTrainFlair = new FileInfo(Environment.CurrentDirectory + "/data/output/trainFlairTitle.txt");

        public static void run()
        {

            Dictionary<string, TextAnnotation> trainTitle = getDictionaryAnnotation(text: inputTitleTrainText, entity: inputTitleTrainEntity);

            Dictionary<string, TextAnnotation> trainAbstarct = getDictionaryAnnotation(text: inputAbstractTrainText, entity: inputAbstractTrainEntity);

            cerateOutput(outputTitleTrainFlair, trainTitle);

            cerateOutput(outputAbstractTrainFlair, trainAbstarct);

        }

        public static void cerateOutput(FileInfo file, Dictionary<string, TextAnnotation> dictionary)
        {

            foreach (KeyValuePair<string, TextAnnotation> dictionaryItem in dictionary)
            {
                
            }

        }

        public static string removeWhiteSpaces(string text)
        {

            RegexOptions options = RegexOptions.None;

            Regex regex = new Regex("[ ]{2,}", options);  

            return regex.Replace(text, " ");

        }

        public static Dictionary<string, TextAnnotation> getDictionaryAnnotation(FileInfo text, FileInfo entity)
        {

            Dictionary<string, TextAnnotation> dictionaryAnnotation = new Dictionary<string, TextAnnotation>();

            using (StreamReader sr = new StreamReader(text.FullName))
            {

                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    dictionaryAnnotation.Add(values[0], new TextAnnotation(){ text = values[1] });

                }
                
            }

            using (StreamReader sr = new StreamReader(entity.FullName))
            {
                
                while (!sr.EndOfStream)
                {

                    var line = sr.ReadLine();

                    string[] values = line.Split('\t');

                    if (dictionaryAnnotation.ContainsKey(values[0]))
                    {

                        // get text annotation
                        TextAnnotation textAnnotation = dictionaryAnnotation[values[0]];

                        // get gene mention
                        List<GeneMention> geneMentionList = textAnnotation.geneMentionList;

                        // adjsut gene mention
                        geneMentionList.Add(new GeneMention(){ geneName = values[4], startIndex = values[2], endIndex = values[3] });

                        // return gene mention
                        textAnnotation.geneMentionList = geneMentionList;

                        // return text annotation
                        dictionaryAnnotation[values[0]] = textAnnotation;

                    }
                    
                }

            }

            return dictionaryAnnotation;

        }

    }

    class TextAnnotation
    {
        public string text;

        public List<GeneMention> geneMentionList = new List<GeneMention>();

    }

    class GeneMention
    {

        public string geneName;

        public string startIndex;

        public string endIndex;

    }

}