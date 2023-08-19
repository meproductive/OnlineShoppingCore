using OnlineShoppingCoreEntity;

namespace OnlineShoppingCore.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
