using Amazon;
using System;
using System.Xml;

namespace PrepareGoldStandard
{
    public class AWScredentials
    {

        public static string accessKey = string.Empty;
        public static string secretKey = string.Empty;
        public static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast2;
        public static string consoleKey = string.Empty;

        public static string getAccessKey()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./credentials.config");
            accessKey = doc.DocumentElement.SelectSingleNode("/credentials/accessKey").InnerText;
            return accessKey;
        }

        public static string getSecretKey()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./credentials.config");
            secretKey = doc.DocumentElement.SelectSingleNode("/credentials/secretKey").InnerText;
            return secretKey;
        }

        public static string getConsoleKey()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./credentials.config");
            consoleKey = doc.DocumentElement.SelectSingleNode("/credentials/consoleKey").InnerText;
            return consoleKey;
        }

    }
}