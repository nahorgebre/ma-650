using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractPatentData
{
    class StringPreprocessing
    {

        public static string run(string text)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            text = checkIfStringIsEmpty(text);
            text = removeNewLineChar(text);
            text = removeWhiteSpaces(text);
            text = addPunctuation(text);

            watch.Stop();
            //Console.WriteLine("StringPreprocessing.run() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return text;
        }

        public static string addPunctuation(string text)
        {
            if (!text.Substring(text.Length - 1).Equals("."))
            {
                text = string.Format("{0}.", text);
            }
            return text;
        }

        public static string checkIfStringIsEmpty(string text)
        {
            if (text.Equals(string.Empty))
            {
                return "NaN";
            } 
            else
            {
                return text;
            }
        }

        public static string removeWhiteSpaces(string text)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            text = regex.Replace(text, " ");

            watch.Stop();
            //Console.WriteLine("StringPreprocessing.removeWhiteSpaces() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return text;
        }

        public static string removeNewLineChar(string text)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            text = text.Replace("\n", " ").Replace("\r", " ");

            watch.Stop();
            //Console.WriteLine("StringPreprocessing.removeNewLineChar() - Elapsed Time: {0} Milliseconds", watch.ElapsedMilliseconds);

            return text;
        }

    }
}