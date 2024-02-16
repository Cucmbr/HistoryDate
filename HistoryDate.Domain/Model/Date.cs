using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryDateLib.Domain.Model;

public class Date : IAnnoDomini
{
    public Guid Id { get; set; }
    public Guid HistoryDateId { get; set; }
    public long Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool AD {  get; set; } = true;
}
