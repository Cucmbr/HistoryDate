using System.Text.Json;

namespace HistoryDate.Domain.Model;

public enum Eon
{
    Hadean,
    Archean,
    Proterozoic,
    Phanerozoic
}
public enum Era
{
    Eoarchean,
    Paleoarchean,
    Mesoarchean,
    Neoarchean,
    Paleoproterozoic,
    Mesoproterozoic,
    Neoproterozoic,
    Paleozoic,
    Mesozoic,
    Cenozoic
}
public enum Period
{
    Siderian,
    Rhyacian,
    Orosirian,
    Statherian,
    Calymmian,
    Ectasian,
    Stenian,
    Tonian,
    Cryogenian,
    Ediacaran,
    Cambrian,
    Ordovician,
    Silurian,
    Devonian,
    Carboniferous,
    Permian,
    Triassic,
    Jurassic,
    Cretaceous,
    Paleogene,
    Neogene,
    Quaternary,
    NotDefined
}
public enum Epoch
{

}
public enum Subepoch
{

}
public enum Age
{

}
// нужно придумать, как ограничить доступ к определённым промежуткам, если на уровне выше были выбраны те, которые не включают нижестоящие.
// прим.: при выборе катархея нельзя указать четвертичынй период. аналочгично с эпохами и т.д.
// возможно, стоит вынести эоны, эры и тд в отдельные классы со своими списками возможных подмножеств.

public class GeoTimeScale : HistoryDate
{
    public bool IsPrecambrian { get; set; } //возможно где-то стоит установить значения по умолчанию
    public Eon Eon { get; set; }
    public Era Era { get; set; }
    public Period Period { get; set; }
    public Epoch Epoch { get; set; }
    public Subepoch Subepoch { get; set; }
    public Age Age { get; set; }

    public override void CalcInterval()
    {
        throw new NotImplementedException();
    }

    public override string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
