using EShop.Web.Models.Identity;

namespace EShop.Web.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public EShopApplicationUser User { get; set; }
        public virtual  ICollection<ProductinOrder>? Products { get; set; }
    }
}
