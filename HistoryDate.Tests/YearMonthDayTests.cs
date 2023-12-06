using HistoryDate.Domain.Model;

namespace HistoryDate.Tests
{
    public class YearMonthDayTests
    {
        [Theory]
        [InlineData (1)]
        [InlineData (1000)]
        [InlineData (2025)]
        public void hasCalculatedOneYearIntervalCorrectly(long year)
        {
            var YMD = new YearMonthDay(year);
            
            YMD.CalcInterval();
            
            if (YMD.AD)
            {
                Assert.Equal(year, YMD.Begin.Year);
                Assert.Equal(1, YMD.Begin.Day);
                Assert.Equal(1, YMD.Begin.Month);

                Assert.Equal(year, YMD.End.Year);
                Assert.Equal(31, YMD.End.Day);
                Assert.Equal(12, YMD.End.Month);
            }
        }
    }
}