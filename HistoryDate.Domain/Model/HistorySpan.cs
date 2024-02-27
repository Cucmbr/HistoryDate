using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryDateLib.Domain.Model;

public class HistorySpan
{
    public int Id { get; set; }

    [NotMapped]
    public HistoryDate Begining { get { return HistoryDates[0]; } set { HistoryDates[0] = value; } }

    [NotMapped]
    public HistoryDate End { get { return HistoryDates[1]; } set { HistoryDates[1] = value; } }

    public List<HistoryDate> HistoryDates;
}