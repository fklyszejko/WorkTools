namespace Schedule;

public static class Schedule
{
    public static string GenerateItemFromSchedule(string text, string month, string year)
    {
        ValidInput(text);
        TextToList(text);

        return "";

    }



    public static void ValidInput(string text)
    {
        if(string.IsNullOrEmpty(text))
        {
            throw new InvalidDataException("Nieprawidłowe dane");
        }
    }

    private static List<List<string>>? TextToList(string text)
    {
        List<List<string>> list = new();

        string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string[] columns = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> row = new List<string>(columns);
            list.Add(row);
        }

        return list;
    }

}
