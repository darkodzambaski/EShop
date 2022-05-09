using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.Domainmodels
{
    public class Product : BaseEntity
    {
     
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int Rating { get; set; }
        public virtual ICollection<ProductinShoppingCart>? ProductinShoppingCarts { get; set; }
        public virtual ICollection<ProductinOrder>? Orders { get; set; }
    }
}
