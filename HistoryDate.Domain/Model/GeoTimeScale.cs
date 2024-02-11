using System.Text.Json;

namespace HistoryDateLib.Domain.Model;

public enum Eon
{
    NotDefined = 0,
    Hadean,
    Archean,
    Proterozoic,
    Phanerozoic
}
public enum Era
{
    NotDefined = 0,
    Eoarchean, 
    Paleoarchean,
    Mesoarchean,
    Neoarchean,
    Paleoproterozoic,
    Mesoproterozoic,
    Neoproterozoic,
    Paleozoi,
    Mesozoic,
    Cenozoic
}
public enum Period
{
    NotDefined = 0,
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
    Quaternary
}

// нужно придумать, как ограничить доступ к определённым промежуткам, если на уровне выше были выбраны те, которые не включают нижестоящие.
// прим.: при выборе катархея нельзя указать четвертичынй период. аналочгично с эпохами и т.д.
// возможно, стоит вынести эоны, эры и тд в отдельные классы со своими списками возможных подмножеств.

public class GeoTimeScale : HistoryDate
{
    public bool IsPrecambrian { get; set; }
    public Eon Eon { get; set; } = Eon.NotDefined;
    public Era Era { get; set; } = Era.NotDefined;
    public Period Period { get; set; } = Period.NotDefined;
    private Dictionary<string, int[]> Hierarchy { get; } = new Dictionary<string, int[]>() 
    {
        //Eon
        ["Hadean"] = [1],
        ["Archean"] = [2],
        ["Proterozoic"] = [3],
        ["Phanerozoic"] = [4],

        //Era
        ["Eoarchean"] = [2, 1],
        ["Paleoarchean"] = [2, 2],
        ["Mesoarchean"] = [2, 3],
        ["Neoarchean"] = [2, 4],
        ["Paleoproterozoic"] = [3, 5],
        ["Mesoproterozoic"] = [3, 6],
        ["Neoproterozoic"] = [3, 7],
        ["Paleozoic"] = [4, 8],
        ["Mesozoic"] = [4, 9],
        ["Cenozoic"] = [4, 10],

        //Period
        ["Siderian"] = [3, 5, 1],
        ["Rhyacian"] = [3, 5, 2],
        ["Orosirian"] = [3, 5, 3],
        ["Statherian"] = [3, 5, 4],

        ["Calymmian"] = [3, 6, 5],
        ["Ectasian"] = [3, 6, 6],
        ["Stenian"] = [3, 6, 7],

        ["Tonian"] = [3, 7, 8],
        ["Cryogenian"] = [3, 7, 9],
        ["Ediacaran"] = [3, 7, 10],

        ["Cambrian"] = [4, 8, 11],
        ["Ordovician"] = [4, 8, 12],
        ["Silurian"] = [4, 8, 13],
        ["Devonian"] = [4, 8, 14],
        ["Carboniferous"] = [4, 8, 15],
        ["Permian"] = [4, 8, 16],

        ["Triassic"] = [4, 9, 17 ],
        ["Jurassic"] = [4, 9, 18],
        ["Cretaceous"] = [4, 9, 19 ],

        ["Paleogene"] = [4, 10, 20],
        ["Neogene"] = [4, 10, 21],
        ["Quaternary"] = [4, 10, 22]
    };

    private bool IsValidDate()
    {
        if (Period != Period.NotDefined)
        {
            int[] periodArrayD = Hierarchy[$"{Period}"];
            Era = (Era)periodArrayD[1];
            Eon = (Eon)periodArrayD[0];
            return true;
        }
        else if(Era != Era.NotDefined)
        {
            int[] EraArrayD = Hierarchy[$"{Era}"];
            Eon = (Eon)EraArrayD[0];
            return true;
        }
        else if (Eon != Eon.NotDefined)
        {
            return true;
        }
        return false;
    }

    public override void CalcInterval()
    {
        throw new NotImplementedException();
    }

    public override void ToJson()
    {
        JsonFormat = JsonSerializer.Serialize(this);
    }
    public override void FromJson()
    {
        throw new NotImplementedException();
    }
}