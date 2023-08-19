using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Abstract
{
    public interface IProductDAL : IRepository<Product>
    {
        //IEnumerable<Product> GetPopularProducts();
        Product GetProductDetails(int id);
        List<Product> GetProductByCategory(string category, int page, int pageSize);
        Product GetByWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
