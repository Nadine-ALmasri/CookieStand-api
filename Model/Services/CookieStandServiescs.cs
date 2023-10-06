using cookie_stand_api.Data;
using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Model.Services
{
    public class CookieStandServiescs : ICookieStand
    { private readonly CookieDbContext _db;
        public CookieStandServiescs(CookieDbContext db)
        {
            _db = db;
            
        }
        public async Task<CookieStand> Create(CookieStandDTO CookieStand)
        {
            var cookie = new CookieStand()
            {
                Location = CookieStand.Location,
                AverageCookiesPerSale = CookieStand.AverageCookiesPerSale,
                Description = CookieStand.Description,
                MaximumCustomersPerHour = CookieStand.MaximumCustomersPerHour,
                MinimumCustomersPerHour = CookieStand.MinimumCustomersPerHour,
                Owner = CookieStand.Owner,
            };
           await _db.AddAsync(cookie);
            await _db.SaveChangesAsync();
            return cookie;
        }

        public async Task Delete(int CookieStandId)
        {
          CookieStand cookie = await _db.CookieStand.FindAsync(CookieStandId);
            if (cookie != null)
            {
                _db.CookieStand.Remove(cookie);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<CookieStand>> GetCookieStand()
        {
            return await _db.CookieStand
        .Include(c => c.HourlySales) // Eager load the HourlySales related data
        .ToListAsync();
        }

        public async Task<CookieStand> GetCookieStand(int id)
        {
            var cookie = await _db.CookieStand
        .Include(c => c.HourlySales) 
        .FirstOrDefaultAsync(x => x.Id == id);
            if (cookie == null) { return null; }
            return cookie;
        }

        public async Task<CookieStand> Update(CookieStandDTO CookieStandDTO, int CookieStandId)
        {
            var existingCookieStand = await _db.CookieStand.FirstOrDefaultAsync(x => x.Id == CookieStandId);
            if (existingCookieStand == null)
            {
                return null; 
            }

            // Update the properties with values from CookieStandDTO
            existingCookieStand.Location = CookieStandDTO.Location;
            existingCookieStand.AverageCookiesPerSale = CookieStandDTO.AverageCookiesPerSale;
            existingCookieStand.Description = CookieStandDTO.Description;
            existingCookieStand.MaximumCustomersPerHour = CookieStandDTO.MaximumCustomersPerHour;
            existingCookieStand.MinimumCustomersPerHour = CookieStandDTO.MinimumCustomersPerHour;
            existingCookieStand.Owner = CookieStandDTO.Owner;
            _db.Entry(existingCookieStand).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return existingCookieStand;
        }
    }
}
