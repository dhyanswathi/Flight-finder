using Flight_Finder.Api.DTO;
using Flight_Finder.Api.Models;
using Flight_Finder.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Finder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ITokenManager _tokenManager;
        public UsersController(IUserRepository repo, ITokenManager tokenManager)
        {
            _repo = repo;
            _tokenManager = tokenManager;
        }

            [HttpGet]
        public IActionResult GetUser(string id) 
        {
            try
            {
                var user = _repo.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.ToString());
            }
        }

        [HttpPost("register")]
        public IActionResult PostUser(UserRegister user)
        {
            var result = _repo.Register(user);
            return Created("", result);
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserLogin userLogin)
        {
            var result = _repo.GetAllUsers();
            var user = result.FirstOrDefault(x => x.Email == userLogin.Email);

            if (user != null && user.Password == userLogin.Password)
            {
                var token = _tokenManager.Authenticate(userLogin.Email, userLogin.Password);
                if (token == null)
                {
                    return Unauthorized();
                }

                var loginUser = new LoginResponse
                {
                    UserId = user.UserId, 
                    Email = user.Email,
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Token = token
                };
                return Ok(loginUser);
            }

            return Unauthorized("Email or password is incorrect");
        }
    }
}
