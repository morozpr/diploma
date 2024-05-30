using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class UserService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;
    
    #region getting data

    public async Task<IEnumerable<User>> GetAllData()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetEntityByID(Guid uuid)
    {
        return await _context.Users.FindAsync(uuid);
    }

    public async Task<IEnumerable<User>> GetEntityByUsername(string username)
    {
        return await _context.Users.Where(e => e.UserName == username).ToListAsync();
    }
    
    

    #endregion
}