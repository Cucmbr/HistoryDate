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
    public void ToJson()
    {
        JsonFormat = $"{{\"Begin\":{{\"Year\":{Begin.Year},\"Month\":{Begin.Month},\"Day\":{Begin.Day},\"AD\":{Begin.AD.ToString().ToLower()}}},\"End\":{{\"Year\":{End.Year},\"Month\":{End.Month},\"Day\":{End.Day},\"AD\":{End.AD.ToString().ToLower()}}},\"DateApproximation\":{(int)DateApproximation},\"Presumably\":{Presumably.ToString().ToLower()}}}";
    }
}
