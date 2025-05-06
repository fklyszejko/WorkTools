using System.IO;
using System.Text;

namespace Schedule;

public static class FileOperation
{
    public static string FormatCSV(List<Item> items)
    {
        StringBuilder output = new();

        foreach(Item item in items)
        {
            StringBuilder text = new();
            text.Append(item.StartDate.ToString("MM/dd/yyyy"));
            text.Append(',');
            text.Append(item.Subject);
            text.Append(',');
            text.Append(item.StartTime.ToString("hh:mm"));
            text.Append(',');
            text.Append(item.EndDate.ToString("MM/dd/yyyy"));
            text.Append(',');
            text.Append(item.EndTime.ToString("hh:mm"));
            text.Append(',');
            text.Append(item.Description);
            text.Append(',');
            text.Append(item.Location);
            text.Append(',');
            text.Append(item.AllDayEvent);

            output.Append(text);
        }

        return output.ToString();
    }

    public static void SaveFile(string text)
    {
        string fileName = "test.csv";
        string header = "Start date,Subject,Start Time,End Date,End Time,Description,Location,All Day Event";
        
        using (StreamWriter output = System.IO.File.CreateText(fileName))
        {
            output.WriteLine(header);
            output.Write(text);
        }
    }

}
