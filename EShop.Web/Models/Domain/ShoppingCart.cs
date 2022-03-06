using EShop.Web.Models.Identity;

namespace EShop.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public EShopApplicationUser Owner { get; set; }
        public virtual ICollection <ProductinShoppingCart> ProductinShoppingCarts { get; set; }
        
    }
}
