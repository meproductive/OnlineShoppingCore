﻿using Microsoft.EntityFrameworkCore;
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
    public class EFCoreProductDAL : EFCoreGenericRepository<Product, ShopContext>, IProductDAL
    {
        //public IEnumerable<Product> GetPopularProducts()
        //{
        //    throw new NotImplementedException();
        //}
        public override IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Include(i => i.Images).AsQueryable();

                return filter == null ? products.ToList() : products.Where(filter).ToList();
            }
        }

        public List<Product> GetProductByCategory(string category, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Include("Images").AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(i => i.ProductCategory)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategory.Any(a => a.Category.Name.ToLower() == category.ToLower()));

                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        //public override Product GetById(int id)
        //{
        //    using (var context = new ShopContext())
        //    {
        //        //var product = context.Products.Include("Images").Where(i => i.Id == id).FirstOrDefault();
        //        return context.Products.Include("Images").FirstOrDefault(i => i.Id == id);
        //    }

        //}

        public Product GetProductDetails(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(i => i.Id == id)
                    .Include("Images")
                    .Include(i => i.ProductCategory)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public override void Update(Product entity)
        {
            using (var context = new ShopContext())
            {
                context.Images.RemoveRange(context.Images.Where(i => i.ProductId == entity.Id).ToList());

                var product = context.Products.Where(i => i.Id == entity.Id).FirstOrDefault();

                product.Description = entity.Description;
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Images = entity.Images;

                context.SaveChanges();
            }
            base.Update(entity);
        }
              
    }
}

