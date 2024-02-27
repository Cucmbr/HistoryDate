using HistoryDateLib.Domain.Model;

namespace HistoryDateLib.Infrastructure.Searching;

public class Sorter
{
    public List<HistorySpan> SortByRelevance(List<HistorySpan> spans, HistorySpan target)
    {
        var result = new List<HistorySpan>(spans.Count);

        foreach (var span in spans)
        {

        }
    }
}