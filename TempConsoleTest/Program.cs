using HistoryDateLib.Domain.Model;
using HistoryDateLib.Infrastructure;

GregorianCalendar greg = new GregorianCalendar(1001, 2, 10);
GregorianCalendar greg2 = new GregorianCalendar(500, 3, 20);
GregorianCalendar greg3 = new GregorianCalendar(2004, 4, 17);
GregorianCalendar greg4 = new GregorianCalendar(2004, 3, 7);

Context context = new Context();
var repos = new HistoryDateRepository(context);

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

await repos.AddAsync(new HistorySpan(greg2, greg));