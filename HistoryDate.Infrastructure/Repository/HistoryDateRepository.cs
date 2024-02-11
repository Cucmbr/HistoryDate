using HistoryDateLib.Domain.Model;
using HistoryDateLib.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using System.IO.Pipes;

namespace HistoryDateLib.Infrastructure.Repository;

public class HistoryDateRepository
{
    private readonly Context _context;

    public Context UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public HistoryDateRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<HistoryDate> GetByIdAsync(Guid id)
    {
        return await _context.HistoryDates.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(HistoryDate date)
    {
        _context.HistoryDates.Add(date);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateApproximationAsync(HistoryDate date)
    {
        var existingDate = await GetByIdAsync(date.Id);
        if (existingDate != null)
        {
            _context.HistoryDates.Entry(existingDate).CurrentValues.SetValues(date); 
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var temp = await _context.HistoryDates.FindAsync(id);
        _context.HistoryDates.Remove(temp);
        await _context.SaveChangesAsync();
    }
    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
