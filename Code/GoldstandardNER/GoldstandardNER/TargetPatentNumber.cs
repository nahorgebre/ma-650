using System;
using System.IO;
using System.Collections.Generic;

namespace GoldstandardNER
{
    class TargetPatentNumber
    {
        public string targetPatentNumber = string.Empty;
        public string targetPatentDate = string.Empty;
        public string targetPatentClaimsCount = string.Empty;

        public static List<TargetPatentNumber> getTargetPatentNumbers()
        {
            List<TargetPatentNumber> targetPatentNumberList = new List<TargetPatentNumber>();
            using (var reader = new StreamReader(PatNum.targetPatentNumbersFileName))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    TargetPatentNumber targetPatentNumber = new TargetPatentNumber();
                    var line = reader.ReadLine();
                    String[] values = line.Split(',');

                    targetPatentNumber.targetPatentNumber = values[0].Replace("\"", "");
                    targetPatentNumber.targetPatentDate = values[1].Replace("\"", "");
                    targetPatentNumber.targetPatentClaimsCount = values[2].Replace("\"", "");
                    targetPatentNumberList.Add(targetPatentNumber);                
                }
            }
            return targetPatentNumberList;
        }

    }
}