namespace EShop.Web.Models.Domain
{
    public class ProductinShoppingCart
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
