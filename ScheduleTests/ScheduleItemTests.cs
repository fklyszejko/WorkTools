using Schedule;

namespace ScheduleTests;

public class ScheduleItemTests
{
    [Fact(DisplayName ="Set time from text")]
    public void Time()
    {
        Item item = new();

        item.SetTime("00:21-12:20");

        Assert.Equal(new TimeOnly(0, 21), item.StartTime);
        Assert.Equal(new TimeOnly(12,20), item.EndTime);
    }

    [Fact(DisplayName ="Set date from text")]
    public void Date()
    {
        Item item = new();

        item.SetTime("00:21-12:20");
        item.SetDate("12", "06", "2025");

        Assert.Equal(new DateOnly(2025, 06, 12), item.StartDate);
    }

    [Fact(DisplayName="Set date and add 1 day")]
    public void DateAddDay()
    {
        Item item = new();

        item.SetTime("16:21-01:00");
        item.SetDate("12", "06", "2025");

        Assert.Equal(new DateOnly(2025, 06, 13), item.EndDate);
    }

    [Fact(DisplayName = "Set description when endPlace starts with 'R' and ends with '99'")]
    public void Description()
    {
        Item item = new();

        item.SetDescription("R2(P) 99");

        Assert.Equal("Zakoñczenie: R2", item.Description);
    }

    [Fact(DisplayName = "Set location")]
    public void Location()
    {
        Item item = new();
        
        item.SetLocation("R2(P) 00", "GOC£AWEK 05");

        Assert.Equal("R2 -> GOC£AWEK 05",item.Location);
    }

    [Fact(DisplayName = "Set subject from two variables")]
    public void Subject()
    {
        Item item = new();

        item.SetSubject("12", "2");

        Assert.Equal("12/2", item.Subject);
    }

    [Fact(DisplayName = "Set subject")]
    public void Subject1()
    {
        Item item = new();

        item.SetSubject("Dy¿ur");

        Assert.Equal("Dy¿ur", item.Subject);
    }
}