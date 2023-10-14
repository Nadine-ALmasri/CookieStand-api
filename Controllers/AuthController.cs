

using cookie_stand_api.Model.DTO;
using cookie_stand_api.Model.Interface;
using cookie_stand_api.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
   
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private IUserService userService;

        public AuthController(IUserService service)
        {
            userService = service;


        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
        {
            var user = await userService.Authenticate(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> ClientRegister(RegisterUserDTO Data)
        {
            var user = await userService.Register(Data, this.ModelState);
            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

    }
}