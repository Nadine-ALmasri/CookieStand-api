using cookie_stand_api.Data;
using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Model.Services
{
    public class CookieStandServiescs : ICookieStand
    { private readonly CookieDbContext _db;
        private readonly IHourlySales _hourlySales;
        public CookieStandServiescs(CookieDbContext db, IHourlySales hourlySales)
        {
            _db = db;
            _hourlySales = hourlySales;
            
        }
        public async Task<CookieStand> Create(CookiePost CookieStand)
        {
            var cookie = new CookieStand()
            { 
                Location = CookieStand.Location,
                AverageCookiesPerSale = CookieStand.AverageCookiesPerSale,
              
                MaximumCustomersPerHour = CookieStand.MaximumCustomersPerHour,
                MinimumCustomersPerHour = CookieStand.MinimumCustomersPerHour,
               
            }; 

            await _db.AddAsync(cookie);
            cookie.Description = "none";
            cookie.Owner = "null ";
            cookie.HourlySales = await _hourlySales.CreateHourlySalesRandom(cookie.Id, cookie.MaximumCustomersPerHour, cookie.MinimumCustomersPerHour, cookie.AverageCookiesPerSale);
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
