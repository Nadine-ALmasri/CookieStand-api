using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace cookie_stand_api.Model.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<AppUser> userManager;

        public IdentityUserService(UserManager<AppUser> manager)
        {
            userManager = manager;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            bool vaildtionOfPassword = await userManager.CheckPasswordAsync(user, password);
            if (vaildtionOfPassword)
            {
                return new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                   
                };
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new AppUser()
            {
                UserName = data.UserName,
                PhoneNumber = data.Phone,
                Email = data.Email,

            };

            var result = await userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {

               

                UserDTO userDto = new UserDTO
                {
                  
                    Id = user.Id,
                    UserName = user.UserName,
                  
                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(RegisterUserDTO.UserName) :
                    "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
