using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schedule.ItemGeneration;

namespace ScheduleTests;

public class ItemGenerator
{
    [Fact]
    public static void GenerateItemFromSchedule_ValidInput_ReturnsCorrectItems()
    {
        string input = @"1 Cz	WT	 	 	 	 	 	 	 		
2 Pi	WS	 	 	 	 	 	 	 		
3 So	19/ 122/2	10:13-20:12		
WIATRACZNA 41	PRZYJAZD	R7(P) 99
4 Ni	19/ 96/3	14:17-00:17
GOCŁAWEK 15	PRZERWA	R7(P) 99
13 Wt	SWL/ 4/1	06:49-16:10		
R7(P) 00	GOCŁAWEK 05	R7(P) 99
KIJOWSKA 94	ANNOPOL 92	WIATRACZNA 94
Linia	Br.	Od	Do
19	927	05:49	10:34
SWL	4	10:34	13:29
43	5	13:29	18:10

15 Cz	PDC/WIA/1	04:41-13:30		
27 Wt	NN	13:25-22:57
28 Sr	GDP	13:25-22:57	 	 	 
29 Cz	UKG	13:25-22:57
30 Pt	BHP	13:25-22:57
";
        int month = 10;
        int year = 2023;

        List<Item> results = GenerateItemFromSchedule(input, month, year);

        Assert.NotNull(results);
        Assert.Equal(9, results.Count);

        Assert.Equal("19/122", results[0].Subject);
        Assert.Equal("WIATRACZNA 41 -> PRZYJAZD", results[0].Location);
        Assert.Equal("Zakończenie: R7", results[0].Description);
        Assert.Equal(new DateOnly(2023, 10, 3), results[0].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 3), results[0].EndDate);
        Assert.Equal(new TimeOnly(10, 13), results[0].StartTime);
        Assert.Equal(new TimeOnly(20, 12), results[0].EndTime);

        Assert.Equal("19/96", results[1].Subject);
        Assert.Equal("GOCŁAWEK 15 -> PRZERWA", results[1].Location);
        Assert.Equal("Zakończenie: R7", results[1].Description);
        Assert.Equal(new DateOnly(2023, 10, 4), results[1].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 5), results[1].EndDate);
        Assert.Equal(new TimeOnly(14, 17), results[1].StartTime);
        Assert.Equal(new TimeOnly(0, 17), results[1].EndTime);

        Assert.Equal("19/927", results[2].Subject);
        Assert.Equal("R7 -> GOCŁAWEK 05", results[2].Location);
        Assert.Equal("Zakończenie: R7", results[2].Description);
        Assert.Equal(new DateOnly(2023, 10, 13), results[2].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 13), results[2].EndDate);
        Assert.Equal(new TimeOnly(5, 49), results[2].StartTime);
        Assert.Equal(new TimeOnly(10,34), results[2].EndTime);
        Assert.Equal("43/5", results[3].Subject);
        Assert.Equal("KIJOWSKA 94 -> ANNOPOL 92", results[3].Location);
        Assert.Equal("Zakończenie: WIATRACZNA 94", results[3].Description);
        Assert.Equal(new DateOnly(2023, 10, 13), results[3].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 13), results[3].EndDate);
        Assert.Equal(new TimeOnly(13, 29), results[3].StartTime);
        Assert.Equal(new TimeOnly(18, 10), results[3].EndTime);

        Assert.Equal("Podciąganie/WIA", results[4].Subject);
        Assert.Equal("Skontaktuj się z dyspozytorem!", results[4].Description);
        Assert.Equal(new DateOnly(2023, 10, 15), results[4].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 15), results[4].EndDate);
        Assert.Equal(new TimeOnly(4, 41), results[4].StartTime);
        Assert.Equal(new TimeOnly(13, 30), results[4].EndTime);

        Assert.Equal("NN", results[5].Subject);
        Assert.Equal("", results[5].Description);
        Assert.Equal(new DateOnly(2023, 10, 27), results[5].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 27), results[5].EndDate);
        Assert.Equal(new TimeOnly(13, 25), results[5].StartTime);
        Assert.Equal(new TimeOnly(22, 57), results[5].EndTime);

        Assert.Equal("Dyżur", results[6].Subject);
        Assert.Equal("Sprawdź wyprawkę.", results[6].Description);
        Assert.Equal(new DateOnly(2023, 10, 28), results[6].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 28), results[6].EndDate);
        Assert.Equal(new TimeOnly(13, 25), results[6].StartTime);
        Assert.Equal(new TimeOnly(22, 57), results[6].EndTime);

        Assert.Equal("Krwiodawstwo", results[7].Subject);
        Assert.Equal("Centrum Krwiodawstwa i Krwiolecznictwa", results[7].Location);
        Assert.Equal(new DateOnly(2023, 10, 29), results[7].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 29), results[7].EndDate);
        Assert.Equal(new TimeOnly(13, 25), results[7].StartTime);
        Assert.Equal(new TimeOnly(22, 57), results[7].EndTime);

        Assert.Equal("BHP", results[8].Subject);
        Assert.Equal("", results[8].Description);
        Assert.Equal(new DateOnly(2023, 10, 30), results[8].StartDate);
        Assert.Equal(new DateOnly(2023, 10, 30), results[8].EndDate);
        Assert.Equal(new TimeOnly(13, 25), results[8].StartTime);
        Assert.Equal(new TimeOnly(22, 57), results[8].EndTime);
        Assert.Equal("", results[8].Location);




    }
}
