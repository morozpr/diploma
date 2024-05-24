using Microsoft.EntityFrameworkCore;
using v001.Models;

namespace v001.Services;

public class GuestService(DiplomaDbContext context)
{
    private readonly DiplomaDbContext _context = context;

    #region getting guests

    public async Task<Guest?> GetEntityByID(Guid uuid)
    {
        return await _context.Guests.FindAsync(uuid);
    }

    public async Task<IEnumerable<Guest>> GetEntityBySurname(string surname)
    {
        return await _context.Guests.Where(guest => guest.SecondName == surname).ToListAsync();
    }
    
    public async Task<IEnumerable<Guest>> GetEntityByName(string firstname, string surname)
    {
        return await _context.Guests.Where(guest => guest.SecondName == surname && guest.FirstName == firstname).ToListAsync();
    }

    public async Task<IEnumerable<Guest>> GetAllEnities()
    {
        return await _context.Guests.ToListAsync();
    }
    
    public async Task<IEnumerable<Guest>> GetEntityByEmail(string email)
    {
        return await _context.Guests.Where(guest => guest.Email == email).ToListAsync();
    }
    
    public async Task<IEnumerable<Guest>> GetEntityByPhone(string phnumber)
    {
        return await _context.Guests.Where(guest => guest.PhoneNumber == phnumber).ToListAsync();
    }

    #endregion

    #region edit guests

    public async Task<Guest> editGuest(Guest guest, Guid uuid)
    {
        if (uuid != guest.GuestId)
        {
            throw new Exception("IDs does not match");
        }
        
        _context.Entry(guest).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return guest;
    }

    #endregion

    #region add guests

    public async Task<Guest> addGuest(Guest guest)
    {
        _context.Guests.AddAsync(guest);
        await _context.SaveChangesAsync();

        return guest;
    }

    #endregion

    #region delete guests

    public async void deleteGuest(Guid uuid)
    {
        var g = GetEntityByID(uuid);

        if (g == null)
        {
            throw new Exception("Object not found");
        }
        
        _context.Guests.Remove(await g);
    }

    #endregion
}