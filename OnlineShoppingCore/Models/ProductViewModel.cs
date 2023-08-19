using OnlineShoppingCoreEntity;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCore.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cannot pass without product name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        public double Price { get; set; }
        public List<Category> Categories { get; set; }

        //public List<ProductCategory> ProductCategories { get; set; }

        //public ProductViewModel()
        //{
        //    Images = new List<Image>();
        //}
    }
}
