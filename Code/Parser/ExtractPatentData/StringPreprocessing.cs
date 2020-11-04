using System.Text.RegularExpressions;

namespace ExtractPatentData
{
    class StringPreprocessing
    {
        public static string run(string text)
        {
            text = text.Trim();
            if (text.Equals(string.Empty))
            {
                text = "NaN";
            }
            else
            {        
                text = RemoveLineBreaks(text);
                text = removeWhiteSpaces(text);
                //text = addPunctuation(text);
            }
            return text;
        }

        public static string addPunctuation(string text)
        {
            if (!text.Substring(text.Length - 1).Equals("."))
            {
                text = string.Format("{0}. ", text);
            }
            return text;
        }

        public static string removeWhiteSpaces(string text)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            return regex.Replace(text, " ");
        }

        /*
        public static string removeNewLineChar(string text)
        {
            return text.Replace("\n", " ").Replace("\r", " ");
        }
        */

        public static string RemoveLineBreaks(string s)
        {
            return Regex.Replace(s, @"\t|\n|\r", string.Empty);
        }

    }
}