using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingCore.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
