using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XplClient.Model;

public class BaseDataUI
{
    public static IEnumerable<String> baseDataStrings { get; private set; }

    static BaseDataUI()
    {
        List<XplLib.Objects.BaseData> baseData = XplLib.Func.ConvertEntriesToObjects(XplLib.Func.ReadEntriesFile());
        List<String> strings = new List<String>();
        foreach (XplLib.Objects.BaseData entry in baseData)
        {
            strings.Add(entry.ReturnPrintString());
        }
        baseDataStrings = strings;
    }
}
