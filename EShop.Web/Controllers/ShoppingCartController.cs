﻿using EShop.Web.Data;
using EShop.Web.Models.DTO;
using EShop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<EShopApplicationUser> _userMenager;

         public ShoppingCartController(ApplicationDbContext context, UserManager <EShopApplicationUser> userManager) 
        {
            _context = context;
            _userMenager = userManager;
        }


        public async Task <IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var loggedInUser = await _context.Users
                .Where(z => z.Id == userId)
                .Include(z=>z.UserCart)
                .Include(z => z.UserCart.ProductinShoppingCarts)
                .Include("UserCart.ProductinShoppingCarts.Product")
                .FirstOrDefaultAsync(); 
                
                var userShoppingCart = loggedInUser.UserCart;
            var productPrice = userShoppingCart.ProductinShoppingCarts.Select(z => new
            {
                ProductPrice = z.Product.ProductPrice,
                Quantity = z.Quantity
            }).ToList();

            double totalPrice = 0;

            foreach (var item in productPrice)
            {
                totalPrice += item.ProductPrice * item.Quantity;
            }

            ShoppingCartDTO shoppingCartDTOitem = new ShoppingCartDTO
            {
                productinShoppingCarts = userShoppingCart.ProductinShoppingCarts.ToList(),
                totalPrice = totalPrice
            };

            //var allProducts = userShoppingCart.ProductinShoppingCarts.Select(z => z.Product).ToList();

            return View(shoppingCartDTOitem);
        }
    }
}