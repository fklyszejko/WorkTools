using System.Text.RegularExpressions;
using static Schedule.ItemHandler;

namespace Schedule;

public static class ItemGeneration
{
    public static List<Item> GenerateItemFromSchedule(string text, int month, int year)
    {
        List<List<string>> input = DataConversion.ConvertTextToDataList(text);
        List<Item> items = new();

        while (input.Count > 0)
        {
            ProcessItemCondition(input, items, month, year);
        }

        return items;
    }

    private static void ProcessItemCondition(List<List<string>> input, List<Item> items, int month, int year)
    {
        if (input[0].Count <= 2)
        {
            input.RemoveAt(0);
            return;
        }

        string time = input[0][2];
        string itemType = input[0][1];
        int lineToRemove = 1;

        if (string.IsNullOrEmpty(time))
        {
            input.RemoveAt(0);
            return;
        }

        Item item = new();

        if (itemType.Contains("GDP"))
        {
            HandlerGDP(item, input);
        }
        else if (itemType.Contains("UK") || itemType.Contains("UKG"))
        {
            HandlerBlood(item, input);
        }
        else if (itemType.Contains("PDC"))
        {
            HandlerPDC(item, input);
        }
        else if (itemType.Contains("SWL"))
        {
            HandlerSWL1(item, input);
            item.SetDate(input[0][0], month, year);
            items.Add(item);

            item = new Item();
            HandlerSWL2(item, input);
            lineToRemove = 7;
        }
        else if (Regex.IsMatch(itemType, @"^[A-Za-z]?\d{1,3}/\s?\d{1,3}[A-Za-z]?/\d{1}$"))
        {
            HandlerTwoLine(item, input);
            lineToRemove = 2;
        }
        else
        {
            HandlerOneLine(item, input);
        }

        item.SetDate(input[0][0], month, year);
        input.RemoveRange(0, lineToRemove);
        items.Add(item);
    }
}
