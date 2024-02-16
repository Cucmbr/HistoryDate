using HistoryDateLib.Domain.Model;
using HistoryDateLib.Infrastructure;
Century cent = new Century(19, CenturyPart.FirstHalf, true);
GregorianCalendar greg = new GregorianCalendar(1000, 2, 10);
GregorianCalendar greg2 = new GregorianCalendar(500, 3, 20);
GregorianCalendar greg3 = new GregorianCalendar(2004, 4, 17);
GregorianCalendar greg4 = new GregorianCalendar(2004, 3, 7);

Context context = new Context();
var repos = new HistoryDateRepository(context);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

await repos.AddAsync(greg);
await repos.AddAsync(greg2);
await repos.AddAsync(greg3);
await repos.AddAsync(greg4);