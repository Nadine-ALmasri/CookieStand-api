using cookie_stand_api.Data;
using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Model.Services
{
    public class HourlySalesServies:IHourlySales
    {
        private readonly CookieDbContext _db;

        public HourlySalesServies(CookieDbContext db)
        {
             _db = db; 
        }

        public async Task<List<HourlySales>> GetAllHourlySales()
        {
            return await _db.HourlySales.ToListAsync();
        }

        public async Task<List<HourlySales>> GetHourlySalesByCookieStandId(int cookieStandId)
        {
            return await _db.HourlySales
                .Where(s => s.CookieStandId == cookieStandId).ToListAsync();
               
        }

        public async Task<HourlySales> CreateHourlySales(HourlySalesDTO hourlySalesDTO)
        {
            var hourlySales = new HourlySales()
            {
                CookieStandId = hourlySalesDTO.CookieStandId,
                SalesAmount = hourlySalesDTO.SalesAmount,
             hour=hourlySalesDTO.hour 
            };

            await _db.AddAsync(hourlySales);
            await _db.SaveChangesAsync();
            return hourlySales;
        }

        public async Task DeleteHourlySales(int hourlySalesId)
        {
            var hourlySales = await _db.HourlySales.FindAsync(hourlySalesId);
            if (hourlySales != null)
            {
                _db.HourlySales.Remove(hourlySales);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<HourlySales> UpdateHourlySales(int hourlySalesId, HourlySalesDTO updatedHourlySalesDTO)
        {
            var hourlySales = await _db.HourlySales.FindAsync(hourlySalesId);

            if (hourlySales == null)
            {
                return null; // Return null or handle the case where the hourly sales record is not found.
            }

            // Update the hourly sales record with the new data
            hourlySales.SalesAmount = updatedHourlySalesDTO.SalesAmount;
            hourlySales.hour = updatedHourlySalesDTO.hour;
            _db.Entry(hourlySales).State = EntityState.Modified;
           // _db.HourlySales.Update(hourlySales);
            await _db.SaveChangesAsync();

            return hourlySales;
        }
        public async Task<HourlySales> GetHourlySalesById(int hourlySalesId)
        {
            return await _db.HourlySales.FindAsync(hourlySalesId);
        }
    }
}
