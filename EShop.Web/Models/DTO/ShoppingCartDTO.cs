using EShop.Web.Models.Domain;
using System.Collections.Generic;

namespace EShop.Web.Models.DTO
{
    public class ShoppingCartDTO
    {
        public List<ProductinShoppingCart> productinShoppingCarts { get; set; }
        public double totalPrice { get; set; }
    }
}
