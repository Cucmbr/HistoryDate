namespace HistoryDate.Domain.Model;

public class Date : IAnnoDomini
{
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD {  get; set; } = true;
}
