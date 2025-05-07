using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Schedule.ItemValidator;

namespace Schedule;

public class Item
{

    public TimeOnly StartTime { get; set; } = TimeOnly.MinValue;
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

        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        else
        {
            throw new ArgumentException($"Nie znaleziono liczby w wprowadzonym tekście '{input}'");
        }
    }

    public void SetTime(string time)
    {
        if (IsValidTime(time))
        {
            string[] times = time.Split('-');
            StartTime = TimeOnly.Parse(times[0]);
            EndTime = TimeOnly.Parse(times[1]);
        }
        else
        {
            throw new ArgumentException($"Niepoprawny format czasu: {time}. Oczekiwany format: HH:mm-HH:mm");
        }
    }

    public void SetTime(string startTime, string endTime)
    {
        StartTime = TimeOnly.Parse(startTime);
        EndTime = TimeOnly.Parse(endTime);
    }
    public void SetDate(string day, int month, int year)
    {
        int dayInt = ExtractDayNumber(day);

        ValidTimesAreNotEqual(StartTime, EndTime);

        StartDate = new(year, month, dayInt);

        EndDate = (StartTime > EndTime) ? StartDate.AddDays(1) : StartDate;

    }
    public void SetDescription(string endPlace)
    {
        if (IsEndPlaceDepotName(endPlace))
        {
            endPlace = endPlace[..2];
        }

        Description = $"Zakończenie: {endPlace}";
    }
    public void SetLocation(string startPlace, string direction)
    {
        if (IsStartPlaceDepotName(startPlace))
        {
            startPlace = startPlace[..2];
        }

        Location = $"{startPlace} -> {direction}";
    }

    public void SetSubject(string subject)
    {
        string[] parts = subject.Split('/');

        if (parts.Length > 1)
        {
            string line = parts[0].Trim();
            string brigade = parts[1].Trim();

            SetSubject(line, brigade);
        }
        else
        {
            Subject = subject.Trim();
        }
    }

    public void SetSubject(string line, string brigade)
    {
        Subject = $"{line}/{brigade}";
    }
}
