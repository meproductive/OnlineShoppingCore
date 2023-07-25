using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCoreEntity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public double Price { get; set; }

        public List<ProductCategory> ProductCategory { get; set; }

        public Product()
        {
            Images = new List<Image>();
        }
    }

}
