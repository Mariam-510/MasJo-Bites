using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.ViewModels.AccountViewModels;
using OrderFoodOnlineSystem.ViewModels.AddressViewModel;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;
using OrderFoodOnlineSystem.ViewModels.CartViewModels;
using OrderFoodOnlineSystem.ViewModels.CategoryViewModel;
using OrderFoodOnlineSystem.ViewModels.CustomerViewModels;
using OrderFoodOnlineSystem.ViewModels.MenuItemViewModel;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;
using OrderFoodOnlineSystem.ViewModels.OrderViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantManagerViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;
using OrderFoodOnlineSystem.ViewModels.ReviewViewModel;

namespace OrderFoodOnlineSystem.Mapping
{
    public static class ManualMapperProfiles
    {
        //----------------------------------------------------------------------------------------
        //Account
        public static Account RegisterCustomer(this RegisterCustomerViewModel registerCustomerViewModel)
        {
            return new Account
            {
                Email = registerCustomerViewModel.Email,
                UserName = registerCustomerViewModel.Email
            };
        }

        public static Account RegisterAdmin(this CreateAdminViewModel createAdminViewModel)
        {
            return new Account
            {
                Email = createAdminViewModel.Email,
                UserName = createAdminViewModel.Email
            };
        }

        public static Account RegisterRestaurantManager(this CreateRestaurantManagerViewModel createRestaurantManagerViewModel)
        {
            return new Account
            {
                Email = createRestaurantManagerViewModel.Email,
                UserName = createRestaurantManagerViewModel.Email
            };
        }

        public static ResetPasswordViewModel ResetPasswordVM(this Account account)
        {
            return new ResetPasswordViewModel
            {
                Email = account.Email,
            };
        }

        //----------------------------------------------------------------------------------------
        //Admin
        public static List<AdminViewModel> AdminsInfo(this List<Admin> admins)
        {
            var adminViewModelList = new List<AdminViewModel>();
            foreach (var admin in admins)
            {
                adminViewModelList.Add(
                    new AdminViewModel
                    {
                        Id = admin.Id,
                        Name = admin.Name,
                        Email = admin.Account?.Email ?? "N/A",
                    }
                    );
            }
            return adminViewModelList;
        }

        public static AdminViewModel AdminInfo(this Admin admin)
        {
            return new AdminViewModel
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Account?.Email ?? "N/A",
            };
        }

        public static Admin CreateAdmin(this CreateAdminViewModel createAdminViewModel)
        {
            return new Admin
            {
                Name = createAdminViewModel.Name,
            };
        }

        public static UpdateAdminViewModel UpdateAdmin(this Admin admin)
        {
            return new UpdateAdminViewModel
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Account?.Email ?? "N/A",
            };
        }

        public static Admin UpdateAdmin(this UpdateAdminViewModel updateAdminViewModel)
        {
            return new Admin
            {
                Name = updateAdminViewModel.Name
            };
        }

        //----------------------------------------------------------------------------------------
        //RestaurantManager
        public static List<RestaurantManagerViewModel> RestaurantManagersInfo(this List<RestaurantManager> restaurantManagers)
        {
            var RestaurantManagerViewModelList = new List<RestaurantManagerViewModel>();
            foreach (var restaurantManager in restaurantManagers)
            {
                RestaurantManagerViewModelList.Add(
                    new RestaurantManagerViewModel
                    {
                        Id = restaurantManager.Id,
                        Name = restaurantManager.Name,
                        Email = restaurantManager.Account?.Email ?? "N/A",
                        //RestaurantId = restaurantManager.RestaurantId ?? 0,
                        //RestaurantName = restaurantManager.Restaurant?.Name ?? "N/A",
                    }
                    );
            }
            return RestaurantManagerViewModelList;
        }

        public static RestaurantManagerViewModel RestaurantManagerInfo(this RestaurantManager restaurantManager)
        {
            return new RestaurantManagerViewModel
            {
                Id = restaurantManager.Id,
                Name = restaurantManager.Name,
                Email = restaurantManager.Account?.Email ?? "N/A",
                //RestaurantId = restaurantManager.RestaurantId ?? 0,
                //RestaurantName = restaurantManager.Restaurant?.Name ?? "N/A",
            };
        }

        public static RestaurantManager CreateRestaurantManager(this CreateRestaurantManagerViewModel createRestaurantManagerView)
        {
            return new RestaurantManager
            {
                Name = createRestaurantManagerView.Name,
                //RestaurantId = createRestaurantManagerView.RestaurantId,
            };
        }

        public static UpdateRestaurantManagerViewModel UpdateRestaurantManager(this RestaurantManager restaurantManager)
        {
            return new UpdateRestaurantManagerViewModel
            {
                Id = restaurantManager.Id,
                Name = restaurantManager.Name,
                Email = restaurantManager.Account?.Email ?? "N/A",
                //RestaurantId = restaurantManager.RestaurantId
            };
        }

        public static RestaurantManager UpdateRestaurantManager(this UpdateRestaurantManagerViewModel updateRestaurantManagerView)
        {
            return new RestaurantManager
            {
                Name = updateRestaurantManagerView.Name,
                //RestaurantId = updateRestaurantManagerView.RestaurantId
            };
        }

        //----------------------------------------------------------------------------------------
        //Customer
        public static Customer CreateCustomer(this RegisterCustomerViewModel registerCustomerViewModel)
        {
            return new Customer
            {
                FirstName = registerCustomerViewModel.FirstName,
                LastName = registerCustomerViewModel.LastName,
            };
        }

        public static List<CustomerViewModel> CustomersInfo(this List<Customer> customers)
        {
            var customerViewModelList = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                customerViewModelList.Add(
                    new CustomerViewModel
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Account?.Email ?? "N/A",
                    }
                    );
            }
            return customerViewModelList;
        }

        public static CustomerViewModel CustomerInfo(this Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Account?.Email ?? "N/A",
            };
        }

        public static UpdateCustomerViewModel UpdateCustomer(this Customer customer)
        {
            return new UpdateCustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Account?.Email ?? "N/A",
            };
        }

        public static Customer UpdateCustomer(this UpdateCustomerViewModel updateCustomerViewModel)
        {
            return new Customer
            {
                FirstName = updateCustomerViewModel.FirstName,
                LastName = updateCustomerViewModel.LastName,
            };
        }

        //----------------------------------------------------------------------------------------
        //Restaurant
        public static Restaurant AddRestaurant(this AddRestaurantViewModel addRestaurantViewModel)
        {
            return new Restaurant
            {
                Id = addRestaurantViewModel.Id,
                Name = addRestaurantViewModel.Name,
                Description = addRestaurantViewModel.Description,
                DateOpen = addRestaurantViewModel.DateOpen,
                DateColse = addRestaurantViewModel.DateColse,
                DeliveryFees = addRestaurantViewModel.DeliveryFees,
                RestaurantManagerId = addRestaurantViewModel.RestaurantManagerId,
            };
        }

        public static EditRestaurantViewModel EditRestaurantVM(this Restaurant Restaurant)
        {
            return new EditRestaurantViewModel
            {
                Id = Restaurant.Id,
                Name = Restaurant.Name,
                Description = Restaurant.Description,
                DateOpen = Restaurant.DateOpen,
                DateColse = Restaurant.DateColse,
                RestaurantManagerId = Restaurant.RestaurantManagerId,
                DeliveryFees = Restaurant.DeliveryFees,
                ImageUrl = Restaurant.ImageUrl
            };
        }

        public static Restaurant EditVMToRestaurant(this EditRestaurantViewModel editRestaurantViewModel)
        {
            return new Restaurant
            {
                Id = editRestaurantViewModel.Id,
                Name = editRestaurantViewModel.Name,
                Description = editRestaurantViewModel.Description,
                DateOpen = editRestaurantViewModel.DateOpen,
                DateColse = editRestaurantViewModel.DateColse,
                RestaurantManagerId = editRestaurantViewModel.RestaurantManagerId,
                DeliveryFees = editRestaurantViewModel.DeliveryFees,
                ImageUrl = editRestaurantViewModel.ImageUrl
            };
        }

        //----------------------------------------------------------------------------------------
        //Category
        public static Category AddCategoryVM(this CreateCategoryViewModel createCategoryViewModel)
        {
            return new Category
            {
                Id = createCategoryViewModel.Id,
                Name = createCategoryViewModel.Name,
                ImageUrl = createCategoryViewModel.ImageUrl,
            };
        }

        public static Category EditCategoryVM(this EditCategoryViewModel editCategoryViewModel)
        {
            return new Category
            {
                Id = editCategoryViewModel.Id,
                Name = editCategoryViewModel.Name,
                ImageUrl = editCategoryViewModel.ImageUrl,
                IsDeleted = editCategoryViewModel.IsDeleted
            };
        }

        public static EditCategoryViewModel EditCategoryVM(this Category category)
        {
            return new EditCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                IsDeleted = category.IsDeleted
            };
        }

        //----------------------------------------------------------------------------------------
        //MenuItem
        public static MenuItem AddMenuItemVM(this CreateMenuItemViewModel createMenuItemViewModel)
        {
            return new MenuItem
            {
                Id = createMenuItemViewModel.Id,
                Name = createMenuItemViewModel.Name,
                Description = createMenuItemViewModel.Description,
                Price = createMenuItemViewModel.Price,
                ImageUrl = createMenuItemViewModel.ImageUrl,
                IsAvailable = createMenuItemViewModel.IsAvailable,
                IsDeleted = createMenuItemViewModel.IsDeleted,
                RestaurantId = createMenuItemViewModel.RestaurantId ?? 0,
                CategoryId = createMenuItemViewModel.CategoryId ?? 0
            };
        }

        public static MenuItem EditMenuItemVM(this EditMenuItemViewModel editMenuItemViewModel)
        {
            return new MenuItem
            {
                Id = editMenuItemViewModel.Id,
                Name = editMenuItemViewModel.Name,
                Description = editMenuItemViewModel.Description,
                Price = editMenuItemViewModel.Price,
                IsAvailable = editMenuItemViewModel.IsAvailable,
                CategoryId = editMenuItemViewModel.CategoryId ?? 0
            };
        }

        public static EditMenuItemViewModel EditMenuItemVM(this MenuItem menuItem)
        {
            return new EditMenuItemViewModel
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                ImageUrl = menuItem.ImageUrl,
                IsAvailable = menuItem.IsAvailable,
                CategoryId = menuItem.CategoryId ?? 0
            };
        }

        //----------------------------------------------------------------------------------------
        //Address
        public static Address AddAddressVM(this CreateAddressViewModel createAddressViewModel)
        {
            return new Address
            {
                Id = createAddressViewModel.Id,
                City = createAddressViewModel.City,
                Street = createAddressViewModel.Street,
                BuildingNum = createAddressViewModel.BuildingNum,
                Apartment = createAddressViewModel.Apartment,
                Floor = createAddressViewModel.Floor,
                PhoneNum = createAddressViewModel.PhoneNum,
                IsDeleted = createAddressViewModel.IsDeleted,
                CustomerId = createAddressViewModel.CustomerId ?? 0
            };
        }

        public static Address EditAddressVM(this EditAddressViewModel editAddressViewModel)
        {
            return new Address
            {
                Id = editAddressViewModel.Id,
                City = editAddressViewModel.City,
                Street = editAddressViewModel.Street,
                BuildingNum = editAddressViewModel.BuildingNum,
                Apartment = editAddressViewModel.Apartment,
                Floor = editAddressViewModel.Floor,
                PhoneNum = editAddressViewModel.PhoneNum,
                IsDeleted = editAddressViewModel.IsDeleted,
                CustomerId = editAddressViewModel.CustomerId ?? 0
            };
        }

        public static EditAddressViewModel EditAddressVM(this Address address)
        {
            return new EditAddressViewModel
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                BuildingNum = address.BuildingNum,
                Apartment = address.Apartment,
                Floor = address.Floor,
                PhoneNum = address.PhoneNum,
                IsDeleted = address.IsDeleted,
                CustomerId = address.CustomerId ?? 0
            };
        }

        //----------------------------------------------------------------------------------------
        //Review
        public static Review AddReviewVM(this CreateReviewViewModel createReviewViewModel)
        {
            return new Review
            {
                Id = createReviewViewModel.Id,
                Rating = createReviewViewModel.Rating,
                Comment = createReviewViewModel.Comment,
                Date = createReviewViewModel.Date,
                CustomerId = createReviewViewModel.CustomerId ?? 0,
                RestaurantId = createReviewViewModel.RestaurantId ?? 0
            };
        }

        public static Review EditReviewVM(this EditReviewViewModel editReviewViewModel)
        {
            return new Review
            {
                Id = editReviewViewModel.Id,
                Rating = editReviewViewModel.Rating,
                Comment = editReviewViewModel.Comment,
                Date = editReviewViewModel.Date,
                CustomerId = editReviewViewModel.CustomerId ?? 0,
                RestaurantId = editReviewViewModel.RestaurantId ?? 0,
            };
        }

        public static EditReviewViewModel EditReviewVM(this Review review)
        {
            return new EditReviewViewModel
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                Date = review.Date,
                CustomerId = review.CustomerId ?? 0,
                RestaurantId = review.RestaurantId ?? 0,
                Restaurant = review.Restaurant,
                Customer = review.Customer
            };
        }

        //----------------------------------------------------------------------------------------
        //OrderItem
        public static OrderItemViewModel OrderItemVM(this OrderItem orderItem)
        {
            return new OrderItemViewModel
            {
                Id = orderItem.Id,
                Name = orderItem.MenuItem.Name,
                Quantity = orderItem.Quantity,
                TotalPrice = orderItem.Quantity * orderItem.MenuItem.Price,

            };
        }

        public static EditOrderItemViewModel EOrderVM(this OrderItem orderItem)
        {
            return new EditOrderItemViewModel
            {
                Id = orderItem.Id,
                Name = orderItem.MenuItem.Name,
                Quantity = orderItem.Quantity,
                TotalPrice = orderItem.Quantity * orderItem.MenuItem.Price,


            };
        }

        //----------------------------------------------------------------------------------------
        //Cart
        public static CartViewModel CartVM(this Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                RestaurantId = cart.RestaurantId,
                Restaurant = cart.Restaurant,

                SelectedAddressId = cart.SelectedAddressId,
                SelectedAddress = cart.SelectedAddress,


                OrderItems = cart.OrderItems.Where(o => !o.IsDeleted).Select(oi => new OrderItemViewModel
                {
                    Id = oi.Id,
                    Name = oi.MenuItem.Name,
                    Quantity = oi.Quantity,
                    TotalPrice = oi.TotalPrice,
                    MenuItemId = oi.MenuItemId,
                    MenuItem = oi.MenuItem
                }).ToList(),

                TotalPrice = cart.TotalPrice

            };
        }

        //----------------------------------------------------------------------------------------
        //Order
        public static List<OrderViewModel> RestaurantManagerOrdersInfo(this List<Order> restaurantOrders)
        {
            var RestaurantManagerOrdersViewModelList = new List<OrderViewModel>();
            foreach (var restaurantOrder in restaurantOrders)
            {
                RestaurantManagerOrdersViewModelList.Add(
                    new OrderViewModel
                    {
                        Id = restaurantOrder.Id,
                        OrderDate = restaurantOrder.OrderDate,
                        CustomerName = string.Concat(restaurantOrder.Customer.FirstName, " ", restaurantOrder.Customer.LastName),
                        RestaurantName = restaurantOrder.Restaurant.Name,
                        AddressDetails = string.Concat(restaurantOrder.Address.City, " ", restaurantOrder.Address.Street, " ", restaurantOrder.Address.BuildingNum, ",", restaurantOrder.Address.Floor, ",", restaurantOrder.Address.Apartment),
                        TotalPrice = restaurantOrder.TotalPrice,
                        Status = restaurantOrder.Status,
                    });
            }
            return RestaurantManagerOrdersViewModelList;
        }

        public static OrderViewModel OrderVM(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                CustomerName = string.Concat(order.Customer.FirstName, order.Customer.LastName),
                RestaurantName = order.Restaurant.Name,
                AddressDetails = string.Concat(order.Address.City, order.Address.Street, order.Address.BuildingNum, order.Address.Floor, order.Address.Apartment),
                TotalPrice = order.TotalPrice,
                Status = order.Status,


            };
        }
        
        public static DetailsOrderViewModel DOrderVM(this Order order)
        {
            return new DetailsOrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Customer = order.Customer,
                Restaurant = order.Restaurant,
                Address = order.Address,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                PaymentMethod = order.PaymentMethod,
                OrderItems = order.OrderItems.Where(oi => oi.IsDeleted == false).Select(oi => new OrderItemViewModel
                {
                    Id = oi.Id,
                    Name = oi.MenuItem.Name,
                    Quantity = oi.Quantity,
                    TotalPrice = oi.TotalPrice,
                    MenuItemId = oi.MenuItemId,
                    MenuItem = oi.MenuItem
                }).ToList()


            };
        }

        public static List<DetailsOrderViewModel> DOrdersVM(this List<Order> orders)
        {
            var ordersViewModelList = new List<DetailsOrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModelList.Add(new DetailsOrderViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    Customer = order.Customer,
                    Restaurant = order.Restaurant,
                    Address = order.Address,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    PaymentMethod = order.PaymentMethod,
                    OrderItems = order.OrderItems.Where(oi => oi.IsDeleted == false).Select(oi => new OrderItemViewModel
                    {
                        Id = oi.Id,
                        Name = oi.MenuItem.Name,
                        Quantity = oi.Quantity,
                        TotalPrice = oi.TotalPrice,
                        MenuItemId = oi.MenuItemId,
                        MenuItem = oi.MenuItem
                    }).ToList()
                });
            }
            return ordersViewModelList;
        }

   
    }
}
