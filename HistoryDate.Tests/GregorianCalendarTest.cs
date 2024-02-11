using HistoryDateLib.Domain.Model;

namespace HistoryDateLib.Tests
{
    public class GregorianCalendarTest
    {
        [Theory]
        [InlineData (1)]
        [InlineData (1000)]
        [InlineData (2025)]
        public void hasCalculatedOneYearIntervalCorrectly(long year)
        {
            var YMD = new GregorianCalendar(year);
            
            YMD.CalcInterval();
            
            if (YMD.AD)
            {
                Assert.Equal(year, YMD.Begining.Year);
                Assert.Equal(1, YMD.Begining.Day);
                Assert.Equal(1, YMD.Begining.Month);

                Assert.Equal(year, YMD.End.Year);
                Assert.Equal(31, YMD.End.Day);
                Assert.Equal(12, YMD.End.Month);
            }
        }
    }
}