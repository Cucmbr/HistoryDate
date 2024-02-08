using HistoryDate.Domain.Model;
using System.Text.Json;

var ymd = new GregorianCalendar(2004);
ymd.ToJson();
string ymdSer = ymd.JsonFormat;

var ymd2 = JsonSerializer.Deserialize<GregorianCalendar>(ymd.JsonFormat);

Console.WriteLine(ymdSer);

Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine(JsonSerializer.Serialize(ymd2));