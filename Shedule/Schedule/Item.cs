using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Schedule;

public class Item
{

    public TimeOnly StartTime { get; set; }  = TimeOnly.MinValue;
    public TimeOnly EndTime { get; set; } = TimeOnly.MinValue;
    public DateOnly StartDate { get; set; } = DateOnly.MinValue;
    public DateOnly EndDate { get; set; } = DateOnly.MinValue;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public bool AllDayEvent { get; } = false;


    public Item()
    {
    }

    private static int ExtractDayNumber(string input)
    {
        string pattern = @"\d+";

        Match match = Regex.Match(input, pattern);

        if(match.Success)
        {
            return int.Parse(match.Value);
        }
        else
        {
            throw new ArgumentException("Nie znaleziono liczby w wprowadzonym tekście.");
        }
    }

    public void SetTime(string time)
    {
        string pattern = @"^\d{1,2}:\d{1,2}-\d{1,2}:\d{1,2}$";

        if (Regex.IsMatch(time, pattern))
        {
            string[] times = time.Split('-');
            StartTime = TimeOnly.Parse(times[0]);
            EndTime = TimeOnly.Parse(times[1]);
        }
        else
        {
            return;
        }
    }

    public void SetTime(string startTime, string endTime)
    {
        StartTime = TimeOnly.Parse(startTime);
        EndTime = TimeOnly.Parse(endTime);
    }
    public void SetDate(string day, string month, string year)
    {
        int dayInt = ExtractDayNumber(day);

        if (StartTime == EndTime)
        {
            throw new InvalidOperationException("Godzina początkowa i końcowa nie mogą być takie same.");
        }

        if (!int.TryParse(month, out int monthInt) || !int.TryParse(year, out int yearInt))
        {
            throw new ArgumentException("Błędne parametry daty");
        }


        StartDate = new(yearInt, monthInt, dayInt);

        EndDate = (StartTime > EndTime) ? StartDate.AddDays(1) : StartDate;

    }
    public void SetDescription(string endPlace)
    {
        if (endPlace.StartsWith("R") && endPlace.EndsWith("99"))
        {
            endPlace = endPlace[..2];
        }

        Description = $"Zakończenie: {endPlace}";
    }
    public void SetLocation(string startPlace, string direction)
    {
        if (startPlace.StartsWith("R") && startPlace.EndsWith("00"))
        {
            startPlace = startPlace[..2];
        }

        Location = $"{startPlace} -> {direction}";
    }

    public void SetSubject(string subject)
    {
        Subject = subject;
    }

    public void SetSubject(string line, string brigade)
    {
        Subject = $"{line}/{brigade}";
    }
}
