using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class TariffService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<Tariff?> GetEntityByID(Guid uuid)
    {
        return await _context.Tariffs.FindAsync(uuid);
    }

    public async Task<IEnumerable<Tariff>> GetEntityByValue(string data)
    {
        return await _context.Tariffs.Where(e => e.TariffName == data).ToListAsync();
    }

    public async Task<IEnumerable<Tariff>> GetAllEnities()
    {
        return await _context.Tariffs.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<Tariff> editEntity(Tariff e, Guid uuid)
    {
        if (uuid != e.TariffId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<Tariff> addEntity(Tariff e)
    {
        _context.Tariffs.AddAsync(e);
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
        
        _context.Tariffs.Remove(await e);
    }

    #endregion
}