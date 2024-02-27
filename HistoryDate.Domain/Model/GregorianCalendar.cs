using System.Text.Json;

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
                Begining.Year = Year;
                Begining.Month = Month;
                Begining.Day = Day;
                Begining.AD = AD;

                End.Year = Year;
                End.Month = Month;
                End.Day = Day;
                End.AD = AD;
            }
            else if (Month != 0)
            {
                Begining.Year = Year;
                Begining.Month = Month;
                Begining.Day = 1;
                Begining.AD = AD;

                End.Year = Year;
                End.Month = Month;
                End.Day = DateTime.DaysInMonth((int)Year, Month);
                End.AD = AD;
            }
            else
            {
                Begining.Year = Year;
                Begining.Month = 1;
                Begining.Day = 1;
                Begining.AD = AD;

                End.Year = Year;
                End.Month = 12;
                End.Day = 31;
                End.AD = AD;
            }

        }
        else
        {
            Begining.Year = Year;
            Begining.Month = 1;
            Begining.Day = 1;
            Begining.AD = AD;

            End.Year = Year;
            End.Month = 12;
            End.Day = 31;
            End.AD = AD;
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