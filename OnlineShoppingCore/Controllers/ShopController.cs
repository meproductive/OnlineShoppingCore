using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCore.Models;
using OnlineShoppingCoreBLL.Abstract;

namespace OnlineShoppingCore.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }
        public IActionResult Details(int? id)
        {          
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetById((int)id);
            //var product = _productService.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsViewModel()
            {
                Product = product,
                Categories = product.ProductCategory.Select(i => i.Category).ToList()
            });
        }
    }
}
