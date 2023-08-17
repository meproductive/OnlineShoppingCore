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
        [Route("products/{category?}")]
        public IActionResult List(string category, int page=1)
        {
            const int pageSize = 3;
            return View(new ProductListViewModel()
            {
                Pageınfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductByCategory(category, page, pageSize)
            });
        }
        public IActionResult Details(int? id)
        {          
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetProductDetails((int)id);
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
