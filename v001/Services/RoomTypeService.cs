using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class RoomTypeService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<RoomType?> GetEntityByID(Guid uuid)
    {
        return await _context.RoomTypes.FindAsync(uuid);
    }

    public async Task<IEnumerable<RoomType>> GetEntityByValue(string data)
    {
        return await _context.RoomTypes.Where(e => e.RoomTypeName == data).ToListAsync();
    }

    public async Task<IEnumerable<RoomType>> GetAllEnities()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<RoomType> editEntity(RoomType e, Guid uuid)
    {
        if (uuid != e.RoomTypeId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<RoomType> addEntity(RoomType e)
    {
        _context.RoomTypes.AddAsync(e);
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
        
        _context.RoomTypes.Remove(await e);
    }

    #endregion
}