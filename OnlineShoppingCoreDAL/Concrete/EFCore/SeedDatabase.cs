using Microsoft.EntityFrameworkCore;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.Categories.Count() == 0)
                {
                    //Category category = new Category();
                    //category.Name = "Home";
                    //context.Categories.Add(category);
                    //context.SaveChanges();
                    context.Categories.AddRange(Categories);
                }
                if(context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories =
        {
            new Category(){Name = "Women" },
            new Category(){Name = "Men"},
            new Category(){Name = "Accessories"}
        };
        private static Product[] Products =
        {
            new Product(){Name= "T-shirt", Price=150, Images={ new Image() { ImageUrl = "t-shirtb.jpg" }, new Image() { ImageUrl = "t-shirtm.jpg" } }, Description="güzel" },
            new Product(){Name= "T-shirt", Price=150, Images={ new Image() { ImageUrl = "t-shirtb.jpg" }, new Image() { ImageUrl = "t-shirtm.jpg" } }, Description="güzel" },
            new Product(){Name= "wallet", Price=150, Images={ new Image() { ImageUrl = "wallet.jpg" }, new Image() { ImageUrl = "wallet.jpg" } }, Description="güzel" },
            new Product(){Name= "womanwallet", Price=150, Images={ new Image() { ImageUrl = "womanwallet.jpg" }, new Image() { ImageUrl = "womanwallet.jpg" } }, Description="güzel" }
        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product = Products[0], Category=Categories[0]},
            new ProductCategory(){Product = Products[3], Category=Categories[2]},
            new ProductCategory(){Product = Products[3], Category=Categories[0]},
            new ProductCategory(){Product = Products[1], Category=Categories[1]},
            new ProductCategory(){Product = Products[2], Category=Categories[2]},
            new ProductCategory(){Product = Products[2], Category=Categories[1]}
        };
    }
}
