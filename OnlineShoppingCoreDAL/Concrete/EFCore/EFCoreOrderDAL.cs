using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Concrete.EFCore
{
    public class EFCoreOrderDAL:EFCoreGenericRepository<Order, ShopContext>, IOrderDAL
    {
    }
}
