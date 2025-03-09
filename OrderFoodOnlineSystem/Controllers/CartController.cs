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
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.CartViewModels;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;
using static NuGet.Packaging.PackagingConstants;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        public ICartRepository CartRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        private readonly IMapper Mapper;
        private readonly IConfiguration _configuration;

        public CartController(ICartRepository cartRepository, IOrderItemRepository orderItemRepository,
            IMapper _mapper, IConfiguration configuration)
        {
            CartRepository = cartRepository;
            OrderItemRepository= orderItemRepository;
            Mapper = _mapper;
            _configuration = configuration;
        }

        public async Task<IActionResult> Details()
        {
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            //cart
            var cart = await CartRepository.GetByCustomerIdAsync(cusId);

            CartViewModel cartVm = new CartViewModel() { Id = 0, TotalPrice = 0 };

            if (cart != null)
            {
                cartVm = cart.CartVM();
                cart.SelectedAddressId = null;
                cart = await CartRepository.UpdateAsync(cart);
            }

            return View("Details", cartVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCartOrderItemViewModel orderItem, int cartId)
        {
            if (!ModelState.IsValid)
            {
                return View(orderItem);
            }
            var cart = await CartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                return NotFound();
            }
            var OrderItem = await OrderItemRepository.GetByIdAsync(id);
            if (OrderItem != null)
            {
                OrderItem.Quantity = orderItem.Quantity;
                
                var updatedOrderItem = await OrderItemRepository.UpdateOrderItemQuantityAsync(OrderItem);

                if (cart != null)
                {
                    await CartRepository.UpdateAsync(cart);
                }

            }

            var cartVM = cart.CartVM();

            return RedirectToAction("Details",new {id= cartVM.Id });


        }

        public async Task<IActionResult> ClearAllCart(int cartId)
        {
            var cart = await CartRepository.GetByIdAsync(cartId);

            if (cart == null)
            {
                return NotFound();
            }

            if (cart.OrderItems != null && cart.OrderItems.Any())
            {
                foreach (var orderItem in cart.OrderItems)
                {
                    await OrderItemRepository.DeleteAsync(orderItem.Id);
                }

            }
            cart.OrderItems = null;
            if (cart != null)
            {
                await CartRepository.UpdateAsync(cart);
            }

            return RedirectToAction("Details");

        }

        [HttpPost]
        public async Task<IActionResult> ClearCart(int cartId)
        {

            var cart = await CartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                return NotFound(new { message = "Cart not found" });
            }

            if (cart.OrderItems != null && cart.OrderItems.Any())
            {
                foreach (var orderItem in cart.OrderItems)
                {
                    await OrderItemRepository.DeleteAsync(orderItem.Id);
                }

            }

            cart.OrderItems = null;
            if (cart != null)
            {
                await CartRepository.UpdateAsync(cart);
            }

            return Json(new { success = true, message = "Cart cleared successfully" });
        }

        public async Task<IActionResult> Checkout(int addressId)
        {
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            //cart
            var cart = await CartRepository.GetByCustomerIdAsync(cusId);

            CartViewModel cartVm = new CartViewModel() { Id = 0, TotalPrice = 0 };

            if (cart != null)
            {
                cart.SelectedAddressId = addressId;
                await CartRepository.UpdateAsync(cart);
                
                cart = await CartRepository.GetByCustomerIdAsync(cusId);
                cartVm = cart.CartVM();
            }

            var clientId = _configuration["PayPalOptions:ClientId"];
            var clientSecret = _configuration["PayPalOptions:ClientSecret"];

            ViewBag.ClientId = clientId;

            return View("Checkout", cartVm);

        }

    }
}
