using cookie_stand_api.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cookie_stand_api.Model.Interface
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);
    }
}
