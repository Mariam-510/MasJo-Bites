using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Models.Attributes;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;

namespace OrderFoodOnlineSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DbContext
            builder.Services.AddDbContext<OrderFoodDbContext>(op =>
                op.UseSqlServer(builder.Configuration.GetConnectionString("OrderFoodDb")));

            //Identity
            builder.Services.AddIdentity<Account, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<OrderFoodDbContext>()
                .AddDefaultTokenProviders();

            //Google Authentication
            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
                options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
            });

            //Password
            builder.Services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
            });
            builder.Services.AddScoped<IPasswordValidator<Account>, PasswordLengthValidator<Account>>();

            //Scoped DI
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IRestaurantManagerRepository, RestaurantManagerRepository>();
            builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            builder.Services.AddScoped<IFavouriteRestaurantRepository, FavoriteRestaurantRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
            builder.Services.AddScoped<FileService>();
            builder.Services.AddScoped<EmailService>();

            builder.Services.AddAutoMapper(typeof(Program));

            //Authorization
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.UseHttpsRedirection(); //-----------------------------------------------------------

            app.Run();
        }
    }
}
