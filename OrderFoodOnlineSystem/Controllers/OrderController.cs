using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Models.Attributes;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.OrderViewModels;
using static NuGet.Packaging.PackagingConstants;
using Microsoft.AspNetCore.Authorization;

namespace OrderFoodOnlineSystem.Controllers
{
    public class OrderController : Controller
    {
        public IOrderRepository OrderRepository { get; }
        public ICartRepository CartRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }

        private readonly IMapper Mapper;


        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository,
            IOrderItemRepository orderItemRepository, IMapper _mapper)
        {
            OrderRepository = orderRepository;
            CartRepository = cartRepository;
            OrderItemRepository = orderItemRepository;
            Mapper = _mapper;

        }


        // GET: Order
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var orders = await OrderRepository.GetAllAsync();
            var viewModel = orders.Where(o => o.IsDeleted == false).Select(o => o.OrderVM()).ToList();

            return View(viewModel);
        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> GetAllRestaurantOrders()
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurantOrders = await OrderRepository.GetAllByRestaurantAsync(managerId);
            var restaurantManagerOrdersVM = restaurantOrders.RestaurantManagerOrdersInfo();

            return View(restaurantManagerOrdersVM);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllCustomerOrders()
        {
            string cusIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(cusIdStr, out int cusId))
            {
                return Unauthorized("Customer not found.");
            }
            var restaurantOrders = await OrderRepository.GetAllByCustomerAsync(cusId);
            var restaurantsVM = restaurantOrders.DOrdersVM();

            return View(restaurantsVM);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details(int id)
        {
            var order = await OrderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var viewModel = order.DOrderVM();

            return View(viewModel);
        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> DetailsRestaurant(int id)
        {
            var order = await OrderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var viewModel = order.DOrderVM();

            return View(viewModel);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PlaceOrder(PaymentMethod paymentMethod)
        {
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            //cart
            var cart = await CartRepository.GetByCustomerIdAsync(cusId);
            if (cart != null)
            {
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.Pending,
                    TotalPrice = cart.TotalPrice,
                    IsDeleted = false,
                    CustomerId = cart.CustomerId,
                    AddressId = cart.SelectedAddressId,
                    PaymentMethod = paymentMethod,
                    RestaurantId = cart.RestaurantId
                };

                order =  await OrderRepository.CreateAsync(order);

                if (cart.OrderItems != null)
                {
                    foreach (var orderItem in cart.OrderItems)
                    {
                        orderItem.CartId = null;
                        orderItem.OrderId = order.Id;

                        await OrderItemRepository.UpdateAsync(orderItem);
                    }
                }
                return RedirectToAction("Details", "Order", new { id = order.Id });
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> Edit(OrderViewModel order)
        {
            var orderModel = await OrderRepository.GetByIdAsync(order.Id);

            if (orderModel == null)
            {
                return NotFound("Order not found!");
            }

            orderModel.Status = order.Status;

            await OrderRepository.UpdateAsync(orderModel);

            var orderVM = orderModel.OrderVM();

            return RedirectToAction(nameof(GetAllRestaurantOrders));
        }
    }
}
