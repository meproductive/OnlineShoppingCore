using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCoreBLL.Abstract;

namespace OnlineShoppingCore.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }
    }
}
