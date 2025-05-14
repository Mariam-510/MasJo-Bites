using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace OrderFoodOnlineSystem.Data
{
    public static class DbInitializer
    {
        //----------------------------------------------------------------------------------------------------
        //Seed Roles
        static string AdminRoleId = "8b06abb5-8df6-4b7f-8eb4-91344791938e";
        static string CustomerRoleId = "7169d432-6275-48ce-b121-879b37df1762";
        static string RestaurantManagerRoleId = "d6285ef2-cf06-475c-914f-119737485d65";
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=AdminRoleId,
                    ConcurrencyStamp=AdminRoleId,
                    Name="Admin",
                    NormalizedName="Admin".ToUpper(),
                },
                new IdentityRole
                {
                    Id=CustomerRoleId,
                    ConcurrencyStamp=CustomerRoleId,
                    Name="Customer",
                    NormalizedName="Customer".ToUpper(),
                },
                new IdentityRole
                {
                    Id=RestaurantManagerRoleId,
                    ConcurrencyStamp=RestaurantManagerRoleId,
                    Name="RestaurantManager",
                    NormalizedName="RestaurantManager".ToUpper(),
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        //----------------------------------------------------------------------------------------------------
        //Seed Admins
        public static void SeedAdmins(ModelBuilder modelBuilder)
        {
            var adminAccountId = "80d9c265-64a3-4520-9b0f-164d5bfc6afa";
            //Seed Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = adminAccountId,
                    UserName = "admin1@gmail.com",
                    NormalizedUserName = "ADMIN1@GMAIL.COM",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEGs3LRYykr9WajXOK4Y11VLGHF14VzdhhAnyRd0aAgKTpCoR5r2nZlzuRr/6p2FDLQ==", //Admin1@123
                    SecurityStamp = "52a4b8bd-9804-45d3-9125-32df5869fab8",
                    ConcurrencyStamp = "53f4f840-6448-4fbb-ab15-9ac7eb688f7c",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });

            //Assign Role to Admin Account
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminAccountId,
                    RoleId = AdminRoleId
                });

            //Seed Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Name = "Admin",
                    IsDeleted = false,
                    AccountId = adminAccountId
                });
        }

        //----------------------------------------------------------------------------------------------------
        //Seed RestaurantManagers
        public static void SeedRestaurantManagers(ModelBuilder modelBuilder)
        {
            var manager1AccountId = "cfcc4d4f-598d-48d7-985c-973ade5c4a85";
            var manager2AccountId = "823d613d-51f5-44d0-af8c-98a5dcf1e070";
            var manager3AccountId = "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f";
            var manager4AccountId = "249116a4-54c9-4928-8de1-8c1c1b921695";
            var manager5AccountId = "007e8fc5-4751-4514-8d48-842fe1478097";
            var manager6AccountId = "19116f65-9e11-4b13-81b0-0b5a2f224fda";

            // Seed Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = manager1AccountId,
                    UserName = "tbmanager@gmail.com",
                    NormalizedUserName = "TBMANAGER@GMAIL.COM",
                    Email = "tbmanager@gmail.com",
                    NormalizedEmail = "TBMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEKIH5mf5ukdcyNhy9cGyI3rO6aflvTikWXkyEzQ1xTUOmb8Y1Dc2W1i8XEHkvac9Sg==", //Manager1@
                    SecurityStamp = "e1efa798-3d21-492a-bd10-56f58e015edd",
                    ConcurrencyStamp = "d8d751d6-f58f-4a15-b713-c3cd581cb551",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new Account
                {
                    Id = manager2AccountId,
                    UserName = "bkmanager@gmail.com",
                    NormalizedUserName = "BKMANAGER@GMAIL.COM",
                    Email = "BKmanager@gmail.com",
                    NormalizedEmail = "bkMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEEzzzh6xvgWC74o9rwDkUUJfdbz/AEw6lHJtUWqjVUf1lAt2PCqqPjSfOZZeKFevMg==", //Manager2@
                    SecurityStamp = "1ab93e8b-f2d8-459c-aa16-6d30c2cb47fd",
                    ConcurrencyStamp = "8236404b-5356-422e-afd6-b54776a3e3dc",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new Account
                {
                    Id = manager3AccountId,
                    UserName = "gmanager@gmail.com",
                    NormalizedUserName = "GMANAGER@GMAIL.COM",
                    Email = "gmanager@gmail.com",
                    NormalizedEmail = "GMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEOoXQKojc6ZSiZyZtbTZz5JsnvW4dKBW5KUfkTb08aAAcysSB2T/KfwZiFoUEeIISQ==", //Manager3@
                    SecurityStamp = "d8bed259-7a1b-4cfa-8368-dca899b2029a",
                    ConcurrencyStamp = "bd8753f1-4f94-4be3-b63a-17bc2d7635a3",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new Account
                {
                    Id = manager4AccountId,
                    UserName = "pjmanager@gmail.com",
                    NormalizedUserName = "PJMANAGER@GMAIL.COM",
                    Email = "pjmanager@gmail.com",
                    NormalizedEmail = "PJMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEDuvofy/t/2NZIbiJ9n9mvM1uHuOB8ImAiLFjbhN/j3TjV4o3SkE8v3usBeLaeXtRA==", //Manager4@
                    SecurityStamp = "91593a72-cd2d-4902-9e33-07a5a9ef9b38",
                    ConcurrencyStamp = "a7ed6003-b034-4c31-8d11-23b45cf730fe",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new Account
                {
                    Id = manager5AccountId,
                    UserName = "phmanager@gmail.com",
                    NormalizedUserName = "PHMANAGER@GMAIL.COM",
                    Email = "phmanager@gmail.com",
                    NormalizedEmail = "PHMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEJsFxPtWwJrhdHsbWzPv2mlJq6gkqkBLImRbB95k6qCtt0s18sCaIF0evY6O3McY+g==", //Manager5@
                    SecurityStamp = "3e674cdc-01bd-42e1-afc8-4b4e4564be82",
                    ConcurrencyStamp = "51266c8c-079d-4eed-abc6-9f6412ef2af4",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new Account
                {
                    Id = manager6AccountId,
                    UserName = "sdmanager@gmail.com",
                    NormalizedUserName = "SDMANAGER@GMAIL.COM",
                    Email = "sdmanager@gmail.com",
                    NormalizedEmail = "SDMANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEF5jzaGrwmpeB+afU4J3+f0hwmMkB7mRzui/d/qxsPUL3Q53aLr2p2wvSddOBBtgNg==", //Manager6@
                    SecurityStamp = "7248531d-eaa3-4ddc-86f3-9f303e1a3874",
                    ConcurrencyStamp = "b92ecee8-0a51-4970-9ad2-db4bb66e244b",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
                );

            // Assign Role to Restaurant Managers
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = manager1AccountId, RoleId = RestaurantManagerRoleId },
                new IdentityUserRole<string> { UserId = manager2AccountId, RoleId = RestaurantManagerRoleId },
                new IdentityUserRole<string> { UserId = manager3AccountId, RoleId = RestaurantManagerRoleId },
                new IdentityUserRole<string> { UserId = manager4AccountId, RoleId = RestaurantManagerRoleId },
                new IdentityUserRole<string> { UserId = manager5AccountId, RoleId = RestaurantManagerRoleId },
                new IdentityUserRole<string> { UserId = manager6AccountId, RoleId = RestaurantManagerRoleId });

            // Seed Restaurant Managers
            modelBuilder.Entity<RestaurantManager>().HasData(
                new RestaurantManager
                {
                    Id = 1,
                    Name = "Tasty Bites Manager",
                    IsDeleted = false,
                    AccountId = manager1AccountId
                },
                new RestaurantManager
                {
                    Id = 2,
                    Name = "Burger King Manager",
                    IsDeleted = false,
                    AccountId = manager2AccountId
                },
                new RestaurantManager
                {
                    Id = 3,
                    Name = "Ginger Manager",
                    IsDeleted = false,
                    AccountId = manager3AccountId
                },
                new RestaurantManager
                {
                    Id = 4,
                    Name = "PaPa John Manager",
                    IsDeleted = false,
                    AccountId = manager4AccountId
                },
                new RestaurantManager
                {
                    Id = 5,
                    Name = "Pizza Hut Manager",
                    IsDeleted = false,
                    AccountId = manager5AccountId
                },
                new RestaurantManager
                {
                    Id = 6,
                    Name = "Sweet Delights Manager",
                    IsDeleted = false,
                    AccountId = manager6AccountId
                }
                );
        }

        //----------------------------------------------------------------------------------------------------
        //Seed Restaurants
        public static void SeedRestaurants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Tasty Bites",
                    Description = "A stylish and modern restaurant serving delicious pizza, pasta, and grilled meals in a cozy ambiance.",
                    ImageUrl = "RestaurantImages/Tasty bites.PNG",
                    DateOpen = new TimeOnly(11, 0),
                    DateColse = new TimeOnly(6, 0),
                    IsDeleted = false,
                    AverageRating = 0,
                    DeliveryFees = 40,
                    RestaurantManagerId = 1
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Burger King",
                    Description = "A popular Egyptian burger chain known for its real beef burgers and bold flavors.",
                    ImageUrl = "RestaurantImages/Burger King.jpeg",
                    DateOpen = new TimeOnly(13, 0),
                    DateColse = new TimeOnly(7, 0),
                    IsDeleted = false,
                    AverageRating = 0,
                    DeliveryFees = 50,
                    RestaurantManagerId = 2
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Ginger",
                    Description = "Ginger offers authentic Japanese cuisine and fresh sushi in a stylish setting.",
                    ImageUrl = "RestaurantImages/Ginger.JPG",
                    DateOpen = new TimeOnly(13, 0),
                    DateColse = new TimeOnly(23, 0),
                    IsDeleted = false,
                    AverageRating = 0,
                    DeliveryFees = 35,
                    RestaurantManagerId = 3
                },
                new Restaurant
                {
                    Id = 4,
                    Name = "PaPa John",
                    Description = "Papa John’s is a popular American pizza chain known for fresh ingredients and garlic sauce.",
                    ImageUrl = "RestaurantImages/papaJohn.jpeg",
                    DateOpen = new TimeOnly(11, 0),
                    DateColse = new TimeOnly(23, 30),
                    AverageRating = 0,
                    IsDeleted = false,
                    DeliveryFees = 25,
                    RestaurantManagerId = 4
                },
                new Restaurant
                {
                    Id = 5,
                    Name = "Pizza Hut",
                    Description = "A global restaurant known for pan pizzas, pasta, and sides.",
                    ImageUrl = "RestaurantImages/PizzaHut.jpeg",
                    DateOpen = new TimeOnly(10, 0),
                    DateColse = new TimeOnly(22, 0),
                    AverageRating = 0,
                    IsDeleted = false,
                    DeliveryFees = 45,
                    RestaurantManagerId = 5
                },
                new Restaurant
                {
                    Id = 6,
                    Name = "Sweet Delights",
                    Description = "A cozy spot serving irresistible desserts and sweet treats.",
                    ImageUrl = "RestaurantImages/Sweet Delight.PNG",
                    DateOpen = new TimeOnly(10, 0),
                    DateColse = new TimeOnly(23, 0),
                    AverageRating = 0,
                    IsDeleted = false,
                    DeliveryFees = 25,
                    RestaurantManagerId = 6
                }
            );
        }

        //----------------------------------------------------------------------------------------------------
        //Seed Categories
        public static void SeedCategories(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Pizza",
                    ImageUrl = "CategoryImages/pizza.jpeg",
                    IsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    Name = "Burgers",
                    ImageUrl = "CategoryImages/Burger.jpeg",
                    IsDeleted = false
                },
                new Category
                {
                    Id = 3,
                    Name = "Pasta",
                    ImageUrl = "CategoryImages/pasta.jpeg",
                    IsDeleted = false
                },
                new Category
                {
                    Id = 4,
                    Name = "Sushi",
                    ImageUrl = "CategoryImages/Sushi.jpeg",
                    IsDeleted = false
                },
                new Category
                {
                    Id = 5,
                    Name = "Desserts",
                    ImageUrl = "CategoryImages/shop-37.jpg",
                    IsDeleted = false
                },
                new Category
                {
                    Id = 6,
                    Name = "Drinks",
                    ImageUrl = "CategoryImages/Drink Category.jpeg",
                    IsDeleted = false
                }
            );
        }

        //----------------------------------------------------------------------------------------------------
        //Seed RestaurantCategories
        public static void SeedRestaurantCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantCategory>().HasData(
                new RestaurantCategory { RestaurantId = 1, CategoryId = 1, IsDeleted = false }, // Tasty Bites -> Pizza
                new RestaurantCategory { RestaurantId = 1, CategoryId = 3, IsDeleted = false }, // Tasty Bites -> Pasta
                new RestaurantCategory { RestaurantId = 1, CategoryId = 6, IsDeleted = false }, // Tasty Bites -> Drinks

                new RestaurantCategory { RestaurantId = 2, CategoryId = 2, IsDeleted = false }, // Burger King -> Burgers
                new RestaurantCategory { RestaurantId = 2, CategoryId = 6, IsDeleted = false }, // Burger King -> Drinks

                new RestaurantCategory { RestaurantId = 3, CategoryId = 4, IsDeleted = false }, // Ginger -> Sushi
                new RestaurantCategory { RestaurantId = 3, CategoryId = 6, IsDeleted = false }, // Ginger -> Drinks

                new RestaurantCategory { RestaurantId = 4, CategoryId = 1, IsDeleted = false }, // PaPa John -> Pizza
                new RestaurantCategory { RestaurantId = 4, CategoryId = 6, IsDeleted = false }, // PaPa John -> Drinks

                new RestaurantCategory { RestaurantId = 5, CategoryId = 1, IsDeleted = false }, // Pizza Hut -> Pizza
                new RestaurantCategory { RestaurantId = 5, CategoryId = 5, IsDeleted = false }, // Pizza Hut -> Desserts
                new RestaurantCategory { RestaurantId = 5, CategoryId = 6, IsDeleted = false }, // Pizza Hut -> Drinks

                new RestaurantCategory { RestaurantId = 6, CategoryId = 5, IsDeleted = false },  // Sweet Delights -> Desserts
                new RestaurantCategory { RestaurantId = 6, CategoryId = 6, IsDeleted = false }  // Sweet Delights -> Drinks
            );
        }

        //----------------------------------------------------------------------------------------------------
        //Seed MenuItems
        public static void SeedMenuItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(
                // Tasty Bites (Pizza & Pasta & Drinks)
                new MenuItem { Id = 1, Name = "Margherita Pizza", Description = "Classic pizza with tomato sauce and mozzarella.", Price = 150m, ImageUrl = "MenuItemImages/Margherita Pizza.jpeg", RestaurantId = 1, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 2, Name = "Pepperoni Pizza", Description = "Spicy pepperoni with cheese on a crispy crust.", Price = 200m, ImageUrl = "MenuItemImages/Pepperoni Pizza.jpeg", RestaurantId = 1, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 3, Name = "BBQ Chicken Pizza", Description = "BBQ sauce with grilled chicken and red onions.", Price = 220m, ImageUrl = "MenuItemImages/BBQ.jpeg", RestaurantId = 1, CategoryId = 1, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 4, Name = "Spaghetti Bolognese", Description = "Traditional spaghetti with beef sauce.", Price = 145m, ImageUrl = "MenuItemImages/Red Wine Bolognese.jpeg", RestaurantId = 1, CategoryId = 3, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 5, Name = "Fettuccine Alfredo", Description = "Creamy Alfredo sauce with parmesan cheese.", Price = 170m, ImageUrl = "MenuItemImages/Fettuccine Alfredo.jpeg", RestaurantId = 1, CategoryId = 3, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 6, Name = "Penne Arrabbiata", Description = "Penne pasta in a spicy tomato sauce.", Price = 165m, ImageUrl = "MenuItemImages/Penne Arrabbiata.jpeg", RestaurantId = 1, CategoryId = 3, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 7, Name = "Mojito", Description = "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", Price = 50m, ImageUrl = "MenuItemImages/Moheto.jpeg", RestaurantId = 1, CategoryId = 6, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 8, Name = "V7 Pineapple ", Description = "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", Price = 35m, ImageUrl = "MenuItemImages/v7.jpg", RestaurantId = 1, CategoryId = 6, IsAvailable = true, IsDeleted = false },

                // Burger King (Burgers & Drinks)
                new MenuItem { Id = 9, Name = "Classic Cheeseburger", Description = "Beef patty with cheddar cheese and fresh lettuce.", Price = 175m, ImageUrl = "MenuItemImages/Classic Cheeseburger.jpeg", RestaurantId = 2, CategoryId = 2, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 10, Name = "Bacon Burger", Description = "Crispy bacon and melted cheese on a juicy patty.", Price = 180m, ImageUrl = "MenuItemImages/Bacon Burger.jpeg", RestaurantId = 2, CategoryId = 2, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 11, Name = "Mushroom Swiss Burger", Description = "Grilled mushrooms and Swiss cheese on a beef patty.", Price = 185m, ImageUrl = "MenuItemImages/Mushroom Swiss Burger.jpeg", RestaurantId = 2, CategoryId = 2, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 12, Name = "V7 Lemon", Description = "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", Price = 25m, ImageUrl = "MenuItemImages/v7_2.jpg", RestaurantId = 2, CategoryId = 6, IsAvailable = true, IsDeleted = false },

                // Ginger (Sushi & Drinks)
                new MenuItem { Id = 13, Name = "California Roll", Description = "Crab, avocado, and cucumber wrapped in seaweed.", Price = 60m, ImageUrl = "MenuItemImages/California Roll.jpeg", RestaurantId = 3, CategoryId = 4, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 14, Name = "Spicy Tuna Roll", Description = "Tuna mixed with spicy mayo and wrapped in rice.", Price = 52m, ImageUrl = "MenuItemImages/Spicy Tuna Roll.jpeg", RestaurantId = 3, CategoryId = 4, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 15, Name = "Dragon Roll", Description = "Eel, avocado, and cucumber topped with eel sauce.", Price = 55m, ImageUrl = "MenuItemImages/Dragon Roll.jpeg", RestaurantId = 3, CategoryId = 4, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 16, Name = "Orange Juice", Description = "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", Price = 60m, ImageUrl = "MenuItemImages/Oragne Juice.jpeg", RestaurantId = 3, CategoryId = 6, IsAvailable = true, IsDeleted = false },

                // PaPa John (Pizza & Drinks)
                new MenuItem { Id = 17, Name = "Four Cheese Pizza", Description = "Mozzarella, cheddar, parmesan, and gorgonzola.", Price = 185m, ImageUrl = "MenuItemImages/Four Cheese Pizza.jpeg", RestaurantId = 4, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 18, Name = "Veggie Supreme", Description = "Loaded with fresh veggies and tomato sauce.", Price = 180m, ImageUrl = "MenuItemImages/Hawaiian Pizza.jpeg", RestaurantId = 4, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 19, Name = "Hawaiian Pizza", Description = "Ham and pineapple on a cheesy base.", Price = 190m, ImageUrl = "MenuItemImages/Veggie Supreme.jpeg", RestaurantId = 4, CategoryId = 1, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 20, Name = "V7 Lemon", Description = "A bold and refreshing blend of zesty lemon with the energizing kick of V7.", Price = 25m, ImageUrl = "MenuItemImages/v7_2.jpg", RestaurantId = 4, CategoryId = 6, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 21, Name = "Mojito", Description = "A refreshing blend of zesty lime, fresh mint, and a hint of sweetness for a cool, invigorating taste.", Price = 55m, ImageUrl = "MenuItemImages/Moheto.jpeg", RestaurantId = 4, CategoryId = 6, IsAvailable = true, IsDeleted = false },

                //  Pizza Hut (Pizza & Desserts & Drinks)
                new MenuItem { Id = 22, Name = "Margherita Pizza", Description = "Classic pizza with tomato sauce and mozzarella.", Price = 160m, ImageUrl = "MenuItemImages/Margherita Pizza.jpeg", RestaurantId = 5, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 23, Name = "BBQ Chicken Pizza", Description = "BBQ sauce with grilled chicken and red onions.", Price = 220m, ImageUrl = "MenuItemImages/BBQ.jpeg", RestaurantId = 5, CategoryId = 1, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 24, Name = "Four Cheese Pizza", Description = "Mozzarella, cheddar, parmesan, and gorgonzola.", Price = 185m, ImageUrl = "MenuItemImages/Four Cheese Pizza.jpeg", RestaurantId = 5, CategoryId = 1, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 25, Name = "Chocolate Lava Cake", Description = "Warm chocolate cake with a gooey center.", Price = 80m, ImageUrl = "MenuItemImages/Chocolate Lava Cake.jpeg", RestaurantId = 5, CategoryId = 5, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 26, Name = "V7 Pineapple ", Description = "A tropical and invigorating blend of sweet pineapple with the energizing power of V7.", Price = 30m, ImageUrl = "MenuItemImages/v7.jpg", RestaurantId = 5, CategoryId = 6, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 27, Name = "Orange Juice", Description = "A refreshing, tangy-sweet juice bursting with citrus flavor and natural goodness.", Price = 40m, ImageUrl = "MenuItemImages/Oragne Juice.jpeg", RestaurantId = 5, CategoryId = 6, IsAvailable = true, IsDeleted = false },

                // Sweet Delights (Desserts & Drinks)
                new MenuItem { Id = 28, Name = "Molten Chocolate Cake", Description = "Rich chocolate cake with melted chocolate inside.", Price = 80m, ImageUrl = "MenuItemImages/Molten Chocolate Cake.jpeg", RestaurantId = 6, CategoryId = 5, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 29, Name = "Fruit Tart", Description = "Fresh fruits on a creamy custard base.", Price = 70m, ImageUrl = "MenuItemImages/Fruit Tart.jpeg", RestaurantId = 6, CategoryId = 5, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 30, Name = "Carrot Cake", Description = "Moist carrot cake with cream cheese frosting.", Price = 75m, ImageUrl = "MenuItemImages/Carrot Cake.jpeg", RestaurantId = 6, CategoryId = 5, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 31, Name = "Cheesecake", Description = "Creamy cheesecake with a graham cracker crust.", Price = 90m, ImageUrl = "MenuItemImages/Cheesecake.jpeg", RestaurantId = 6, CategoryId = 5, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 32, Name = "Tiramisu", Description = "Classic Italian coffee-flavored dessert.", Price = 95m, ImageUrl = "MenuItemImages/Tiramisu.jpeg", RestaurantId = 6, CategoryId = 5, IsAvailable = true, IsDeleted = false },

                new MenuItem { Id = 33, Name = "Ice Coffe", Description = "A refreshing, chilled coffee drink with bold flavors and a smooth finish.", Price = 120m, ImageUrl = "MenuItemImages/Iced Coffee.jpeg", RestaurantId = 6, CategoryId = 6, IsAvailable = true, IsDeleted = false },
                new MenuItem { Id = 34, Name = "Strwberry Milkshake", Description = "A creamy, sweet blend of fresh strawberries and milk, topped with a smooth, velvety finish.", Price = 100m, ImageUrl = "MenuItemImages/Strawberry Milkshake.jpeg", RestaurantId = 6, CategoryId = 6, IsAvailable = true, IsDeleted = false }

                );
        }



    }
}