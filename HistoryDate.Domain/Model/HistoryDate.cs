using System.Text.Json.Serialization;

namespace HistoryDateLib.Domain.Model;

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
    public Guid Id { get; set; }

    [JsonIgnore]
    public Date Begining { get; set; } = null!;

    [JsonIgnore]
    public Date End { get; set; } = null!;

    [JsonIgnore]
    public DateApproximation DateApproximation { get; set; } = DateApproximation.NotDefined;

    [JsonIgnore]
    public bool Presumably { get; set; } = false;
     
    [JsonIgnore]
    public string JsonFormat { get; set; } = string.Empty;

    public HistoryDate() { }

    public HistoryDate(string json)
    {
        JsonFormat = json;

        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
    }

    public abstract void CalcInterval();
    public abstract void ToJson();
    public abstract void FromJson();
}