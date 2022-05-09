using EShop.Domain.Identity;

namespace EShop.Domain.Domainmodels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public EShopApplicationUser User { get; set; }
        public virtual  ICollection<ProductinOrder>? Products { get; set; }
    }
}
