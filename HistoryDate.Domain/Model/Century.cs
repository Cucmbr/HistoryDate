namespace HistoryDate.Domain.Model;

public enum CenturyPart
{
    Begin,
    End,
    FirstHalf,
    LastHalf,
    FirstThird,
    SecondThird,
    LastThird,
    FirstQuarter,
    SecondQuarter,
    ThirdQuarter,
    LastQuarter,
    FirstDecade,
    SecondDecade,
    ThirdDecade,
    FourthDecade,
    FifthDecade,
    SixthDecade,
    SeventhDecade,
    EighthDecade,
    NinethDecade,
    LastDeacde,
    NotDefined
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



    public override void CalcInterval()
    {
        if (Value != 0)
        {
            Begin = new Date() { Year = Value * 100 - 99, Month = 1, Day = 1, AD = AD };
            End = new Date() { Year = Value * 100, Month = 12, Day = 31, AD = AD };
        } //нужно добавить интервалы с учётом centurypart!

    }
}
