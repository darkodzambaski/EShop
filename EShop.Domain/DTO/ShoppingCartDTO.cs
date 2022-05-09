using EShop.Domain.Domainmodels;
using System.Collections.Generic;

namespace EShop.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<ProductinShoppingCart> productinShoppingCarts { get; set; }
        public double totalPrice { get; set; }
    }
}
