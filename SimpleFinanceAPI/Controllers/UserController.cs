using Microsoft.AspNetCore.Mvc;
using SimpleFinanceAPI.Interfaces;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
