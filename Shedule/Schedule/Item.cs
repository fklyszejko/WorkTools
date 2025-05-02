using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Schedule;

public class Item : IDisposable
{
    private TimeOnly _startTime;
    private TimeOnly _endTime;
    private DateOnly _startDate;
    private DateOnly _endDate;
    private string _description;
    private string _location;
    private string _subject;


    public Item()
    {
        _startTime = TimeOnly.MinValue;
        _endTime = TimeOnly.MinValue;
        _startDate = DateOnly.MinValue;
        _endDate = DateOnly.MinValue;
        _description = string.Empty;
        _location = string.Empty;
        _subject = string.Empty;
    }


    public TimeOnly StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }
    public TimeOnly EndTime
    {
        get { return _endTime; }
        set { _endTime = value; }
    }
    public DateOnly StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    public DateOnly EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
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
        if (StartTime == EndTime)
        {
            throw new InvalidOperationException("Godzina początkowa i końcowa nie mogą być takie same.");
        }

        if (!int.TryParse(day, out int dayInt) || !int.TryParse(month, out int monthInt) || !int.TryParse(year, out int yearInt))
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


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
