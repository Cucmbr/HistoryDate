using System.Text.Json;

namespace HistoryDateLib.Domain.Model;

public enum MillenniumPart
{
    FirstHalf = 2,
    LastHalf = 12,
    FirstThird = 3,
    SecondThird = 13,
    LastThird = 23,
    NotDefined = 1,
}

public class Millennium : HistoryDate, IAnnoDomini
{
    public int Value { get; set; }
    public bool AD { get; set; } = true;
    public MillenniumPart Part { get; set; } = MillenniumPart.NotDefined;

    public Millennium()
    {
    }

    public Millennium(int val )
    {
        Value = val;
    }
    public Millennium(int val, MillenniumPart part, bool AD = true) 
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
        int millenniumUtility = (Value - 1) * 1000 + 1;

        if (Value == 0)
        {
            throw new InvalidDataException("Invalid millennium value");
        }

        int[] mn = MNCalculator();
        Begining.Year = millenniumUtility + (1000 * mn[0] / mn[1]);
        Begining.Month = 1;
        Begining.Day = 1;
        Begining.AD = AD;

        End.Year = millenniumUtility + (1000 * (mn[0] + 1)) / mn[1] - 1;
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