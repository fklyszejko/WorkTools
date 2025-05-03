using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule;

public static class ItemHandler
{
    public static void HandlerGDP(Item item, List<List<string>> list)
    {
        item.SetTime(time: list[0][2]);
        item.Subject = "Dyżur";
        item.Description = "Sprawdź wyprawkę.";
        item.Location = Properties.Settings.Default.depot;
    }

    public static void HandlerBlood(Item item, List<List<string>> list)
    {
        item.SetTime(time: list[0][2]);
        item.Subject = "Krwiodawstwo";
        item.Location = "Centrum Krwiodawstwa i Krwiolecznictwa";
    }

    public static void HandlerPDC(Item item, List<List<string>> list)
    {
        item.SetTime(time: list[0][2]);
        string[] subject = list[0][1].Split('/');
        item.SetSubject(line: "Podciąganie", subject[1].Trim());
        item.Description = "Skontaktuj się z dyspozytorem.";
    }


    public static void HandlerSWL1(Item item, List<List<string>> list)
    {
        item.SetTime(startTime: list[4][2], endTime: list[4][3]);
        item.SetSubject(line: list[4][0], brigade: list[4][1]);
        item.SetLocation(startPlace: list[1][0], direction: list[1][1]);
        item.SetDescription(endPlace: list[1][2]);
    }

    public static void HandlerSWL2(Item item, List<List<string>> list)
    {
        item.SetTime(startTime: list[6][2], endTime: list[6][3]);
        item.SetSubject(line: list[6][0], brigade: list[6][1]);
        item.SetLocation(startPlace: list[2][0], direction: list[2][1]);
        item.SetDescription(endPlace: list[2][2]);
    }

    public static void HandlerTwoLine(Item item, List<List<string>> list)
    {
        item.SetTime(time: list[0][2]);
        string[] subject = list[0][1].Split('/');
        item.SetSubject(line: subject[0].Trim(), brigade: subject[1].Trim());
        item.SetLocation(startPlace: list[1][0], direction: list[1][1]);
        item.SetDescription(endPlace: list[1][2]);
    }

    public static void HandlerOneLine(Item item, List<List<string>> list)
    {
        item.SetTime(time: list[0][2]);
        string[] subject = list[0][1].Split('/');
        item.SetSubject(subject: subject[0].Trim());
    }
}
