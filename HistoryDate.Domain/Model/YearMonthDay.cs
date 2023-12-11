namespace HistoryDate.Domain.Model;

public class YearMonthDay : HistoryDate, IAnnoDomini
{
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; } // нужно реализовать проверку на правильность даты. Например, если количество дней больше 31, то неправильная дата, аналогично с месяцами.
    public bool AD { get; set; }
    
    public YearMonthDay() 
    {
        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
    }

    public YearMonthDay(long year, int month, int day, bool AD = true)
    {
        Year = year;
        Month = month;
        Day = day;
        this.AD = AD;
    }

    public YearMonthDay(long year, int month, bool AD = true)
    {
        Year = year;
        Month = month;
        this.AD = AD;
    }

    public YearMonthDay(long year, bool AD = true)
    {
        Year = year;
        this.AD = AD;
    }

    public override void CalcInterval() // не доделан  // саша чето сделала,
                                        // но невыкупает, где вычисляется интервал и как сделать отдельное вычисления для дат д.н.э
    {
       
        if (Year == 0 || (Month == 0 && Day != 0))
        {
            throw new Exception("Year is zero or day has no month. Error!");
        }
        else if(AD)
        {
            if (Month > 12 || Month < 0 )
            {
                throw new Exception("Month > 12 or Month value is negative. Error!");
            }
            else if (Day > 31 || Day < 0)
            {
                throw new Exception("Day > 31 or Day value is negative. Error!");
            }
            else {
                if (Day != 0 && Month != 0)
                {
                    Begin = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
                    End = new Date { Year = Year, Month = Month, Day = Day, AD = AD };
                }
                else if (Month != 0)
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
           
        }
        else if(!AD) // вот тут ужас сделала
        {
            if (Day != 0 && Month != 0)
            {
                Begin = new Date { Year = Year, Month = Month, Day = Day, AD = false };
                End = new Date { Year = Year, Month = Month, Day = Day, AD = false };
            }
            else if (Month != 0)
            {
                Begin = new Date { Year = Year, Month = Month, Day = DateTime.DaysInMonth((int)Year, Month), AD = false };
                End = new Date { Year = Year, Month = Month, Day = Day = 1, AD = false };
            }
            else
            {
                Begin = new Date { Year = Year, Month = 12, Day = 31, AD = false };
                End = new Date { Year = Year, Month = 1, Day = 1, AD = false };
            }

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
