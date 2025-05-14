using OrderFoodOnlineSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using OrderFoodOnlineSystem.ViewModels;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;
using OrderFoodOnlineSystem.ViewModels.AccountViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantManagerViewModels;
using OrderFoodOnlineSystem.ViewModels.CustomerViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;
using OrderFoodOnlineSystem.ViewModels.OrderViewModels;

namespace OrderFoodOnlineSystem.Data
{
    public class OrderFoodDbContext: IdentityDbContext<Account>
    {
        #region DBSets
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FavouriteRestaurant> FavouriteRestaurants { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public virtual DbSet<RestaurantManager> RestaurantManagers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; } 
        #endregion

        public OrderFoodDbContext(DbContextOptions<OrderFoodDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //----------------------------------------------------------------------------------
            //SeedRoles
            DbInitializer.SeedRoles(builder);

            //SeedAdmins
            DbInitializer.SeedAdmins(builder);

            //SeedRestaurantManagers
            DbInitializer.SeedRestaurantManagers(builder);

            //SeedRestaurants
            DbInitializer.SeedRestaurants(builder);

            //SeedCategories
            DbInitializer.SeedCategories(builder);

            //SeedRestaurantCategories
            DbInitializer.SeedRestaurantCategories(builder);

            //SeedMenuItems
            DbInitializer.SeedMenuItems(builder);

            //----------------------------------------------------------------------------------
            #region M-M Relation
            //FavouriteRestaurant Table
            builder.Entity<FavouriteRestaurant>()
                .HasKey(f => new { f.CustomerId, f.RestaurantId });

            builder.Entity<FavouriteRestaurant>()
                  .HasOne(f => f.Customer)
                  .WithMany(c => c.FavouriteRestaurants)
                  .HasForeignKey(f => f.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FavouriteRestaurant>()
                 .HasOne(f => f.Restaurant)
                 .WithMany(c => c.FavouriteRestaurants)
                 .HasForeignKey(f => f.RestaurantId)
                 .OnDelete(DeleteBehavior.Restrict);


            //RestaurantCategory Table
            builder.Entity<RestaurantCategory>()
                .HasKey(rc => new { rc.RestaurantId, rc.CategoryId });

            builder.Entity<RestaurantCategory>()
                  .HasOne(rc => rc.Restaurant)
                  .WithMany(c => c.RestaurantCategories)
                  .HasForeignKey(f => f.RestaurantId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RestaurantCategory>()
                 .HasOne(rc => rc.Category)
                 .WithMany(c => c.RestaurantCategories)
                 .HasForeignKey(rc => rc.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            #endregion

        }
    }


}
