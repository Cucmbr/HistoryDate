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

public class GeoTimeScale : HistoryDate
{
    public bool IsPrecambrian { get; set; }
    public Eon Eon { get; set; } = Eon.NotDefined;
    public Era Era { get; set; } = Era.NotDefined;
    public Period Period { get; set; } = Period.NotDefined;
    const int Ma = 1000000;
    private Dictionary<string, int[]> Hierarchy { get; } = new Dictionary<string, int[]>() 
    {
        //Eon
        ["Hadean"] = [1, 4600],
        ["Archean"] = [2, 4000],
        ["Proterozoic"] = [3, 2500],
        ["Phanerozoic"] = [4, 541],

        //Era
        ["Eoarchean"] = [2, 1, 4000],
        ["Paleoarchean"] = [2, 2, 3600 ],
        ["Mesoarchean"] = [2, 3, 3200],
        ["Neoarchean"] = [2, 4, 2800 ],
        ["Paleoproterozoic"] = [3, 5, 2500],
        ["Mesoproterozoic"] = [3, 6, 1600],
        ["Neoproterozoic"] = [3, 7, 1000],
        ["Paleozoic"] = [4, 8, 541],
        ["Mesozoic"] = [4, 9, 251],
        ["Cenozoic"] = [4, 10, 66],

        //Period
        ["Siderian"] = [3, 5, 1, 2500],
        ["Rhyacian"] = [3, 5, 2, 2300],
        ["Orosirian"] = [3, 5, 3, 2300],
        ["Statherian"] = [3, 5, 4, 1800],

        ["Calymmian"] = [3, 6, 5, 1600],
        ["Ectasian"] = [3, 6, 6, 1400],
        ["Stenian"] = [3, 6, 7, 1200],

        ["Tonian"] = [3, 7, 8, 1000],
        ["Cryogenian"] = [3, 7, 9, 720],
        ["Ediacaran"] = [3, 7, 10, 635],

        ["Cambrian"] = [4, 8, 11, 541],
        ["Ordovician"] = [4, 8, 12, 485],
        ["Silurian"] = [4, 8, 13, 444],
        ["Devonian"] = [4, 8, 14, 419],
        ["Carboniferous"] = [4, 8, 15, 359],
        ["Permian"] = [4, 8, 16, 299],

        ["Triassic"] = [4, 9, 17, 252],
        ["Jurassic"] = [4, 9, 18, 201],
        ["Cretaceous"] = [4, 9, 19, 145],

        ["Paleogene"] = [4, 10, 20, 66],
        ["Neogene"] = [4, 10, 21, 23],
        ["Quaternary"] = [4, 10, 22, 3]
    };

    private bool IsValidDate(out int result)
    {
        if (Period != Period.NotDefined)
        {
            int[] periodArrayD = Hierarchy[$"{Period}"];
            Era = (Era)periodArrayD[1];
            Eon = (Eon)periodArrayD[0];
            result = 3;
            return true;
        }
        else if(Era != Era.NotDefined)
        {
            int[] EraArrayD = Hierarchy[$"{Era}"];
            Eon = (Eon)EraArrayD[0];
            result = 2;
            return true;
        }
        else if (Eon != Eon.NotDefined)
        {
            result = 1;
            return true;
        }

        result = 0;
        return false;
    }

    public override void CalcInterval()
    {
        if (!IsValidDate(out int check)) 
        {
            throw new InvalidDataException("Invalid Geological Date");
        }
  
        switch (check)
        {
            case 3:
                var nextPeriod = Period + 1;
                
                Begining = new Date { Year = Hierarchy[$"{Period}"].Last() * Ma, Month = 1, Day = 1, AD = false };
                End = new Date { Year = (int)(Period + 1) > 22 ? DateTime.Now.Year : Hierarchy[$"{nextPeriod}"].Last() * Ma, Month = (int)(Period + 1) > 10 ? DateTime.Now.Month : 12, Day = (int)(Period + 1) > 10 ? DateTime.Now.Day : 31, AD = (int)(Period + 1) > 10 ? true : false };
                break;
            case 2:
                var nextEra = Era + 1;

                Begining = new Date { Year = Hierarchy[$"{Era}"].Last() * Ma, Month = 1, Day = 1, AD = false };
                End = new Date { Year = (int)(Era + 1) > 10 ? DateTime.Now.Year : Hierarchy[$"{nextEra}"].Last() * Ma, Month  = (int)(Era + 1) > 4 ? DateTime.Now.Month : 12, Day = (int)(Era + 1) > 4 ? DateTime.Now.Day : 31, AD = (int)(Era + 1) > 10 ? true : false };
                break;
            case 1:
                var nextEon = Eon + 1;

                Begining = new Date { Year = Hierarchy[$"{Eon}"].Last() * Ma, Month = 1, Day = 1, AD = false };
                End = new Date { Year = (int)(Eon + 1) > 4 ? DateTime.Now.Year : Hierarchy[$"{nextEon}"].Last() * Ma, Month = (int)(Eon + 1) > 4 ? DateTime.Now.Month : 12, Day = (int)(Eon + 1) > 4 ? DateTime.Now.Day : 31, AD = (int)(Eon + 1) > 10 ? true : false };
                break;
        }
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