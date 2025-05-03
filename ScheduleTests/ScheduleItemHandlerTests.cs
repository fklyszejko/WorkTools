using Xunit;

namespace ScheduleTests;

public class ScheduleItemHandlerTests
{
    [Fact]
    public void SetsCorrectPropertiesForGDPItem()
    {
        Item item = new ();
        List<List<string>>? list = new () { new () { "data1", "GDP", "12:00-14:00" } };

        ItemHandler.HandlerGDP(item, list);

        Assert.Equal(TimeOnly.Parse("12:00"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("14:00"), item.EndTime);
        Assert.Equal("Dyżur", item.Subject);
        Assert.Equal("Sprawdź wyprawkę.", item.Description);
        Assert.Equal("", item.Location);
    }

}