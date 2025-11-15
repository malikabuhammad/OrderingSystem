using Microsoft.AspNetCore.Mvc;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]

    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
