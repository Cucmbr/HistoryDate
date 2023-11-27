namespace HistoryDate.Domain.Model;

public class YearMonthDay : HistoryDate, IAnnoDomini
{
    public long Year { get; set; }
    public int? Month { get; set; }
    public int? Day { get; set; }
    public bool AD { get; set; } = true;

    public YearMonthDay()
    {
        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
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
        if (Month != null && Day != null)
        {
            Begin = new Date { Year = Year, Month = (int)Month, Day = (int)Day };
            End = new Date { Year = Year, Month = (int)Month, Day = (int)Day };
            if (!AD)
            {
                Begin.AD = false;
                End.AD = false;
            }
            //через шаблоны (сопоставление с образцом)
        }
        else if()
        {

        }
    }

    public override void FromJson()
    {
        
    }

    public override string ToString()
    {

        return "";
    }
}
