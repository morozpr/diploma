using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class BookStatusTypeService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting data

    public async Task<BookStatusType?> GetEntityByID(Guid uuid)
    {
        return await _context.BookStatusTypes.FindAsync(uuid);
    }

    public async Task<IEnumerable<BookStatusType>> GetEntityByName(string name)
    {
        return await _context.BookStatusTypes.Where(e => e.BookStatusTypeName == name).ToListAsync();
    }

    public async Task<IEnumerable<BookStatusType>> GetAllEnities()
    {
        return await _context.BookStatusTypes.ToListAsync();
    }

    #endregion

    #region edit data

    public async Task<BookStatusType> editEntity(BookStatusType e, Guid uuid)
    {
        if (uuid != e.BookStatusTypeId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return e;
    }

    #endregion

    #region add data

    public async Task<BookStatusType> addEntity(BookStatusType e)
    {
        _context.BookStatusTypes.AddAsync(e);
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
        
        _context.BookStatusTypes.Remove(await e);
    }

    #endregion
}