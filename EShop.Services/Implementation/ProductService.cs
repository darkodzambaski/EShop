using EShop.Domain.Domainmodels;
using EShop.Domain.DTO;
using EShop.Services.Interface;
using EShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository <ProductinShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        public ProductService(IRepository<Product> productRepository, IRepository <ProductinShoppingCart> productInShoppingCartRepository, IUserRepository userRepository) 
        {
            _productRepository= productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCartDTO item, string userID)
        {
            
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.ProductId != null && userShoppingCart != null)
            {
                var product = this.GetDetailsForProduct(item.ProductId);


                if (product != null)
                {
                    ProductinShoppingCart itemToAdd = new ProductinShoppingCart
                    {
                        Product = product,
                        ProductId = product.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };
                    
                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }
        public void CreateNewProduct(Product p) 
        {
           this._productRepository.Insert(p);
        }
        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return this._productRepository.GetAll().ToList(); 
        }
        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }
        public AddToShoppingCartDTO GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            AddToShoppingCartDTO model = new AddToShoppingCartDTO
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };
            return model;
        }
        public void UpdeteExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
