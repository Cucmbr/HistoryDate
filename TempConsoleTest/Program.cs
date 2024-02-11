﻿using HistoryDateLib.Domain.Model;
using System.Text.Json;

//int tempCentury = 101;
//Century[] test = { new Century(tempCentury), new Century(tempCentury, CenturyPart.LastHalf), new Century(tempCentury, CenturyPart.NotDefined), new Century(tempCentury, CenturyPart.SixthDecade), new Century(tempCentury, CenturyPart.FirstQuarter), new Century(tempCentury, CenturyPart.FirstThird), new Century(tempCentury, CenturyPart.SecondThird), new Century(tempCentury, CenturyPart.LastThird) };
//var test2 = new Century(15);

//foreach (var i in test)
//{
//    i.CalcInterval();
//    Console.WriteLine(JsonSerializer.Serialize(i));
//    Console.WriteLine("------------------------------");
//}

var greg = new GregorianCalendar(2004, 04, 17);
var cent = new Century(21, CenturyPart.FirstQuarter);

greg.ToJson();
cent.ToJson();

Console.WriteLine(greg.JsonFormat);
Console.WriteLine(nameof(greg));