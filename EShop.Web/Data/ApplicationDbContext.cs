using EShop.Web.Models.Domain;
using EShop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ProductinShoppingCart> ProductinShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
           .Property(z => z.Id)
           .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
           .Property(z => z.Id)
           .ValueGeneratedOnAdd();

            builder.Entity<ProductinShoppingCart>()
           .HasKey(z => new { z.ProductId, z.ShoppingCartId });


            builder.Entity<ProductinShoppingCart>()
                .HasOne(z => z.Product)
                .WithMany(z => z.ProductinShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<ProductinShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.ProductinShoppingCarts)
                .HasForeignKey(z => z.ProductId);

            builder.Entity<ShoppingCart>()
                .HasOne<EShopApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);
        }
    }
    
}
