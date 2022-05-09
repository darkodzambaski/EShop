using EShop.Domain.Domainmodels;

namespace EShop.Domain.DTO
{
    public class AddToShoppingCartDTO
    {
        public Product SelectedProduct { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
