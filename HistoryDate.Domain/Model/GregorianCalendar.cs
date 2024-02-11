using System.Text.Json;
using System.Text.Json.Serialization;

namespace HistoryDateLib.Domain.Model;

public class GregorianCalendar : HistoryDate, IAnnoDomini
{
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD { get; set; } = true;

    public GregorianCalendar(long year, int month, int day, bool AD = true)
    {
        Year = year;
        Month = month;
        Day = day;
        this.AD = AD;

        CalcInterval();
    }

    public GregorianCalendar(long year, int month, bool AD = true)
    {
        Year = year;
        Month = month;
        this.AD = AD;

        CalcInterval();
    }

    public GregorianCalendar(long year, bool AD = true)
    {
        Year = year;
        this.AD = AD;

        CalcInterval();
    }

    public bool IsValidDate()
    {
        if (Year == 0 || (Month == 0 && Day != 0))
        {
            return false;
        }
        else if (Month > 12 || Month < 0)
        {
            return false;
        }
        else if (Day > 31 || Day < 0)
        {
            return false;
        }

        if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
        { 
            if (Day > 31)
                return false;
        }
        else if (Month == 2)
        {
            if (Year % 400 == 0 || (Year % 4 == 0 && Year % 100 != 0))
            {
                if (Day > 29)
                    return false;
            }
            else
            {
                if (Day > 28)
                    return false;
            }
        }
        else
        {
            if (Day > 30)
                return false;
        }

        return true;
    }

    public override void CalcInterval()
    {
        if (!IsValidDate())
        { 
            throw new InvalidDataException("Invalid YMD Date");
        }

        if (AD)
        {
            if (Day != 0 && Month != 0)
            {
                Begining = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
                End = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
            }
            else if (Month != 0)
            {
                Begining = new Date { Year = Year, Month = Month, Day = 1, AD = AD };
                End = new Date { Year = Year, Month = Month, Day = DateTime.DaysInMonth((int)Year, Month), AD = AD };
            }
            else
            {
                Begining = new Date { Year = Year, Month = 1, Day = 1, AD = AD };
                End = new Date { Year = Year, Month = 12, Day = 31, AD = AD };
            }

        }
        else
        {
            Begining = new Date { Year = Year, Month = 1, Day = 1, AD = false };
            End = new Date { Year = Year, Month = 12, Day = 31, AD = false };
        }
    }

    public override void ToJson()
    {
        JsonFormat = JsonSerializer.Serialize(this);
    }
    public override void FromJson()
    {
        var temp = JsonSerializer.Deserialize<GregorianCalendar>(JsonFormat)!;
        Year = temp.Year;
        Month = temp.Month;
        Day = temp.Day;
        AD = temp.AD;
    }

    public override string ToString()
    {
        if (AD)
            return $"{(Day == 0 ? "" : Day + ".")} {(Month == 0 ? "" : Month + ".")} {(Year == 0 ? "" : Year + ".")}";
        else
            return $"{Year} г. до н. э.";
    }
}
