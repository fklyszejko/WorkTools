using System.Text.RegularExpressions;
using static Schedule.ItemHandler;

namespace Schedule;

public static class ItemGeneration
{
    public static List<Item> GenerateItemFromSchedule(string text, string month, string year)
    {
        List<List<string>> input = DataConversion.ConvertTextToDataList(text) ?? throw new ArgumentException("Nieprawidłowe dane wejściowe.");
        List<Item> items = new();

        while (input.Count > 0)
        {
            ProcessItemCondition(input, items, month, year);
        }

        return items;
    }

    private static void ProcessItemCondition(List<List<string>> input, List<Item> items, string month, string year)
    {
        if (input[0].Count < 3)
        {
            throw new ArgumentException("Dane wejściowe są nieprawidłowe lub niekompletne.");
        }

        string time = input[0][2];
        string itemType = input[0][1];

        if (string.IsNullOrEmpty(time))
        {
            input.RemoveAt(0);
            return;
        }
        
        Item item = new();
        
        if (itemType.Contains("GDP"))
        {
            HandlerGDP(item, input);
            input.RemoveAt(0);
        }
        else if (itemType.Contains("UK") || itemType.Contains("UKG"))
        {
            HandlerBlood(item, input);
            input.RemoveAt(0);
        }
        else if (itemType.Contains("PDC"))
        {
            HandlerPDC(item, input);
            input.RemoveAt(0);
        }
        else if (itemType.Contains("SWL"))
        {
            HandlerSWL1(item, input);
            item.SetDate(input[0][0], month, year);
            items.Add(item);

            item = new Item();
            HandlerSWL2(item, input);
            input.RemoveRange(0, 7);
        }
        else if (Regex.IsMatch(itemType, @"^[A-Za-z]?\d{1,3}/\d{1,3}[A-Za-z]?/\d{1}$"))
        {
            HandlerTwoLine(item, input);
            input.RemoveRange(0, 2);
        }
        else
        {
            HandlerOneLine(item, input);
            input.RemoveAt(0);
        }
        
        item.SetDate(input[0][0], month, year);
        items.Add(item);
    }
}
