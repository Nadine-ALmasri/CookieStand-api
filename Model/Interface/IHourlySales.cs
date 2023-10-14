using cookie_stand_api.Model.DTO;

namespace cookie_stand_api.Model.Interface
{
    public interface IHourlySales
    {
        Task<List<HourlySales>> GetAllHourlySales();
        Task<List<HourlySales>> GetHourlySalesByCookieStandId(int cookieStandId);
        Task<HourlySales> CreateHourlySales(HourlySalesDTO hourlySalesDTO);
        Task<HourlySales> UpdateHourlySales(int hourlySalesId, HourlySalesDTO updatedHourlySalesDTO);
        Task<HourlySales> GetHourlySalesById(int hourlySalesId);
        Task DeleteHourlySales(int hourlySalesId);
        Task<List<HourlySales>> CreateHourlySalesRandom(int CookieStandID, int MinimumCustomersPerHour,
          int MaximumCustomersPerHour, double AverageCookiesPerSale);
    }
}
