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
        
    }
}
