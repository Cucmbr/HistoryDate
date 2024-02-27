using System.ComponentModel.DataAnnotations.Schema;
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
    public int Id { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Date Begining { get { return Dates[0]; } set { Dates[0] = value; } }

    [NotMapped]
    [JsonIgnore]
    public Date End { get { return Dates[1]; } set { Dates[1] = value; } }


    [JsonIgnore]
    public DateApproximation DateApproximation { get; set; } = DateApproximation.NotDefined;

    [JsonIgnore]
    public bool Presumably { get; set; } = false;
     
    [JsonIgnore]
    public string JsonFormat { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Date> Dates;

    [JsonIgnore]
    public int HistorySpanId {  get; set; }

    [JsonIgnore]
    public HistorySpan HistorySpan {  get; set; }

    public HistoryDate() 
    {
        Dates = [new() { HistoryDate = this }, new() { HistoryDate = this }];
    }

    public HistoryDate(string json)
    {
        Dates = [new() { HistoryDate = this }, new() { HistoryDate = this }];
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