using System.Text.RegularExpressions;
using static Schedule.ItemHandler;

namespace Schedule;

public static class ItemGeneration
{
    private const int DateIndex = 0;
    private const int ItemTypeIndex = 1;
    private const int TimeIndex = 2;
    private const int Row = 0;

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
        if (input[Row].Count <= 2)
        {
            input.RemoveAt(0);
            return;
        }

        string time = input[Row][TimeIndex];
        string itemType = input[Row][ItemTypeIndex];
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

        item.SetDate(input[Row][DateIndex], month, year);
        input.RemoveRange(0, lineToRemove);
        items.Add(item);
    }
}
