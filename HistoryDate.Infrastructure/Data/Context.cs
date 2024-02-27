using HistoryDateLib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HistoryDateLib.Infrastructure;

public class Context : DbContext
{
    public DbSet<HistoryDate> HistoryDates { get; set; }
    public DbSet<Date> Dates { get; set; }
    public DbSet<HistorySpan> HistorySpans { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=HistoryBewnis.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoryDate>().HasMany(h => h.Dates).WithOne(d => d.HistoryDate).HasForeignKey(d => d.HistoryDateId);
    }
}