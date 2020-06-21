using DataTranslation;
using System.IO;

public class Program
{
    public static void Main()
    {
        dataTranslationPubLinks();
        dataTranslationPubMentions();
    }

    public static void dataTranslationPubLinks() 
    {
        Directory.CreateDirectory("Publication-Links");
        pubLinksMethods.pubLinks_dt();
    }

    public static void dataTranslationPubMentions() 
    {
        Directory.CreateDirectory("Publication-Mentions");
        pubMentionsMethods.pubMentions_dt();
    }

}