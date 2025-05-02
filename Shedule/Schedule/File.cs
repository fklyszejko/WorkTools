using System.IO;

namespace Schedule;
public static class File
{
    public static void SaveFile(string text)
    {
        string fileName = "test.csv";
        string header = "Start date,Subject,Start Time, End Date,End Time, Description, Location, All Day Event";
        
        using (StreamWriter output = System.IO.File.CreateText(fileName))
        {
            output.WriteLine(header);
            output.Write(text);
        }
    }

}
