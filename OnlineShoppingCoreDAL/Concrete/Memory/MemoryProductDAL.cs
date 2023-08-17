using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Concrete.Memory
{
    public class MemoryProductDAL : IProductDAL
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = new List<Product>()
            {
               new Product() {Id=1, Name="Samsung", Price=10000, Images={new Image() { ImageUrl="tshirtb.jpg"} }}
            };
            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(string category, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
