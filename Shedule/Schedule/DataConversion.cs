using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule;

public static class DataConversion
{
    public static List<List<string>>? ConvertTextToDataList(string inputText)
    {
        List<List<string>> dataList = new();
        
        string[] lines = inputText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string line in lines)
        {
            string[] columns = line.Split(new[] { '\t' }, StringSplitOptions.None);
            List<string> row = new (columns);
            dataList.Add(row);
        }

        return dataList;
    }
}
