using Schedule;

namespace ScheduleTests;

public class ScheduleTests
{
    [Fact(DisplayName = "Validate input")]
    public void ValidateInputTest()
    {
        string text = "";

        Assert.Throws<InvalidDataException>(() =>
        {
            Schedule.Schedule.ValidInput(text);
        });
    }
}
