﻿namespace HistoryDate.Domain.Model;

public class YearMonthDay : HistoryDate, IAnnoDomini
{
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD { get; set; } = true;
    
    public YearMonthDay() 
    {
        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
    }

    public YearMonthDay(long year, int month, int day)  // нет способа определения AD
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

    public override void CalcInterval() // не доделан
    {
        if (Year == 0 && (Month == 0 && Day != 0))
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
                Begin = new Date { Year = Year, Month = 12, Day = 31, AD = AD };
            }
        }
        else if(!AD)
        {
            // проконсультроваться с Пал Санычем!
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
