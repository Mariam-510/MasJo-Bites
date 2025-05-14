using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapper;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.CartViewModels;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;
using Org.BouncyCastle.Asn1.Ocsp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderItemController : Controller
    {
        public IOrderItemRepository OrderItemRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ICartRepository CartRepository { get; }
        public IMenuItemRepository MenuItemRepository { get; }

        private readonly IMapper Mapper;

        public OrderItemController(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository,
            IMapper _mapper, ICustomerRepository customerRepository, ICartRepository cartRepository, IMenuItemRepository menuItemRepository)
        {
            OrderItemRepository = orderItemRepository;
            OrderRepository = orderRepository;
            Mapper = _mapper;
            CustomerRepository = customerRepository;
            CartRepository = cartRepository;
            MenuItemRepository = menuItemRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderItemViewModel createOrderItemView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            string UserIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(UserIdStr, out int userId))
            {
                return Unauthorized("User not found.");
            }

            var customer = await CustomerRepository.GetByIdAsync(userId);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            var cart = await CartRepository.GetByCustomerIdAsync(customer.Id);
            var menuItem = await MenuItemRepository.GetByIdAsync(createOrderItemView.MenuItemId);

            if (cart == null || menuItem == null)
            {
                return NotFound("Cart or Menu item not found.");
            }

            var existingOrderItem = await OrderItemRepository.Exists(cart.Id, menuItem.Id);
            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += createOrderItemView.Quantity;
                existingOrderItem = await OrderItemRepository.UpdateOrderItemQuantityAsync(existingOrderItem);

                return Ok(new { message = "Item quantity updated in cart." });
            }
            else
            {
                // Check if all items are from the same restaurant
                if (cart.OrderItems == null || cart.OrderItems.Count() == 0 || cart.OrderItems.Any(o => o.MenuItem.RestaurantId == menuItem.RestaurantId))
                {
                    var orderItem = Mapper.Map<OrderItem>(createOrderItemView);
                    orderItem.CartId = cart.Id;
                    orderItem = await OrderItemRepository.CreateAsync(orderItem);

                    var newOrderItem = await OrderItemRepository.GetByIdAsync(orderItem.Id);
                    await CartRepository.UpdateRestaurantIdAsync(cart.Id, newOrderItem?.MenuItem?.RestaurantId);

                    return Ok(new { message = "Item added to cart successfully!" });
                }
                else
                {
                    return BadRequest("Can't add items from different restaurants.");
                }
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var orderItem = await OrderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            var viewModel = orderItem.EOrderVM();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] EditOrderItemViewModel editOrderItemViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid data" });
            }

            var orderItem = await OrderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound(new { success = false, message = "Order item not found" });
            }

            orderItem.Quantity = editOrderItemViewModel.Quantity;
            orderItem = await OrderItemRepository.UpdateOrderItemQuantityAsync(orderItem);

            if (orderItem == null)
            {
                return NotFound(new { success = false, message = "Update failed" });
            }


            // Recalculate overall total price
            string UserIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(UserIdStr, out int userId))
            {
                return Unauthorized("User not found.");
            }

            var cart = await CartRepository.GetByCustomerIdAsync(userId);
            decimal total = cart.TotalPrice;
            decimal subtotal = 0;
            if (cart.TotalPrice > 0)
            {
                subtotal = total - (cart.Restaurant?.DeliveryFees ?? 0);
            }

            return Json(new
            {
                success = true,
                subtotal = subtotal.ToString("F2"),  // Formats to 2 decimal places
                total = total.ToString("F2"),
                itemTotalPrice = orderItem.TotalPrice.ToString("F2"),
                orderItemId = id
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var orderItem = await OrderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound(new { success = false, message = "Order item not found" });
            }

            await OrderItemRepository.DeleteAsync(id);

            // Get user ID
            string userIdStr = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userIdStr, out int userId))
            {
                return Unauthorized("User not found.");
            }

            // Recalculate total price after deletion
            var cart = await CartRepository.GetByCustomerIdAsync(userId);
            decimal total = cart.TotalPrice;

            decimal subtotal = 0;
            if (cart.TotalPrice > 0)
            {
                subtotal = total - (cart.Restaurant?.DeliveryFees ?? 0);
            }


            return Json(new { success = true, subtotal, total });
        }


    }
}
