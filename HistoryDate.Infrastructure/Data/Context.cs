using HistoryDateLib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HistoryDateLib.Infrastructure;

public class Context : DbContext
{
    public DbSet<HistoryDate> HistoryDates { get; set; }
    public DbSet<Date> Dates { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=HistoryBewnis.db");
    }
}