using EShop.Domain.Identity;

namespace EShop.Domain.Domainmodels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public EShopApplicationUser Owner { get; set; }
        public virtual ICollection <ProductinShoppingCart>? ProductinShoppingCarts { get; set; }
        
    }
}
