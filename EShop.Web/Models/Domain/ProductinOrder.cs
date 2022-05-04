namespace EShop.Web.Models.Domain
{
    public class ProductinOrder
    {
        public Guid ProductId { get; set; }
        public Product SelectedProduct { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
    }
}
