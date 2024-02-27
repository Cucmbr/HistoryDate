using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryDateLib.Domain.Model;

public class HistorySpan
{
    public int Id { get; set; }

    [NotMapped]
    public HistoryDate Begining { get { return HistoryDates[0]; } set { HistoryDates[0] = value; } }

    [NotMapped]
    public HistoryDate End { get { return HistoryDates[1]; } set { HistoryDates[1] = value; } }

    public List<HistoryDate> HistoryDates { get; set; }

    public HistorySpan()
    {
        HistoryDates = [new HistoryDate() { HistorySpanId = Id}, new HistoryDate() { HistorySpanId = Id}];
    }
    public HistorySpan(HistoryDate date1, HistoryDate date2)
    {
        date1.HistorySpan = this;
        date2.HistorySpan = this;
        date1.HistorySpanId = Id;
        date2.HistorySpanId = Id;
        HistoryDates = [date1, date2];
    }
}