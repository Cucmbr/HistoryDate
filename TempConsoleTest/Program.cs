using HistoryDate.Domain.Model;
using System.Text.Json;

var ymd = new GregorianCalendar(2004);

var ymd2 = JsonSerializer.Deserialize<GregorianCalendar>(ymd.ToJson());

Console.WriteLine(ymd.ToJson());

Console.WriteLine("----------------------------------------------------------------------------------");

Console.WriteLine(JsonSerializer.Serialize(ymd2));