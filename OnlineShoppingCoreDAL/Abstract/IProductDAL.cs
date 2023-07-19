using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Abstract
{
    public interface IProductDAL
    {
        Product GetById(int id);
        Product GetOne(Expression<Func<Task, bool>> filter);
        IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter);

        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
