using HistoryDate.Domain.Model;
using System.Text.Json;

var ymd = new YearMonthDay(2004);
ymd.ToJson();
string ymdSer = ymd.JsonFormat;

var ymd2 = JsonSerializer.Deserialize<YearMonthDay>(ymd.JsonFormat);
ymd2.ToJson();
Console.WriteLine("---------------------------------");

Console.WriteLine(ymd2.JsonFormat);



Console.WriteLine(ymdSer);