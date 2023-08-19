using Microsoft.EntityFrameworkCore;
using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Concrete.EFCore
{
    public class EFCoreCategoryDAL : EFCoreGenericRepository<Category, ShopContext>, ICategoryDAL
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using(var context = new ShopContext())
            {
                var cmd = @"Delete From ProductCategory where categoryId=@p0 and productId=@p1";
                context.Database.ExecuteSqlRaw(cmd, categoryId, productId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Categories.Where(i => i.Id == id)
                    .Include(i => i.ProductCategory)
                    .ThenInclude(i => i.Product)
                    .ThenInclude(i => i.Images)
                    .FirstOrDefault();
            }
        }
    }
}
