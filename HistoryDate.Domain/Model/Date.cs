namespace HistoryDateLib.Domain.Model;

public class Date : IAnnoDomini
{
    //bool IsBegin { get; set; }
    public Guid id { get; set; }
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD {  get; set; } = true;
}
