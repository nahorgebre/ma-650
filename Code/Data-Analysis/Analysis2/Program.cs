﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Analysis2
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> pubMedDateDictionary = Methods.getPubMedDateDisctionary();

            Console.WriteLine("Dictionary Size: " + pubMedDateDictionary.Count);

            string x = pubMedDateDictionary["19223445"];

            Console.WriteLine(x);

        }
    }
}
