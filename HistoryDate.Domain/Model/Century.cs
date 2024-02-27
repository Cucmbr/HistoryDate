using System.Text.Json;

namespace HistoryDateLib.Domain.Model;

public enum CenturyPart
{
    FirstHalf = 2,
    LastHalf = 12,
    FirstThird = 3,
    SecondThird = 13,
    LastThird = 23,
    FirstQuarter = 4,
    SecondQuarter = 14,
    ThirdQuarter = 24,
    LastQuarter = 34,
    FirstDecade = 10,
    SecondDecade = 110,
    ThirdDecade = 210,
    FourthDecade = 310,
    FifthDecade = 410,
    SixthDecade = 510,
    SeventhDecade = 610,
    EighthDecade = 710,
    NinethDecade = 810,
    LastDeacde = 910,
    NotDefined = 1
}

public class Century : HistoryDate, IAnnoDomini
{
    public int Value { get; set; }
    public bool AD { get; set; } = true;
    public CenturyPart Part { get; set; } = CenturyPart.NotDefined;

    public Century()
    {
    }

    public Century(int val) // нет способа определения AD
    {
        Value = val;
    }

    public Century(int val, CenturyPart part, bool AD = true)
    {
        Value = val;
        Part = part;
        this.AD = AD;
    }

    private int[] MNCalculator()
    {
        int partCode = (int)Part;
        if (partCode % 10 == 0)
        {
            return [partCode / 100, 10];
        }
        else if (partCode < 10)
        {
            return [0, partCode];
        }
        else
        {
            return [partCode / 10, partCode % 10];
        }
    }

    public override void CalcInterval()
    {
        int centuryUtility = (Value - 1) * 100 + 1;

        if (Value == 0)
        {
            throw new InvalidDataException("Invalid century value");
        }

        int[] mn = MNCalculator();
        Begining.Year = centuryUtility + (100 * mn[0] / mn[1]); 
        Begining.Month = 1; 
        Begining.Day = 1; 
        Begining.AD = AD;

        End.Year = centuryUtility + (100 * (mn[0] + 1)) / mn[1] - 1; 
        End.Month = 12; 
        End.Day = 31; 
        End.AD = AD;
    }

    public override void ToJson()
    {
        JsonFormat = JsonSerializer.Serialize(this);
    }

    public override void FromJson()
    {
        throw new NotImplementedException();
    }
}