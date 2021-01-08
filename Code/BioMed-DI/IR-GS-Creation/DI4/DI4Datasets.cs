using System;
using System.IO;

namespace IR_GS_Creation
{
    class DI4Datasets
    {

        public static FileInfo DI3_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/DI3_dt.tsv");  
        public static FileInfo patent_abstract_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_abstract_dt.tsv");  
        public static FileInfo patent_title_dt = new FileInfo(Environment.CurrentDirectory + "/data/input/DI4/patent_title_dt.tsv");              

    }

}