using System.Text.Json;

namespace HistoryDate.Domain.Model;

public enum DateApproximation
{ 
    NotErlier,
    NotLater,
    Approximately,
    NotDefined
}

public abstract class HistoryDate
{
    public Date Begin { get; set; } = null!;
    public Date End { get; set; } = null!;
    public DateApproximation DateApproximation { get; set; } = DateApproximation.NotDefined;
    public bool Presumably { get; set; } = false;
    public string JsonFormat { get; set; } = string.Empty;

    public abstract void CalcInterval();

    public abstract void FromJson();

    public void FromJson(string json)
    {
        JsonFormat = json;
        FromJson();
    }

    public virtual void ToJson()
    {
        JsonFormat = JsonSerializer.Serialize(this);
    }
}
