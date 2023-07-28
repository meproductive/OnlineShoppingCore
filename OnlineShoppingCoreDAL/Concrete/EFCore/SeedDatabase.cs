using Microsoft.EntityFrameworkCore;
using OnlineShoppingCoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreDAL.Concrete.EFCore
{
    public class SeedDatabase
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

                }
            }
        }
        private static Category[] Categories =
        {
            new Category(){Name = "Home" },
            new Category(){Name = "Electronic"}
        };
        private static Product[] Products =
        {
            new Product(){Name= "T-shirt", Price=150, Images={new Image(){ImageUrl="tshirtb.jpg"}
        };
    }
}
