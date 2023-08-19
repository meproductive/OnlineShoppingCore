using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCore.Models;
using OnlineShoppingCoreBLL.Abstract;
using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreEntity;

namespace OnlineShoppingCore.Controllers
{
    [Authorize]
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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
                return NotFound();

            var model = _productService.GetByWithCategories(id.Value);

            ViewBag.Categories = _categoryService.GetAll();

            return View(new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Images = model.Images,
                Description = model.Description,
                Price = model.Price,
                Categories = model.ProductCategory.Select(i => i.Category).ToList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel model, List<IFormFile> files, int[] categoryIds)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAll();
                var m = _productService.GetByWithCategories(model.Id);
                model.Images = m.Images;
                model.Categories = m.ProductCategory.Select(i => i.Category).ToList();
                return View(model);
            }
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

                _productService.Update(entity, categoryIds);
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
            var category = _categoryService.GetByIdWithProducts(id);
            return View(new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.ProductCategory.Select(i => i.Product).ToList()

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
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity == null)
                return NotFound();

            _categoryService.Delete(entity);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);
            return Redirect("/admin/categories/" + categoryId);
        }
    }
}

