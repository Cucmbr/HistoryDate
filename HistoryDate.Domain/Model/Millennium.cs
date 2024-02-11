using System.Text.Json;

namespace HistoryDate.Domain.Model;

// возможно, нужен енум для разных частей тысячелетия

public class Millennium : HistoryDate, IAnnoDomini
{
    public int Value { get; set; }
    public bool AD { get; set; } = true;

    public Millennium()
    {
    }

    public Millennium(int val ) // нет способа определения AD
    {
        Value = val;
       
    }

    public override void CalcInterval()
    {
        if (Value != 0)
        {
            Begin = new Date() { Year = Value * 1000 - 999, Month = 1, Day = 1, AD = AD };
            End = new Date() { Year = Value * 1000, Month = 12, Day = 31, AD = AD };
        } // скорее всего не работает с датами до нашей эры!
    }

    public override string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
