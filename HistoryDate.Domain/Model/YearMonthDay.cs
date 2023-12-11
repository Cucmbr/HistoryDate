namespace HistoryDate.Domain.Model;

public class YearMonthDay : HistoryDate, IAnnoDomini
{
    public long Year { get; set; }
    public int Month { get; set; } //в этом и других классах нет возможности задавать presumably и approximation
    public int Day { get; set; } // нужно реализовать проверку на правильность даты. Например, если количество дней больше 31, то неправильная дата, аналогично с месяцами.
    public bool AD { get; set; }
    
    public YearMonthDay() 
    {
        if (JsonFormat != string.Empty)
        {
            FromJson();
        }

        CalcInterval();
    }

    public YearMonthDay(long year, int month, int day, bool AD = true)
    {
        Year = year;
        Month = month;
        Day = day;
        this.AD = AD;

        CalcInterval();
    }

    public YearMonthDay(long year, int month, bool AD = true)
    {
        Year = year;
        Month = month;
        this.AD = AD;

        CalcInterval();
    }

    public YearMonthDay(long year, bool AD = true)
    {
        Year = year;
        this.AD = AD;

        CalcInterval();
    }

    public override void CalcInterval() // не доделан
    {
        if (Year == 0 || (Month == 0 && Day != 0))
        {
            throw new Exception("Year is zero or day has no month. Error!");
        }
        else if(AD)
        {
            if (Day != 0 && Month != 0)
            {
                Begin = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
                End = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
            }
            else if(Month != 0)
            {
                Begin = new Date { Year = Year, Month = Month, Day = 1, AD = AD };
                End = new Date { Year = Year, Month = Month, Day = DateTime.DaysInMonth((int)Year, Month), AD = AD };
            }
            else
            {
                Begin = new Date { Year = Year, Month = 1, Day = 1, AD = AD };
                End = new Date { Year = Year, Month = 12, Day = 31, AD = AD };
            }
        }
        else if(!AD)
        {
            
        }
    }

    public override void FromJson()
    {
        
    }

    public override string ToString()
    {
        if (AD)
            return $"{(Day == 0 ? "" : Day + ".")} {(Month == 0 ? "" : Month + ".")} {(Year == 0 ? "" : Year + ".")}"; // решение-затычка, не универсально
        else
            return "Not implemented.";
    }
}
