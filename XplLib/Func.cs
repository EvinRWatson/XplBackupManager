using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XplLib
{
    public static class Func
    {
        public static List<String[]> ReadEntriesFile()
        {
            List<String[]> entries = new List<String[]>();
            String fname = "C:\\Dev\\BackupTest\\entries.csv";
            string[] lines = System.IO.File.ReadAllLines(fname);
            foreach (string line in lines)
            {
                entries.Add(line.Split(","));
            }
            return entries;
        }
    }
}
