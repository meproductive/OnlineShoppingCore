using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingCore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
