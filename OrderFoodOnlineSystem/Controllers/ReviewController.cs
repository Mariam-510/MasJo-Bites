using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.AddressViewModel;
using OrderFoodOnlineSystem.ViewModels.ReviewViewModel;

namespace OrderFoodOnlineSystem.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ReviewController : Controller
    {
        public IReviewRepository _reviewRepository { get; }
        public IRestaurantRepository RestaurantRepository { get; }

        public ReviewController(IReviewRepository reviewRepository,
            IRestaurantRepository restaurantRepository)
        {
            _reviewRepository = reviewRepository;
            RestaurantRepository = restaurantRepository;
        }

        
        public async Task<ActionResult> Index()
        {
            int cusId = 0;
            int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

            var reviews = await _reviewRepository.GetAllByCustomerAsync(cusId);

            return View(reviews);
        }

        public async Task<ActionResult> Create(int restaurantId)
        {
            var cusId = @User.FindFirst("UserId")?.Value;

            ViewBag.CustomerId = cusId;
            ViewBag.RestaurantId = restaurantId;

            var restaurant = await RestaurantRepository.GetByIdAsync(restaurantId);

            if(restaurant==null)
            {
                return NotFound();
            }
            ViewBag.RestaurantName = restaurant.Name;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateReviewViewModel createReviewViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var review = createReviewViewModel.AddReviewVM();
                    await _reviewRepository.CreateAsync(review);


                    return RedirectToAction("Details", "Restaurant", new {id = createReviewViewModel.RestaurantId});
                }
                else
                    return View(createReviewViewModel);
            }
            catch
            {
                return View(createReviewViewModel);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);

            if (review == null)
                return NotFound();

            var editReviewVM = review.EditReviewVM();

            return View(editReviewVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditReviewViewModel editReviewViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var reviewModel = await _reviewRepository.GetByIdAsync(id);
                    var reviewVM = editReviewViewModel.EditReviewVM();
                    var editedReview = await _reviewRepository.UpdateAsync(id, reviewVM);
                    if (editedReview != null)
                        return RedirectToAction(nameof(Index));
                    else
                        return NotFound("Review not found!");
                }
                else
                    return View(editReviewViewModel);
            }
            catch
            {
                return View(editReviewViewModel);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var review = await _reviewRepository.DeleteAsync(id);
                    if(review == null)
                        return NotFound();
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
