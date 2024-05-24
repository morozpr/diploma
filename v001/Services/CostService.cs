using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class CostService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<Cost?> GetEntityByID(Guid uuid)
    {
        return await _context.Costs.FindAsync(uuid);
    }

    public async Task<IEnumerable<Cost>> GetEntityByValue(int data)
    {
        return await _context.Costs.Where(e => e.CostValue == data).ToListAsync();
    }

    public async Task<IEnumerable<Cost>> GetAllEnities()
    {
        return await _context.Costs.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<Cost> editEntity(Cost e, Guid uuid)
    {
        if (uuid != e.CostId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<Cost> addEntity(Cost e)
    {
        _context.Costs.AddAsync(e);
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region delete data

    public async void deleteEntity(Guid uuid)
    {
        var e = GetEntityByID(uuid);

        if (e == null)
        {
            throw new Exception("Object not found");
        }
        
        _context.Costs.Remove(await e);
    }

    #endregion
}