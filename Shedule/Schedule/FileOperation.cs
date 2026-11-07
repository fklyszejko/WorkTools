using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms.Design;

namespace Schedule;

public static class FileOperation
{
    public static string FormatCSV(List<Item> items)
    {
        CultureInfo cultureSettings = CultureInfo.InvariantCulture;

        StringBuilder output = new();

        foreach(Item item in items)
        {
            StringBuilder text = new();
            text.Append(item.StartDate.ToString("MM/dd/yyyy",cultureSettings));
            text.Append(',');
            text.Append(item.Subject);
            text.Append(',');
            text.Append(item.StartTime.ToString("HH:mm"));
            text.Append(',');
            text.Append(item.EndDate.ToString("MM/dd/yyyy",cultureSettings));
            text.Append(',');
            text.Append(item.EndTime.ToString("HH:mm"));
            text.Append(',');
            text.Append(item.Description);
            text.Append(',');
            text.Append(item.Location);
            text.Append(',');
            text.Append(item.AllDayEvent);

            output.AppendLine(text.ToString());
        }

        return output.ToString();
    }

    public static bool SaveFile(string text,int month, int year)
    {
        string fileName = FileName(month, year);
        fileName = GetUniqueFileName(fileName);
        string header = "Start date,Subject,Start Time,End Date,End Time,Description,Location,All Day Event";
        
        using (StreamWriter output = File.CreateText(fileName))
        {
            output.WriteLine(header);
            output.Write(text);
        }

        return true;
    }

    private static string GetUniqueFileName(string fileName)
    {
            if (!File.Exists(fileName))
            {
                return fileName;
            }

            string directory = Path.GetDirectoryName(fileName) ?? string.Empty;
            string name = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);

            int number = 1;
            string newFileName;

            do
            {
                newFileName = Path.Combine(
                    directory,
                    $"{name}_{number}{extension}");

                number++;
            }
            while (File.Exists(newFileName));

            return newFileName;
    }
    private static string FileName(int month, int year, string? format = "csv")
    {
        if(month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Miesiąc musi być w zakresie od 1 do 12.");
        }

        string[] months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        string monthText = months[month - 1];
        string yearText = year.ToString();
        
        return $"{monthText}_{yearText}.{format}";
    }
}
