using OnlineShoppingCoreEntity;

namespace OnlineShoppingCore.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
