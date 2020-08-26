using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractPatentData
{
    class StringPreprocessing
    {
        public static string replaceWhiteSpaces(string text)
        {
            return text.Replace(" ", "-");
        }

        public static string run(string text)
        {
            if (text.Equals(string.Empty))
            {
                text = "NaN";
            }
            else
            {        
                text = removeNewLineChar(text);
                text = removeWhiteSpaces(text);
                text = addPunctuation(text);
            }
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

        public static string removeWhiteSpaces(string text)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            return regex.Replace(text, " ");
        }

        public static string removeNewLineChar(string text)
        {
            return text.Replace("\n", " ").Replace("\r", " ");
        }

    }
}