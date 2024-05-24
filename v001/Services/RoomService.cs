using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class RoomService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<Room?> GetEntityByID(Guid uuid)
    {
        return await _context.Rooms.FindAsync(uuid);
    }

    public async Task<IEnumerable<Room>> GetEntityByValue(string data)
    {
        return await _context.Rooms.Where(e => e.RoomName == data).ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetAllEnities()
    {
        return await _context.Rooms.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<Room> editEntity(Room e, Guid uuid)
    {
        if (uuid != e.RoomId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<Room> addEntity(Room e)
    {
        _context.Rooms.AddAsync(e);
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
        
        _context.Rooms.Remove(await e);
    }

    #endregion
}