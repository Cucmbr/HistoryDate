using HistoryDateLib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HistoryDateLib.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<HistoryDate> HistoryDates { get; set; }
}