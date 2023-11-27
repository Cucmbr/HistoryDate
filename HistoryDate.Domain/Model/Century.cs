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
        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
    }

    public override void CalcInterval()
    {
        //calculate interval
    }

    public override void FromJson()
    {

    }

    public override void ToJson()
    {

    }
}
