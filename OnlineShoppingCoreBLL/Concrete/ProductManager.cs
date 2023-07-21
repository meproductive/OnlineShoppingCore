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

        public Product getById(int id)
        {
            return _productdal.GetById(id);
        }

        public void Update(Product entity)
        {
            _productdal.Update(entity);
        }
    }
}
