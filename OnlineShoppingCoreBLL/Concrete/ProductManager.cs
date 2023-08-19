using Microsoft.EntityFrameworkCore;
using OnlineShoppingCoreBLL.Abstract;
using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreDAL.Concrete.EFCore;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreBLL.Concrete
{
    public class ProductManager : IProductService
    {
        //Injection
        private IProductDAL _productdal;       
        public ProductManager(IProductDAL productdal)
        {
            _productdal = productdal;
        }
        public void Create(Product entity)
        {
            _productdal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productdal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productdal.GetById(id);
        }

        public Product GetByWithCategories(int id)
        {
            return _productdal.GetByWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {

                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategory)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategory.Any(a => a.Category.Name.ToLower() == category.ToLower()));

                }
                return products.Count();
            }

        }

        public List<Product> GetProductByCategory(string category, int page, int pageSize)
        {
            return _productdal.GetProductByCategory(category, page, pageSize);
        }

        public Product GetProductDetails(int id)
        {
            return _productdal.GetProductDetails(id);
        }

        public void Update(Product entity)
        {
            _productdal.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productdal.Update(entity, categoryIds);
        }
    }
}
