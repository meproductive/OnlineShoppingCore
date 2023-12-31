﻿using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreBLL.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProductDetails(int id);
        List<Product> GetProductByCategory(string category, int page, int pageSize);
        int GetCountByCategory(string category);
        Product GetByWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
