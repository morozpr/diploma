using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class DiscountService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<Discount?> GetEntityByID(Guid uuid)
    {
        return await _context.Discounts.FindAsync(uuid);
    }

    public async Task<IEnumerable<Discount>> GetEntityByValue(int data)
    {
        return await _context.Discounts.Where(e => e.DiscountValue == data).ToListAsync();
    }

    public async Task<IEnumerable<Discount>> GetAllEnities()
    {
        return await _context.Discounts.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<Discount> editEntity(Discount e, Guid uuid)
    {
        if (uuid != e.DiscountId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<Discount> addEntity(Discount e)
    {
        _context.Discounts.AddAsync(e);
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
        
        _context.Discounts.Remove(await e);
    }

    #endregion
}