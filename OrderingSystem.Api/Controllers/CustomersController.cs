using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
