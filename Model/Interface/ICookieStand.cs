using cookie_stand_api.Model.DTO;

namespace cookie_stand_api.Model.Interface
{
    public interface ICookieStand
    {
        Task<CookieStand> Create(CookiePost CookieStand);

        Task<List<CookieStand>> GetCookieStand();
        Task<CookieStand> GetCookieStand(int id);

     
        Task<CookieStand> Update(CookieStandDTO CookieStandDTO, int CookieStandId);

        Task Delete(int CookieStandId);
    }
}
