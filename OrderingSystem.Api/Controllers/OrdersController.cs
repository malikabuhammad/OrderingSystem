using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]

    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
