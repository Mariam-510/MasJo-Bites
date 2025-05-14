using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.CartViewModels;
using OrderFoodOnlineSystem.Mapping;

namespace OrderFoodOnlineSystem.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public ICartRepository _cartRepository { get; }
        public IMapper _mapper { get; }

        public CartViewComponent(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int cusId = 0;

            // Access the current user's claims
            var userIdClaim = HttpContext.User?.FindFirst("UserId")?.Value;

            var userRoleClaim = HttpContext.User?.FindFirst("Role")?.Value;


            CartViewModel cartVm = new CartViewModel()
            {
                Id = 0,
                TotalPrice = 0,

            };

            if (userIdClaim != null && userRoleClaim=="Customer" && int.TryParse(userIdClaim, out cusId))
            {
                var cart = await _cartRepository.GetByCustomerIdAsync(cusId);

                if (cart != null)
                {
                    cartVm = cart.CartVM();
                }

                return View(cartVm); // Pass the CartViewModel to the view
            }

            // If the user is not authenticated or the claim is not found, return an empty CartViewModel
            return View(cartVm);
        }
    }
}
