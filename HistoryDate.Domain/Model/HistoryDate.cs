using System.Text.Json;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public Date Begin { get; set; } = null!;

    [JsonIgnore]
    public Date End { get; set; } = null!;

    [JsonIgnore]
    public DateApproximation DateApproximation { get; set; } = DateApproximation.NotDefined;

    [JsonIgnore]
    public bool Presumably { get; set; } = false;

    public abstract void CalcInterval();
    public abstract string ToJson();
}