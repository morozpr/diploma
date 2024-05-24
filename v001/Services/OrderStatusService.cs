using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class OrderStatusService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<OrderStatus?> GetEntityByID(Guid uuid)
    {
        return await _context.OrderStatuses.FindAsync(uuid);
    }

    public async Task<IEnumerable<OrderStatus>> GetEntityByValue(string data)
    {
        return await _context.OrderStatuses.Where(e => e.OrderStatusName == data).ToListAsync();
    }

    public async Task<IEnumerable<OrderStatus>> GetAllEnities()
    {
        return await _context.OrderStatuses.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<OrderStatus> editEntity(OrderStatus e, Guid uuid)
    {
        if (uuid != e.OrderStatusId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<OrderStatus> addEntity(OrderStatus e)
    {
        _context.OrderStatuses.AddAsync(e);
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
        
        _context.OrderStatuses.Remove(await e);
    }

    #endregion
}