using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class OrderService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<Order?> GetEntityByID(Guid uuid)
    {
        return await _context.Orders.FindAsync(uuid);
    }

    public async Task<IEnumerable<Order>> GetAllEnities()
    {
        return await _context.Orders.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<Order> editEntity(Order e, Guid uuid)
    {
        if (uuid != e.OrderId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<Order> addEntity(Order e)
    {
        _context.Orders.AddAsync(e);
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
        
        _context.Orders.Remove(await e);
    }

    #endregion
}