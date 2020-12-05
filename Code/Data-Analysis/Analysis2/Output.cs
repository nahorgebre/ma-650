using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Analysis2
{

    public class Output
    {

        public string Unique_Gene = string.Empty;

        public string Overall_Expression = string.Empty;

        public string First_Year = string.Empty;

        public int year2020 = 0;

        public int year2019 = 0;

        public int year2018 = 0;

        public int year2017 = 0;

        public int year2016 = 0;

        public int year2015 = 0;

        public int year2014 = 0;

        public int year2013 = 0;

        public int year2012 = 0;

        public int year2011 = 0;

        public int year2010 = 0;

        public int year2009 = 0;

        public int year2008 = 0;

        public int year2007 = 0;

        public int year2006 = 0;

        public int year2005 = 0;

        public int year2004 = 0;

        public int year2003 = 0;

        public int year2002 = 0;

        public int year2001 = 0;

        public int year2000 = 0;

        public int year1999 = 0;

        public int year1998 = 0;

        public int year1997 = 0;

        public int year1996 = 0;

        public int year1995 = 0;

        public int year1994 = 0;

        public int year1993 = 0;

        public int year1992 = 0;

        public int year1991 = 0;

        public int year1990 = 0;

        public int year1989 = 0;

        public int year1988 = 0;

        public int year1987 = 0;

        public int year1986 = 0;

        public int year1985 = 0;

        public int year1984 = 0;

        public int year1983 = 0;

        public int year1982 = 0;

        public int year1981 = 0;

        public int year1980 = 0;

        public int year1979 = 0;

        public int year1978 = 0;

        public int year1977 = 0;

        public int year1976 = 0;

        public int year1975 = 0;

        public int year1974 = 0;

        public int year1973 = 0;

        public int year1972 = 0;

        public int year1971 = 0;

        public int year1970 = 0;

        public int year1969 = 0;

        public int year1968 = 0;

        public int year1967 = 0;

        public int year1966 = 0;

        public int year1965 = 0;

        public int year1964 = 0;

        public int year1963 = 0;

        public int year1962 = 0;

        public int year1961 = 0;

        public int year1960 = 0;

        public int year1959 = 0;

        public int year1958 = 0;

        public int year1957 = 0;

        public int year1956 = 0;

        public int year1955 = 0;

        public int year1954 = 0;

        public int year1953 = 0;

        public int year1952 = 0;

        public int year1951 = 0;

        public int year1950 = 0;

        public int year1949 = 0;

        public int year1948 = 0;

        public int year1947 = 0;

        public int year1946 = 0;

        public int year1945 = 0;

        public int year1944 = 0;

        public int year1943 = 0;

        public int year1942 = 0;

        public int year1941 = 0;

        public int year1940 = 0;

        public int year1939 = 0;

        public int year1938 = 0;

        public int year1937 = 0;

        public int year1936 = 0;

        public int year1935 = 0;

        public int year1934 = 0;

        public int year1933 = 0;

        public int year1932 = 0;

        public int year1931 = 0;

        public int year1930 = 0;

        public int year1929 = 0;

        public int year1928 = 0;

        public int year1927 = 0;

        public int year1926 = 0;

        public int year1925 = 0;

        public int year1924 = 0;

        public int year1923 = 0;

        public int year1922 = 0;

        public int year1921 = 0;

        public int year1920 = 0;

        public int year1919 = 0;

        public int year1918 = 0;

        public int year1917 = 0;

        public int year1916 = 0;

        public int year1915 = 0;

        public int year1914 = 0;

        public int year1913 = 0;

        public int year1912 = 0;

        public int year1911 = 0;

        public int year1910 = 0;

        public int year1909 = 0;

        public int year1908 = 0;

        public int year1907 = 0;

        public int year1906 = 0;

        public int year1905 = 0;

        public int year1904 = 0;

        public int year1903 = 0;

        public int year1902 = 0;

        public int year1901 = 0;

        public int year1900 = 0;

        public int year1899 = 0;

        public int year1898 = 0;

        public int year1897 = 0;

        public int year1896 = 0;

        public int year1895 = 0;

        public int year1894 = 0;

        public int year1893 = 0;

        public int year1892 = 0;

        public int year1891 = 0;

        public int year1890 = 0;

        public int year1889 = 0;

        public int year1888 = 0;

        public int year1887 = 0;

        public int year1886 = 0;

        public int year1885 = 0;

        public int year1884 = 0;

        public int year1883 = 0;

        public int year1882 = 0;

        public int year1881 = 0;

        public int year1880 = 0;

        public int year1879 = 0;

        public int year1878 = 0;

        public int year1877 = 0;

        public int year1876 = 0;

        public int year1875 = 0;

        public int year1874 = 0;

        public int year1873 = 0;

        public int year1872 = 0;

        public int year1871 = 0;

        public int year1870 = 0;

        public int year1869 = 0;

        public int year1868 = 0;

        public int year1867 = 0;

        public int year1866 = 0;

        public int year1865 = 0;

        public int year1864 = 0;

        public int year1863 = 0;

        public int year1862 = 0;

        public int year1861 = 0;

        public int year1860 = 0;

        public int year1859 = 0;

        public int year1858 = 0;

        public int year1857 = 0;

        public int year1856 = 0;

        public int year1855 = 0;

        public int year1854 = 0;

        public int year1853 = 0;

        public int year1852 = 0;

        public int year1851 = 0;

        public int year1850 = 0;

        public int year1849 = 0;

        public int year1848 = 0;

        public int year1847 = 0;

        public int year1846 = 0;

        public int year1845 = 0;

        public int year1844 = 0;

        public int year1843 = 0;

        public int year1842 = 0;

        public int year1841 = 0;

        public int year1840 = 0;

        public int year1839 = 0;

        public int year1838 = 0;

        public int year1837 = 0;

        public int year1836 = 0;

        public int year1835 = 0;

        public int year1834 = 0;

        public int year1833 = 0;

        public int year1832 = 0;

        public int year1831 = 0;

        public int year1830 = 0;

        public int year1829 = 0;

        public int year1828 = 0;

        public int year1827 = 0;

        public int year1826 = 0;

        public int year1825 = 0;

        public int year1824 = 0;

        public int year1823 = 0;

        public int year1822 = 0;

        public int year1821 = 0;

        public int year1820 = 0;

        public int year1819 = 0;

        public int year1818 = 0;

        public int year1817 = 0;

        public int year1816 = 0;

        public int year1815 = 0;

        public int year1814 = 0;

        public int year1813 = 0;

        public int year1812 = 0;

        public int year1811 = 0;

        public int year1810 = 0;

        public int year1809 = 0;

        public int year1808 = 0;

        public int year1807 = 0;

        public int year1806 = 0;

        public int year1805 = 0;

        public int year1804 = 0;

        public int year1803 = 0;

        public int year1802 = 0;

        public int year1801 = 0;

        public int year1800 = 0;

        public int year1799 = 0;

        public int year1798 = 0;

        public int year1797 = 0;

        public int year1796 = 0;

        public int year1795 = 0;

        public int year1794 = 0;

        public int year1793 = 0;

        public int year1792 = 0;

        public int year1791 = 0;

        public int year1790 = 0;

        public int year1789 = 0;

        public int year1788 = 0;

        public int year1787 = 0;

        public int year1786 = 0;

        public int year1785 = 0;

        public static void createXml(List<Gene> gene_list, string fileName, string directory)
        {

            Console.WriteLine("Create Xml: " + fileName);

            Console.WriteLine("Count: " + gene_list.Count);

            Directory.CreateDirectory(string.Format("{0}/{1}", Environment.CurrentDirectory, directory));

            XmlSerializer serializer = new XmlSerializer(typeof(Genes));

            TextWriter writer = new StreamWriter(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName));

            Genes genes = new Genes();

            genes.gene = gene_list;

            serializer.Serialize(writer, genes);

            writer.Close();

            Console.WriteLine(string.Format("{0}/{1}/{2}", Environment.CurrentDirectory, directory, fileName));

        }

        public static void createTsv(List<Gene> gene_list, FileInfo file)
        {

            file.Directory.Create();

            var delimiter = "\t";

            using (StreamWriter sw = new StreamWriter(file.FullName))
            {

                List<string> firstLineContent = new List<string>()
                {

                    "Unique_Gene",

                    "Overall_Expression",

                    "First_Year",

                    "2020",

                    "2019",

                    "2018",

                    "2017",

                    "2016",

                    "2015",

                    "2014",

                    "2013",

                    "2012",

                    "2011",

                    "2010",

                    "2009",

                    "2008",

                    "2007",

                    "2006",

                    "2005",

                    "2004",

                    "2003",

                    "2002",

                    "2001",

                    "2000",

                    "1999",

                    "1998",

                    "1997",

                    "1996",

                    "1995",

                    "1994",

                    "1993",

                    "1992",

                    "1991",

                    "1990",

                    "1989",

                    "1988",

                    "1987",

                    "1986",

                    "1985",

                    "1984",

                    "1983",

                    "1982",

                    "1981",

                    "1980",

                    "1979",

                    "1978",

                    "1977",

                    "1976",

                    "1975",

                    "1974",

                    "1973",

                    "1972",

                    "1971",

                    "1970",

                    "1969",

                    "1968",

                    "1967",

                    "1966",

                    "1965",

                    "1964",

                    "1963",

                    "1962",

                    "1961",

                    "1960",

                    "1959",

                    "1958",

                    "1957",

                    "1956",

                    "1955",

                    "1954",

                    "1953",

                    "1952",

                    "1951",

                    "1950",

                    "1949",

                    "1948",

                    "1947",

                    "1946",

                    "1945",

                    "1944",

                    "1943",

                    "1942",

                    "1941",

                    "1940",

                    "1939",

                    "1938",

                    "1937",

                    "1936",

                    "1935",

                    "1934",

                    "1933",

                    "1932",

                    "1931",

                    "1930",

                    "1929",

                    "1928",

                    "1927",

                    "1926",

                    "1925",

                    "1924",

                    "1923",

                    "1922",

                    "1921",

                    "1920",

                    "1919",

                    "1918",

                    "1917",

                    "1916",

                    "1915",

                    "1914",

                    "1913",

                    "1912",

                    "1911",

                    "1910",

                    "1909",

                    "1908",

                    "1907",

                    "1906",

                    "1905",

                    "1904",

                    "1903",

                    "1902",

                    "1901",

                    "1900",

                    "1899",

                    "1898",

                    "1897",

                    "1896",

                    "1895",

                    "1894",

                    "1893",

                    "1892",

                    "1891",

                    "1890",

                    "1889",

                    "1888",

                    "1887",

                    "1886",

                    "1885",

                    "1884",

                    "1883",

                    "1882",

                    "1881",

                    "1880",

                    "1879",

                    "1878",

                    "1877",

                    "1876",

                    "1875",

                    "1874",

                    "1873",

                    "1872",

                    "1871",

                    "1870",

                    "1869",

                    "1868",

                    "1867",

                    "1866",

                    "1865",

                    "1864",

                    "1863",

                    "1862",

                    "1861",

                    "1860",

                    "1859",

                    "1858",

                    "1857",

                    "1856",

                    "1855",

                    "1854",

                    "1853",

                    "1852",

                    "1851",

                    "1850",

                    "1849",

                    "1848",

                    "1847",

                    "1846",

                    "1845",

                    "1844",

                    "1843",

                    "1842",

                    "1841",

                    "1840",

                    "1839",

                    "1838",

                    "1837",

                    "1836",

                    "1835",

                    "1834",

                    "1833",

                    "1832",

                    "1831",

                    "1830",

                    "1829",

                    "1828",

                    "1827",

                    "1826",

                    "1825",

                    "1824",

                    "1823",

                    "1822",

                    "1821",

                    "1820",

                    "1819",

                    "1818",

                    "1817",

                    "1816",

                    "1815",

                    "1814",

                    "1813",

                    "1812",

                    "1811",

                    "1810",

                    "1809",

                    "1808",

                    "1807",

                    "1806",

                    "1805",

                    "1804",

                    "1803",

                    "1802",

                    "1801",

                    "1800",

                    "1799",

                    "1798",

                    "1797",

                    "1796",

                    "1795",

                    "1794",

                    "1793",

                    "1792",

                    "1791",

                    "1790",

                    "1789",

                    "1788",

                    "1787",

                    "1786",

                    "1785"

                };

                var firstLine = string.Join(delimiter, firstLineContent);

                sw.WriteLine(firstLine);


                foreach (Gene geneItem in gene_list)
                {

                    Output output = new Output();

                    if(!string.IsNullOrEmpty(geneItem.ensemblId))
                    {

                    output.Unique_Gene = geneItem.ensemblId;

                    output.Overall_Expression = getOverallExpression(geneItem.organs);

                    output.First_Year = getFirstYear(geneItem.publicationMentions);


                    foreach (GenePublicationMention publicationMentionItem in geneItem.publicationMentions)
                    {

                        if (!string.IsNullOrEmpty(publicationMentionItem.year))
                        {

                            if (publicationMentionItem.year.Equals("2020"))
                            {

                                output.year2020 = output.year2020 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2019"))
                            {

                                output.year2019 = output.year2019 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2018"))
                            {

                                output.year2018 = output.year2018 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2017"))
                            {

                                output.year2017 = output.year2017 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2016"))
                            {

                                output.year2016 = output.year2016 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2015"))
                            {

                                output.year2015 = output.year2015 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2014"))
                            {

                                output.year2014 = output.year2014 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2013"))
                            {

                                output.year2013 = output.year2013 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2012"))
                            {

                                output.year2012 = output.year2012 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2011"))
                            {

                                output.year2011 = output.year2011 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2010"))
                            {

                                output.year2010 = output.year2010 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2009"))
                            {

                                output.year2009 = output.year2009 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2008"))
                            {

                                output.year2008 = output.year2008 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2007"))
                            {

                                output.year2007 = output.year2007 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2006"))
                            {

                                output.year2006 = output.year2006 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2005"))
                            {

                                output.year2005 = output.year2005 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2004"))
                            {

                                output.year2004 = output.year2004 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2003"))
                            {

                                output.year2003 = output.year2003 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2002"))
                            {

                                output.year2002 = output.year2002 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2001"))
                            {

                                output.year2001 = output.year2001 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("2000"))
                            {

                                output.year2000 = output.year2000 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1999"))
                            {

                                output.year1999 = output.year1999 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1998"))
                            {

                                output.year1998 = output.year1998 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1997"))
                            {

                                output.year1997 = output.year1997 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1996"))
                            {

                                output.year1996 = output.year1996 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1995"))
                            {

                                output.year1995 = output.year1995 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1994"))
                            {

                                output.year1994 = output.year1994 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1993"))
                            {

                                output.year1993 = output.year1993 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1992"))
                            {

                                output.year1992 = output.year1992 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1991"))
                            {

                                output.year1991 = output.year1991 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1990"))
                            {

                                output.year1990 = output.year1990 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1989"))
                            {

                                output.year1989 = output.year1989 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1988"))
                            {

                                output.year1988 = output.year1988 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1987"))
                            {

                                output.year1987 = output.year1987 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1986"))
                            {

                                output.year1986 = output.year1986 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1985"))
                            {

                                output.year1985 = output.year1985 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1984"))
                            {

                                output.year1984 = output.year1984 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1983"))
                            {

                                output.year1983 = output.year1983 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1982"))
                            {

                                output.year1982 = output.year1982 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1981"))
                            {

                                output.year1981 = output.year1981 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1980"))
                            {

                                output.year1980 = output.year1980 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1979"))
                            {

                                output.year1979 = output.year1979 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1978"))
                            {

                                output.year1978 = output.year1978 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1977"))
                            {

                                output.year1977 = output.year1977 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1976"))
                            {

                                output.year1976 = output.year1976 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1975"))
                            {

                                output.year1975 = output.year1975 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1974"))
                            {

                                output.year1974 = output.year1974 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1973"))
                            {

                                output.year1973 = output.year1973 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1972"))
                            {

                                output.year1972 = output.year1972 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1971"))
                            {

                                output.year1971 = output.year1971 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1970"))
                            {

                                output.year1970 = output.year1970 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1969"))
                            {

                                output.year1969 = output.year1969 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1968"))
                            {

                                output.year1968 = output.year1968 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1967"))
                            {

                                output.year1967 = output.year1967 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1966"))
                            {

                                output.year1966 = output.year1966 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1965"))
                            {

                                output.year1965 = output.year1965 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1964"))
                            {

                                output.year1964 = output.year1964 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1963"))
                            {

                                output.year1963 = output.year1963 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1962"))
                            {

                                output.year1962 = output.year1962 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1961"))
                            {

                                output.year1961 = output.year1961 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1960"))
                            {

                                output.year1960 = output.year1960 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1959"))
                            {

                                output.year1959 = output.year1959 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1958"))
                            {

                                output.year1958 = output.year1958 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1957"))
                            {

                                output.year1957 = output.year1957 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1956"))
                            {

                                output.year1956 = output.year1956 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1955"))
                            {

                                output.year1955 = output.year1955 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1954"))
                            {

                                output.year1954 = output.year1954 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1953"))
                            {

                                output.year1953 = output.year1953 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1952"))
                            {

                                output.year1952 = output.year1952 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1951"))
                            {

                                output.year1951 = output.year1951 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1950"))
                            {

                                output.year1950 = output.year1950 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1949"))
                            {

                                output.year1949 = output.year1949 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1948"))
                            {

                                output.year1948 = output.year1948 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1947"))
                            {

                                output.year1947 = output.year1947 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1946"))
                            {

                                output.year1946 = output.year1946 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1945"))
                            {

                                output.year1945 = output.year1945 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1944"))
                            {

                                output.year1944 = output.year1944 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1943"))
                            {

                                output.year1943 = output.year1943 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1942"))
                            {

                                output.year1942 = output.year1942 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1941"))
                            {

                                output.year1941 = output.year1941 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1940"))
                            {

                                output.year1940 = output.year1940 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1939"))
                            {

                                output.year1939 = output.year1939 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1938"))
                            {

                                output.year1938 = output.year1938 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1937"))
                            {

                                output.year1937 = output.year1937 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1936"))
                            {

                                output.year1936 = output.year1936 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1935"))
                            {

                                output.year1935 = output.year1935 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1934"))
                            {

                                output.year1934 = output.year1934 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1933"))
                            {

                                output.year1933 = output.year1933 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1932"))
                            {

                                output.year1932 = output.year1932 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1931"))
                            {

                                output.year1931 = output.year1931 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1930"))
                            {

                                output.year1930 = output.year1930 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1929"))
                            {

                                output.year1929 = output.year1929 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1928"))
                            {

                                output.year1928 = output.year1928 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1927"))
                            {

                                output.year1927 = output.year1927 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1926"))
                            {

                                output.year1926 = output.year1926 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1925"))
                            {

                                output.year1925 = output.year1925 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1924"))
                            {

                                output.year1924 = output.year1924 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1923"))
                            {

                                output.year1923 = output.year1923 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1922"))
                            {

                                output.year1922 = output.year1922 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1921"))
                            {

                                output.year1921 = output.year1921 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1920"))
                            {

                                output.year1920 = output.year1920 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1919"))
                            {

                                output.year1919 = output.year1919 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1918"))
                            {

                                output.year1918 = output.year1918 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1917"))
                            {

                                output.year1917 = output.year1917 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1916"))
                            {

                                output.year1916 = output.year1916 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1915"))
                            {

                                output.year1915 = output.year1915 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1914"))
                            {

                                output.year1914 = output.year1914 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1913"))
                            {

                                output.year1913 = output.year1913 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1912"))
                            {

                                output.year1912 = output.year1912 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1911"))
                            {

                                output.year1911 = output.year1911 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1910"))
                            {

                                output.year1910 = output.year1910 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1909"))
                            {

                                output.year1909 = output.year1909 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1908"))
                            {

                                output.year1908 = output.year1908 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1907"))
                            {

                                output.year1907 = output.year1907 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1906"))
                            {

                                output.year1906 = output.year1906 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1905"))
                            {

                                output.year1905 = output.year1905 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1904"))
                            {

                                output.year1904 = output.year1904 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1903"))
                            {

                                output.year1903 = output.year1903 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1902"))
                            {

                                output.year1902 = output.year1902 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1901"))
                            {

                                output.year1901 = output.year1901 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1900"))
                            {

                                output.year1900 = output.year1900 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1899"))
                            {

                                output.year1899 = output.year1899 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1898"))
                            {

                                output.year1898 = output.year1898 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1897"))
                            {

                                output.year1897 = output.year1897 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1896"))
                            {

                                output.year1896 = output.year1896 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1895"))
                            {

                                output.year1895 = output.year1895 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1894"))
                            {

                                output.year1894 = output.year1894 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1893"))
                            {

                                output.year1893 = output.year1893 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1892"))
                            {

                                output.year1892 = output.year1892 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1891"))
                            {

                                output.year1891 = output.year1891 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1890"))
                            {

                                output.year1890 = output.year1890 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1889"))
                            {

                                output.year1889 = output.year1889 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1888"))
                            {

                                output.year1888 = output.year1888 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1887"))
                            {

                                output.year1887 = output.year1887 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1886"))
                            {

                                output.year1886 = output.year1886 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1885"))
                            {

                                output.year1885 = output.year1885 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1884"))
                            {

                                output.year1884 = output.year1884 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1883"))
                            {

                                output.year1883 = output.year1883 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1882"))
                            {

                                output.year1882 = output.year1882 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1881"))
                            {

                                output.year1881 = output.year1881 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1880"))
                            {

                                output.year1880 = output.year1880 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1879"))
                            {

                                output.year1879 = output.year1879 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1878"))
                            {

                                output.year1878 = output.year1878 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1877"))
                            {

                                output.year1877 = output.year1877 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1876"))
                            {

                                output.year1876 = output.year1876 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1875"))
                            {

                                output.year1875 = output.year1875 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1874"))
                            {

                                output.year1874 = output.year1874 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1873"))
                            {

                                output.year1873 = output.year1873 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1872"))
                            {

                                output.year1872 = output.year1872 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1871"))
                            {

                                output.year1871 = output.year1871 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1870"))
                            {

                                output.year1870 = output.year1870 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1869"))
                            {

                                output.year1869 = output.year1869 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1868"))
                            {

                                output.year1868 = output.year1868 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1867"))
                            {

                                output.year1867 = output.year1867 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1866"))
                            {

                                output.year1866 = output.year1866 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1865"))
                            {

                                output.year1865 = output.year1865 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1864"))
                            {

                                output.year1864 = output.year1864 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1863"))
                            {

                                output.year1863 = output.year1863 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1862"))
                            {

                                output.year1862 = output.year1862 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1861"))
                            {

                                output.year1861 = output.year1861 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1860"))
                            {

                                output.year1860 = output.year1860 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1859"))
                            {

                                output.year1859 = output.year1859 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1858"))
                            {

                                output.year1858 = output.year1858 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1857"))
                            {

                                output.year1857 = output.year1857 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1856"))
                            {

                                output.year1856 = output.year1856 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1855"))
                            {

                                output.year1855 = output.year1855 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1854"))
                            {

                                output.year1854 = output.year1854 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1853"))
                            {

                                output.year1853 = output.year1853 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1852"))
                            {

                                output.year1852 = output.year1852 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1851"))
                            {

                                output.year1851 = output.year1851 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1850"))
                            {

                                output.year1850 = output.year1850 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1849"))
                            {

                                output.year1849 = output.year1849 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1848"))
                            {

                                output.year1848 = output.year1848 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1847"))
                            {

                                output.year1847 = output.year1847 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1846"))
                            {

                                output.year1846 = output.year1846 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1845"))
                            {

                                output.year1845 = output.year1845 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1844"))
                            {

                                output.year1844 = output.year1844 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1843"))
                            {

                                output.year1843 = output.year1843 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1842"))
                            {

                                output.year1842 = output.year1842 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1841"))
                            {

                                output.year1841 = output.year1841 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1840"))
                            {

                                output.year1840 = output.year1840 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1839"))
                            {

                                output.year1839 = output.year1839 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1838"))
                            {

                                output.year1838 = output.year1838 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1837"))
                            {

                                output.year1837 = output.year1837 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1836"))
                            {

                                output.year1836 = output.year1836 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1835"))
                            {

                                output.year1835 = output.year1835 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1834"))
                            {

                                output.year1834 = output.year1834 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1833"))
                            {

                                output.year1833 = output.year1833 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1832"))
                            {

                                output.year1832 = output.year1832 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1831"))
                            {

                                output.year1831 = output.year1831 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1830"))
                            {

                                output.year1830 = output.year1830 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1829"))
                            {

                                output.year1829 = output.year1829 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1828"))
                            {

                                output.year1828 = output.year1828 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1827"))
                            {

                                output.year1827 = output.year1827 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1826"))
                            {

                                output.year1826 = output.year1826 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1825"))
                            {

                                output.year1825 = output.year1825 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1824"))
                            {

                                output.year1824 = output.year1824 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1823"))
                            {

                                output.year1823 = output.year1823 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1822"))
                            {

                                output.year1822 = output.year1822 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1821"))
                            {

                                output.year1821 = output.year1821 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1820"))
                            {

                                output.year1820 = output.year1820 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1819"))
                            {

                                output.year1819 = output.year1819 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1818"))
                            {

                                output.year1818 = output.year1818 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1817"))
                            {

                                output.year1817 = output.year1817 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1816"))
                            {

                                output.year1816 = output.year1816 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1815"))
                            {

                                output.year1815 = output.year1815 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1814"))
                            {

                                output.year1814 = output.year1814 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1813"))
                            {

                                output.year1813 = output.year1813 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1812"))
                            {

                                output.year1812 = output.year1812 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1811"))
                            {

                                output.year1811 = output.year1811 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1810"))
                            {

                                output.year1810 = output.year1810 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1809"))
                            {

                                output.year1809 = output.year1809 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1808"))
                            {

                                output.year1808 = output.year1808 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1807"))
                            {

                                output.year1807 = output.year1807 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1806"))
                            {

                                output.year1806 = output.year1806 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1805"))
                            {

                                output.year1805 = output.year1805 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1804"))
                            {

                                output.year1804 = output.year1804 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1803"))
                            {

                                output.year1803 = output.year1803 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1802"))
                            {

                                output.year1802 = output.year1802 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1801"))
                            {

                                output.year1801 = output.year1801 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1800"))
                            {

                                output.year1800 = output.year1800 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1799"))
                            {

                                output.year1799 = output.year1799 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1798"))
                            {

                                output.year1798 = output.year1798 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1797"))
                            {

                                output.year1797 = output.year1797 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1796"))
                            {

                                output.year1796 = output.year1796 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1795"))
                            {

                                output.year1795 = output.year1795 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1794"))
                            {

                                output.year1794 = output.year1794 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1793"))
                            {

                                output.year1793 = output.year1793 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1792"))
                            {

                                output.year1792 = output.year1792 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1791"))
                            {

                                output.year1791 = output.year1791 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1790"))
                            {

                                output.year1790 = output.year1790 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1789"))
                            {

                                output.year1789 = output.year1789 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1788"))
                            {

                                output.year1788 = output.year1788 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1787"))
                            {

                                output.year1787 = output.year1787 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1786"))
                            {

                                output.year1786 = output.year1786 + 1;

                            }
                            else if (publicationMentionItem.year.Equals("1785"))
                            {

                                output.year1785 = output.year1785 + 1;

                            }

                        }

                    }


                    List<string> lineContent = new List<string>()
                    {

                        output.Unique_Gene,

                        output.Overall_Expression,

                        output.First_Year,

                        output.year2020.ToString(),

                        output.year2019.ToString(),

                        output.year2018.ToString(),

                        output.year2017.ToString(),

                        output.year2016.ToString(),

                        output.year2015.ToString(),

                        output.year2014.ToString(),

                        output.year2013.ToString(),

                        output.year2012.ToString(),

                        output.year2011.ToString(),

                        output.year2010.ToString(),

                        output.year2009.ToString(),

                        output.year2008.ToString(),

                        output.year2007.ToString(),

                        output.year2006.ToString(),

                        output.year2005.ToString(),

                        output.year2004.ToString(),

                        output.year2003.ToString(),

                        output.year2002.ToString(),

                        output.year2001.ToString(),

                        output.year2000.ToString(),

                        output.year1999.ToString(),

                        output.year1998.ToString(),

                        output.year1997.ToString(),

                        output.year1996.ToString(),

                        output.year1995.ToString(),

                        output.year1994.ToString(),

                        output.year1993.ToString(),

                        output.year1992.ToString(),

                        output.year1991.ToString(),

                        output.year1990.ToString(),

                        output.year1989.ToString(),

                        output.year1988.ToString(),

                        output.year1987.ToString(),

                        output.year1986.ToString(),

                        output.year1985.ToString(),

                        output.year1984.ToString(),

                        output.year1983.ToString(),

                        output.year1982.ToString(),

                        output.year1981.ToString(),

                        output.year1980.ToString(),

                        output.year1979.ToString(),

                        output.year1978.ToString(),

                        output.year1977.ToString(),

                        output.year1976.ToString(),

                        output.year1975.ToString(),

                        output.year1974.ToString(),

                        output.year1973.ToString(),

                        output.year1972.ToString(),

                        output.year1971.ToString(),

                        output.year1970.ToString(),

                        output.year1969.ToString(),

                        output.year1968.ToString(),

                        output.year1967.ToString(),

                        output.year1966.ToString(),

                        output.year1965.ToString(),

                        output.year1964.ToString(),

                        output.year1963.ToString(),

                        output.year1962.ToString(),

                        output.year1961.ToString(),

                        output.year1960.ToString(),

                        output.year1959.ToString(),

                        output.year1958.ToString(),

                        output.year1957.ToString(),

                        output.year1956.ToString(),

                        output.year1955.ToString(),

                        output.year1954.ToString(),

                        output.year1953.ToString(),

                        output.year1952.ToString(),

                        output.year1951.ToString(),

                        output.year1950.ToString(),

                        output.year1949.ToString(),

                        output.year1948.ToString(),

                        output.year1947.ToString(),

                        output.year1946.ToString(),

                        output.year1945.ToString(),

                        output.year1944.ToString(),

                        output.year1943.ToString(),

                        output.year1942.ToString(),

                        output.year1941.ToString(),

                        output.year1940.ToString(),

                        output.year1939.ToString(),

                        output.year1938.ToString(),

                        output.year1937.ToString(),

                        output.year1936.ToString(),

                        output.year1935.ToString(),

                        output.year1934.ToString(),

                        output.year1933.ToString(),

                        output.year1932.ToString(),

                        output.year1931.ToString(),

                        output.year1930.ToString(),

                        output.year1929.ToString(),

                        output.year1928.ToString(),

                        output.year1927.ToString(),

                        output.year1926.ToString(),

                        output.year1925.ToString(),

                        output.year1924.ToString(),

                        output.year1923.ToString(),

                        output.year1922.ToString(),

                        output.year1921.ToString(),

                        output.year1920.ToString(),

                        output.year1919.ToString(),

                        output.year1918.ToString(),

                        output.year1917.ToString(),

                        output.year1916.ToString(),

                        output.year1915.ToString(),

                        output.year1914.ToString(),

                        output.year1913.ToString(),

                        output.year1912.ToString(),

                        output.year1911.ToString(),

                        output.year1910.ToString(),

                        output.year1909.ToString(),

                        output.year1908.ToString(),

                        output.year1907.ToString(),

                        output.year1906.ToString(),

                        output.year1905.ToString(),

                        output.year1904.ToString(),

                        output.year1903.ToString(),

                        output.year1902.ToString(),

                        output.year1901.ToString(),

                        output.year1900.ToString(),

                        output.year1899.ToString(),

                        output.year1898.ToString(),

                        output.year1897.ToString(),

                        output.year1896.ToString(),

                        output.year1895.ToString(),

                        output.year1894.ToString(),

                        output.year1893.ToString(),

                        output.year1892.ToString(),

                        output.year1891.ToString(),

                        output.year1890.ToString(),

                        output.year1889.ToString(),

                        output.year1888.ToString(),

                        output.year1887.ToString(),

                        output.year1886.ToString(),

                        output.year1885.ToString(),

                        output.year1884.ToString(),

                        output.year1883.ToString(),

                        output.year1882.ToString(),

                        output.year1881.ToString(),

                        output.year1880.ToString(),

                        output.year1879.ToString(),

                        output.year1878.ToString(),

                        output.year1877.ToString(),

                        output.year1876.ToString(),

                        output.year1875.ToString(),

                        output.year1874.ToString(),

                        output.year1873.ToString(),

                        output.year1872.ToString(),

                        output.year1871.ToString(),

                        output.year1870.ToString(),

                        output.year1869.ToString(),

                        output.year1868.ToString(),

                        output.year1867.ToString(),

                        output.year1866.ToString(),

                        output.year1865.ToString(),

                        output.year1864.ToString(),

                        output.year1863.ToString(),

                        output.year1862.ToString(),

                        output.year1861.ToString(),

                        output.year1860.ToString(),

                        output.year1859.ToString(),

                        output.year1858.ToString(),

                        output.year1857.ToString(),

                        output.year1856.ToString(),

                        output.year1855.ToString(),

                        output.year1854.ToString(),

                        output.year1853.ToString(),

                        output.year1852.ToString(),

                        output.year1851.ToString(),

                        output.year1850.ToString(),

                        output.year1849.ToString(),

                        output.year1848.ToString(),

                        output.year1847.ToString(),

                        output.year1846.ToString(),

                        output.year1845.ToString(),

                        output.year1844.ToString(),

                        output.year1843.ToString(),

                        output.year1842.ToString(),

                        output.year1841.ToString(),

                        output.year1840.ToString(),

                        output.year1839.ToString(),

                        output.year1838.ToString(),

                        output.year1837.ToString(),

                        output.year1836.ToString(),

                        output.year1835.ToString(),

                        output.year1834.ToString(),

                        output.year1833.ToString(),

                        output.year1832.ToString(),

                        output.year1831.ToString(),

                        output.year1830.ToString(),

                        output.year1829.ToString(),

                        output.year1828.ToString(),

                        output.year1827.ToString(),

                        output.year1826.ToString(),

                        output.year1825.ToString(),

                        output.year1824.ToString(),

                        output.year1823.ToString(),

                        output.year1822.ToString(),

                        output.year1821.ToString(),

                        output.year1820.ToString(),

                        output.year1819.ToString(),

                        output.year1818.ToString(),

                        output.year1817.ToString(),

                        output.year1816.ToString(),

                        output.year1815.ToString(),

                        output.year1814.ToString(),

                        output.year1813.ToString(),

                        output.year1812.ToString(),

                        output.year1811.ToString(),

                        output.year1810.ToString(),

                        output.year1809.ToString(),

                        output.year1808.ToString(),

                        output.year1807.ToString(),

                        output.year1806.ToString(),

                        output.year1805.ToString(),

                        output.year1804.ToString(),

                        output.year1803.ToString(),

                        output.year1802.ToString(),

                        output.year1801.ToString(),

                        output.year1800.ToString(),

                        output.year1799.ToString(),

                        output.year1798.ToString(),

                        output.year1797.ToString(),

                        output.year1796.ToString(),

                        output.year1795.ToString(),

                        output.year1794.ToString(),

                        output.year1793.ToString(),

                        output.year1792.ToString(),

                        output.year1791.ToString(),

                        output.year1790.ToString(),

                        output.year1789.ToString(),

                        output.year1788.ToString(),

                        output.year1787.ToString(),

                        output.year1786.ToString(),

                        output.year1785.ToString()

                    };

                    var line = string.Join(delimiter, lineContent);

                    sw.WriteLine(line);

                    }

                }

            }

        }

        public static string getFirstYear(List<GenePublicationMention> publicationList)
        {

            int First_Year = 3000;

            foreach (GenePublicationMention publicationItem in publicationList)
            {

                if (!string.IsNullOrEmpty(publicationItem.year))
                {

                    if (Int32.Parse(publicationItem.year) < First_Year)
                    {

                        Console.WriteLine(Int32.Parse(publicationItem.year));

                        First_Year = Int32.Parse(publicationItem.year);

                    }
                    
                }

            }

            if (First_Year.Equals(3000))
            {

                return "-";

            }
            else{

                return First_Year.ToString();

            }

        }

        public static string getOverallExpression(List<Organ> organList)
        {

            string overallExpression = string.Empty;

            foreach (Organ organItem in organList)
            {

                if (organItem.organName.Equals("overallExpression"))
                {

                    overallExpression = organItem.call;

                }

            }

            return overallExpression;

        }

    }

}