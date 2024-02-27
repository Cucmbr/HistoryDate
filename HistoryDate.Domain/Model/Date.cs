using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryDateLib.Domain.Model;

public class Date : IAnnoDomini
{
    public int Id { get; set; }
    public int HistoryDateId { get; set; }
    public HistoryDate HistoryDate { get; set; }
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD {  get; set; } = true;
}