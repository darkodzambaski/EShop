//using EShop.Web.Data;
//using EShop.Web.Models.Domain;
//using EShop.Web.Models.DTO;
//using EShop.Web.Models.Identity;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace EShop.Web.Controllers
//{
//    public class ShoppingCartController : Controller
//    {

//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<EShopApplicationUser> _userMenager;

//         public ShoppingCartController(ApplicationDbContext context, UserManager <EShopApplicationUser> userManager) 
//        {
//            _context = context;
//            _userMenager = userManager;
//        }


//        public async Task <IActionResult> Index()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var loggedInUser = await _context.Users
//                .Where(z => z.Id == userId)
//                .Include(z=>z.UserCart)
//                .Include(z => z.UserCart.ProductinShoppingCarts)
//                .Include("UserCart.ProductinShoppingCarts.Product")
//                .FirstOrDefaultAsync(); 
                
//                var userShoppingCart = loggedInUser.UserCart;
//            var productPrice = userShoppingCart.ProductinShoppingCarts.Select(z => new
//            {
//                ProductPrice = z.Product.ProductPrice,
//                Quantity = z.Quantity
//            }).ToList();

//            double totalPrice = 0;

//            foreach (var item in productPrice)
//            {
//                totalPrice += item.ProductPrice * item.Quantity;
//            }

//            ShoppingCartDTO shoppingCartDTOitem = new ShoppingCartDTO
//            {
//                productinShoppingCarts = userShoppingCart.ProductinShoppingCarts.ToList(),
//                totalPrice = totalPrice
//            };

//            //var allProducts = userShoppingCart.ProductinShoppingCarts.Select(z => z.Product).ToList();

//            return View(shoppingCartDTOitem);
//        }
//        public async Task<IActionResult> DeleteProductFromShoppingCart (Guid? productId)
//        {
//            //operation
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

//            var loggedInUser = await _context.Users
//                .Where(z => z.Id == userId)
//                .Include(z => z.UserCart)
//                .Include(z => z.UserCart.ProductinShoppingCarts)
//                .Include("UserCart.ProductinShoppingCarts.Product")
//                .FirstOrDefaultAsync();

//            var  userShoppingcart = loggedInUser.UserCart;
//            var productToDelete = userShoppingcart.ProductinShoppingCarts
//                .Where(z => z.ProductId == productId)
//                .FirstOrDefault();

//            userShoppingcart.ProductinShoppingCarts.Remove(productToDelete);

//            _context.Update(userShoppingcart);
//            await _context.SaveChangesAsync();
          
//            return RedirectToAction("Index", "ShoppingCart");
//        }
//        public async Task <IActionResult> OrderNow()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var loggedInUser = await _context.Users
//                .Where(z => z.Id == userId)
//                .Include(z => z.UserCart)
//                .Include(z => z.UserCart.ProductinShoppingCarts)
//                .Include("UserCart.ProductinShoppingCarts.Product")
//                .FirstOrDefaultAsync();

//            var userShoppingCart = loggedInUser.UserCart;

//            Order orderitem = new Order
//            {
//                Id = Guid.NewGuid(),
//                UserId = userId,
//                User = loggedInUser,
//            };

//            _context.Add(orderitem);
           

//            List<ProductinOrder> productinOrders = new List<ProductinOrder>();

//            productinOrders = userShoppingCart.ProductinShoppingCarts
//                .Select(z => new ProductinOrder
//                {
//                    OrderId = orderitem.Id,
//                    ProductId = z.ProductId,
//                    SelectedProduct = z.Product,
//                    UserOrder = orderitem
//                }).ToList();  

//           foreach (var item in productinOrders)
//            {
//                _context.Add(orderitem);
               
//            }

//            loggedInUser.UserCart.ProductinShoppingCarts.Clear();

//            _context.Update(loggedInUser);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("Index", "ShoppingCart");
//        }
//    }
//}
