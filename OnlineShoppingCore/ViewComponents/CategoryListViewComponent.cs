using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCore.Models;
using OnlineShoppingCoreBLL.Abstract;

namespace OnlineShoppingCore.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
    }
}
