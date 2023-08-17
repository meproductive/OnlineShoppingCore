using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCore.Models;
using OnlineShoppingCoreBLL.Abstract;
using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreEntity;

namespace OnlineShoppingCore.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        [Route("/admin/products")]
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }
        public IActionResult CreateProduct()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel model, List<IFormFile> files)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            if (files != null)
            {
                foreach (var file in files)
                {
                    Image image = new Image();
                    image.ImageUrl = file.FileName;

                    entity.Images.Add(image);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            _productService.Create(entity);

            return RedirectToAction("ProductList");
        }
        public IActionResult EditProduct(int id)
        {
            var model = _productService.GetProductDetails(id);
            return View(new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Images = model.Images,
                Description = model.Description,
                Price = model.Price
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel model, List<IFormFile> files)
        {
            var entity = _productService.GetById(model.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.Images.Clear();

            if (files != null)
            {
                foreach (var file in files)
                {
                    Image image = new Image();
                    image.ImageUrl = file.FileName;

                    entity.Images.Add(image);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(entity);
                return RedirectToAction("ProductList");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ProductList");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        public IActionResult CreateCategory()
        {
            return View(new CategoryViewModel());
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);
            return RedirectToAction("CategoryList");
        }
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetById(id);
            return View(new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            return RedirectToAction("CategoryList");
        }
    }
}
