using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HistoryDateLib.Domain.Model;

public enum DateApproximation
{ 
    NotErlier,
    NotLater,
    Approximately,
    NotDefined
}

public class HistoryDate
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

    public HistoryDate() 
    {
        Id = Guid.NewGuid();
        Begining = new Date(Id);
        End = new Date(Id);
    }

    public HistoryDate(string json)
    {
        Begining = new Date(Id);
        End = new Date(Id);
        JsonFormat = json;

        if (JsonFormat != string.Empty)
        {
            FromJson();
        }
    }

    public virtual void CalcInterval() { }
    public virtual void ToJson() { }
    public virtual void FromJson() { }
}