using Xunit;

namespace ScheduleTests;

public class ScheduleItemHandlerTests
{

    [Fact]
    public void SetsCorrectPropertiesForGDPItem()
    {
        Item item = new();
        List<List<string>>? list = new() { new() { "data1", "GDP", "12:00-14:00" } };

        ItemHandler.HandlerGDP(item, list);

        Assert.Equal(TimeOnly.Parse("12:00"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("14:00"), item.EndTime);
        Assert.Equal("Dyżur", item.Subject);
        Assert.Equal("Sprawdź wyprawkę.", item.Description);
        Assert.Equal("", item.Location);
    }

    [Fact]
    public void SetsCorrectPropertiesForBloodItem()
    {
        Item item = new();
        List<List<string>>? list = new() { new() { "data1", "Krwiodawstwo", "12:00-14:00" } };

        ItemHandler.HandlerBlood(item, list);

        Assert.Equal(TimeOnly.Parse("12:00"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("14:00"), item.EndTime);
        Assert.Equal("Krwiodawstwo", item.Subject);
        Assert.Equal("", item.Description);
        Assert.Equal("Centrum Krwiodawstwa i Krwiolecznictwa", item.Location);
    }

    [Fact]
    public void SetsCorrectPropertiesForPDCItem()
    {
        Item item = new();
        List<List<string>>? list = new() { new() { "data1", "Podciąganie / WIA", "12:00-14:00" } };

        ItemHandler.HandlerPDC(item, list);

        Assert.Equal(TimeOnly.Parse("12:00"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("14:00"), item.EndTime);
        Assert.Equal("Podciąganie/WIA", item.Subject);
        Assert.Equal("Skontaktuj się z dyspozytorem!", item.Description);
    }

    [Fact]
    public void SetsCorrectPropertiesForSWL()
    {
        Item item = new();

        List<List<string>>? list = new() {
            new() { "data1", "SWL1", "06:49-16:10" },
            new() { "R2(P) 00", "GOCŁAWEK 05", "R2(P) 99" },
            new() {"WIATRACZNA 11","P+R AL.KRAKOWSKA","RONDO WASZYNGTONA 05"},
            new() {},
            new() { "9","027","06:49","10:34" },
            new() {},
            new() { "3","5","11:29","16:10" }
        };

        ItemHandler.HandlerSWL1(item, list);

        Assert.Equal(TimeOnly.Parse("06:49"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("10:34"), item.EndTime);
        Assert.Equal("9/027", item.Subject);
        Assert.Equal("R2 -> GOCŁAWEK 05", item.Location);
        Assert.Equal("Zakończenie: R2", item.Description);

        ItemHandler.HandlerSWL2(item, list);

        Assert.Equal(TimeOnly.Parse("11:29"), item.StartTime);
        Assert.Equal(TimeOnly.Parse("16:10"), item.EndTime);
        Assert.Equal("3/5", item.Subject);
        Assert.Equal("WIATRACZNA 11 -> P+R AL.KRAKOWSKA", item.Location);
        Assert.Equal("Zakończenie: RONDO WASZYNGTONA 05", item.Description);
    }



}