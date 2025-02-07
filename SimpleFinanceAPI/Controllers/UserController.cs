using Microsoft.AspNetCore.Mvc;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
      
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin(string userName, string password)
        {
            var user = await _userRepository.GetUserByUsernameAndPassword(userName, password);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
