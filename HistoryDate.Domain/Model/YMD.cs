using System.Drawing;

namespace HistoryDate.Domain.Model;

public class YearMonthDay : HistoryDate
{
    public long Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }

    public YearMonthDay()
    {
        
    }

    public YearMonthDay(long year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public YearMonthDay(long year, int month)
    {
        Year = year;
        Month = month;
    }

    public YearMonthDay(long year)
    {
        Year = year;
    }

    public override void CalcInterval()
    {
        //calculate interval
    }
}
