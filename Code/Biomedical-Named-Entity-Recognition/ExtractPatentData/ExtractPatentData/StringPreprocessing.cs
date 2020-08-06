using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractPatentData
{
    class StringPreprocessing
    {

        public static string run(string text)
        {
            text = checkIfStringIsEmpty(text);
            text = removeNewLineChar(text);
            text = removeWhiteSpaces(text);
            text = string.Format("{0}.", text);
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
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            text = regex.Replace(text, " ");
            return text;
        }

        public static string removeNewLineChar(string text)
        {
            return text.Replace("\n", " ").Replace("\r", " ");
        }

    }
}