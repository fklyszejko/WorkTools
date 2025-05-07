using Schedule;

namespace ScheduleTests;

public class ScheduleItemTests
{
    [Fact]
    public void SetStartAndEndTimeFromText()
    {
        Item item = new();

        item.SetTime("00:21-12:20");

        Assert.Equal(new TimeOnly(0, 21), item.StartTime);
        Assert.Equal(new TimeOnly(12,20), item.EndTime);
    }

    [Fact]
    public void SetStartDateFromText()
    {
        Item item = new();

        item.SetTime("00:21-12:20");
        item.SetDate("12", 06, 2025);

        Assert.Equal(new DateOnly(2025, 06, 12), item.StartDate);
    }

    [Fact]
    public void SetEndDateNextDay()
    {
        Item item = new();

        item.SetTime("16:21-01:00");
        item.SetDate("12", 06, 2025);

        Assert.Equal(new DateOnly(2025, 06, 13), item.EndDate);
    }

    [Fact]
    public void SetDescriptionEndPlaceDepot()
    {
        Item item = new();

        item.SetDescription("R2(P) 99");

        Assert.Equal("Zakoñczenie: R2", item.Description);
    }

    [Fact]
    public void SetLocationStartPlaceDepot()
    {
        Item item = new();
        
        item.SetLocation("R7(GG) 00", "GOC£AWEK 95");

        Assert.Equal("R7 -> GOC£AWEK 95",item.Location);
    }

    [Fact]
    public void SetSubjectTwoString()
    {
        Item item = new();

        item.SetSubject("12", "2");

        Assert.Equal("12/2", item.Subject);
    }

    [Fact]
    public void SetSubjectSimpleString()
    {
        Item item = new();

        item.SetSubject("GDP");

        Assert.Equal("GDP", item.Subject);
    }

    [Fact]
    public void SetSubjectExtendedStringWithLetter()
    {
        Item item = new();
        item.SetSubject("7/027B/4");
        Assert.Equal("7/027B", item.Subject);
    }

    [Fact]
    public void SetSubjectExtendedStringStartWithLetter()
    {
        Item item = new();
        item.SetSubject("C7/027B/4");
        Assert.Equal("C7/027B", item.Subject);
    }
}