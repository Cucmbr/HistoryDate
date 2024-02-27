using System.Text.Json;

namespace HistoryDateLib.Domain.Model;

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
            //Begining = new Date() { Year = Value * 1000 - 999, Month = 1, Day = 1, AD = AD };
            //End = new Date() { Year = Value * 1000, Month = 12, Day = 31, AD = AD }; нужно переделать под новый формат задания свойств
        } // скорее всего не работает с датами до нашей эры
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
