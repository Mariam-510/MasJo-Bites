using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;
using Org.BouncyCastle.Ocsp;

namespace OrderFoodOnlineSystem.Controllers
{
    public class FavouriteRestaurantController : Controller
    {
        public IMapper Mapper { get; }
        public IReviewRepository ReviewRepository { get; }
        public IFavouriteRestaurantRepository FavouriteRestaurantRepository { get; }
        public FavouriteRestaurantController(IMapper mapper, IReviewRepository reviewRepository,
            IFavouriteRestaurantRepository favouriteRestaurantRepository)
        {
            Mapper=mapper;
            ReviewRepository = reviewRepository;
            FavouriteRestaurantRepository = favouriteRestaurantRepository;
        }

        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetAllFavourites()
        {
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);
            var restaurants = await FavouriteRestaurantRepository.GetAllRestaurantByCustomerAsync(cusId);
            var restaurantVMs = Mapper.Map<List<RestaurantViewModel>>(restaurants);

            foreach (var restaurantVM in restaurantVMs)
            {
                restaurantVM.NumOfReviews = await ReviewRepository.GetCountOfRestaurantReviewsAsync(restaurantVM.Id);
            }

            return View(restaurantVMs);
        }
        
        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int restaurantId, int customerId)
        { 
            var favourite = await FavouriteRestaurantRepository.GetByIdAsync(restaurantId, customerId);

            if (favourite != null)
            {
                bool newStatus = favourite.IsDeleted ? false : true;
                await FavouriteRestaurantRepository.UpdateAsync(restaurantId, customerId, newStatus);
                return Json(new { success = true, message = "" });
            }
            else
            {
                var favouriteRestaurant = new FavouriteRestaurant
                {
                    RestaurantId = restaurantId,
                    CustomerId = customerId,
                    IsDeleted = false
                };
                await FavouriteRestaurantRepository.CreateAsync(favouriteRestaurant);
                return Json(new { success = true, message = "" });
            }
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Delete(int restaurantId, int customerId)
        {
            var favourite = await FavouriteRestaurantRepository.GetByIdAsync(restaurantId, customerId);

            if (favourite != null)
            {
                await FavouriteRestaurantRepository.UpdateAsync(restaurantId, customerId, true);
                
                return RedirectToAction("GetAllFavourites");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
