using HistoryDateLib.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HistoryDateLib.Infrastructure;

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

    public async Task<HistoryDate> GetByIdAsync(int id)
    {
        return await _context.HistoryDates.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(HistorySpan date)
    {
        _context.HistorySpans.Add(date);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateApproximationAsync(HistorySpan date)
    {
        var existingDate = await GetByIdAsync(date.Id);
        if (existingDate != null)
        {
            _context.HistoryDates.Entry(existingDate).CurrentValues.SetValues(date); 
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
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
