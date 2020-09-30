using System;
using System.Text.RegularExpressions;
using System.Web;

namespace ExtractPatentData
{
    class Comparison
    {
        public static void run()
        {
            run3();
        }

        public static void run1()
        {
            string source = "blablabla &ldquo; blablabla &rdquo; blablabla &deg; blabla the clouds theXs.";

            string replaceWith = "many ";
            source = System.Text.RegularExpressions.Regex.Replace(source, "the\\s", LocalReplaceMatchCase,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            Console.WriteLine(source);

            string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression)
            {
                // Test whether the match is capitalized
                if (Char.IsUpper(matchExpression.Value[0]))
                {
                    // Capitalize the replacement string
                    System.Text.StringBuilder replacementBuilder = new System.Text.StringBuilder(replaceWith);
                    replacementBuilder[0] = Char.ToUpper(replacementBuilder[0]);
                    return replacementBuilder.ToString();
                }
                else
                {
                    return replaceWith;
                }
            }
        }

        public static void run2()
        {
            string source = "blablabla &ldquo; blablabla &rdquo; blablabla &deg; blabla the clouds theXs.";
            string normalString = HttpUtility.HtmlDecode(source);
            Console.WriteLine(normalString);
        }

        public static void run3()
        {
            string source = "blablabla &ldquo; blablabla &rdquo; blablabla &deg; blabla the clouds theXs &Prime;.";

            string pattern2 = @"&([a-z0-9]+|#[0-9]{1,6}|#x[0-9a-f]{1,6});";
            // /&([a-z0-9]+|#[0-9]{1,6}|#x[0-9a-f]{1,6});/ig

            string pattern3 = @"&([a-zA-Z0-9]{1,20});";

            //&DiacriticalDot;

            string temp = Regex.Replace(source, pattern3, string.Empty);
            
            Console.WriteLine(temp);
        }
    }
}