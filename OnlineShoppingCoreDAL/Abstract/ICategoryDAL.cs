using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Abstract
{
    public interface ICategoryDAL : IRepository<Category>
    {
        void DeleteFromCategory(int categoryId, int productId);
        Category GetByIdWithProducts(int id);
    }
}
