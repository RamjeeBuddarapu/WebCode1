using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebCode.Database;
using WebCode.DTOs;
using WebCode.Entities;
using WebCode.Models;

namespace WebCode.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MyContext _dbContext;
        private object userService;
        private object _mapper;

        public UserController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpPost("AddUser")]
        public IActionResult AddUser()
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
                return StatusCode(200, users);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("ValidateUser")]
        public IActionResult ValidateUser(Login login)
        {
            try
            {
                User user = userService.ValidteUser(login.Email, login.Password);
                AuthReponse authReponse = new AuthReponse();
                if (user != null)
                {
                    authReponse.UserName = user.Name;
                    authReponse.Role = user.Role;
                    authReponse.Token = GetToken(user);
                }
                return StatusCode(200, authReponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [Authorize(Roles = "User")]
        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                userService.EditUser(user);
                return StatusCode(200, user);
               

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
