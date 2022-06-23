using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XplLib.Objects;

namespace XplLib
{
    public static class Func
    {
        public static List<String[]> ReadEntriesFile()
        {
            List<String[]> entries = new List<String[]>();
            string value = "";
            String fname = "C:\\Dev\\BackupTest\\entries.csv";
            string[] lines = System.IO.File.ReadAllLines(fname);
            foreach (string line in lines)
            {
                entries.Add(line.Split(","));
            }
            return entries;
        }

        public static List<Objects.BaseData> ConvertEntriesToObjects(List<String[]> entries)
        {
            List<Objects.BaseData> objects = new List<Objects.BaseData>();
            foreach (var entry in entries)
            {
                switch (entry[1])
                {
                    case "local":
                        objects.Add(new LocalData(entry));
                        break;
                }
            }
            return objects;
        }

    }
}
