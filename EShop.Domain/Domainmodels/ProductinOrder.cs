namespace EShop.Domain.Domainmodels
{
    public class ProductinOrder : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product SelectedProduct { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
    }
}
