using System.Text.RegularExpressions;

namespace Schedule;

public static class ItemValidator
{
    private static bool IsDepotNameWithEnding(string place, string ending)
    {
        return place.StartsWith("R") && place.EndsWith(ending);
    }
    
    public static bool IsStartPlaceDepotName(string startPlace)
    {
        return IsDepotNameWithEnding(startPlace, "00");
    }

    public static bool IsEndPlaceDepotName(string endPlace)
    {
        return IsDepotNameWithEnding(endPlace, "99");
    }

    public static bool IsValidTime(string time)
    {
        string pattern = @"^\d{1,2}:\d{1,2}-\d{1,2}:\d{1,2}$";
        return Regex.IsMatch(time, pattern);
    }

    public static void ValidTimesAreNotEqual(TimeOnly startTime, TimeOnly endTime)
    {
        if (startTime == endTime)
        {
            throw new InvalidOperationException("Godzina początkowa i końcowa nie mogą być takie same.");
        }
    }

}
