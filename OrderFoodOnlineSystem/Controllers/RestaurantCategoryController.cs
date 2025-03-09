using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels.RestaurantCategoryViewModel;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;

namespace OrderFoodOnlineSystem.Controllers
{
    public class RestaurantCategoryController : Controller
    {
        public IRestaurantCategoryRepository _restaurantCategoryRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IFavouriteRestaurantRepository FavouriteRestaurantRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public IRestaurantRepository RestaurantRepository { get; }
        public IMapper _mapper { get; }

        public RestaurantCategoryController(IRestaurantCategoryRepository restaurantCategoryRepository,
            ICategoryRepository categoryRepository,IFavouriteRestaurantRepository favouriteRestaurantRepository,
            IReviewRepository reviewRepository,IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantCategoryRepository = restaurantCategoryRepository;
            CategoryRepository = categoryRepository;
            FavouriteRestaurantRepository = favouriteRestaurantRepository;
            ReviewRepository = reviewRepository;
            RestaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<ActionResult> GetAllCategories() //restaurantID
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);

            var categories = await _restaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(restaurant.Id);
            var categoriesVMs = _mapper.Map<List<Category>>(categories);

            return View(categoriesVMs);
        }

        public async Task<ActionResult> GetAllRestaurants(int id, string? restaurantName = null, string? filter = null) //categoryId
        {
            //restaurants
            ViewBag.restaurantName = restaurantName;
            var restaurants = await _restaurantCategoryRepository.GetAllRestaurantByCategoryAsync(id, restaurantName, filter);
            var restaurantVMs = _mapper.Map<List<RestaurantViewModel>>(restaurants);
            ViewBag.HasRestaurants = restaurantVMs.Any();

            //restaurants reviwes
            foreach (var restaurantVM in restaurantVMs)
            {
                restaurantVM.NumOfReviews = await ReviewRepository.GetCountOfRestaurantReviewsAsync(restaurantVM.Id);
            }

            //category name
            ViewBag.CategoryName = "";
            var category = await CategoryRepository.GetByIdAsync(id);
            if (category != null) {
                ViewBag.CategoryName = category.Name;
            }

            //favoriteRestaurants
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            var favouriteRestaurants = await FavouriteRestaurantRepository.GetAllByCustomerAsync(cusId);

            ViewBag.favoriteRestaurants = favouriteRestaurants;

            return View(restaurantVMs);
        }

        [HttpGet]
        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> AddCategory()
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);

            var categories = await CategoryRepository.GetAllMissingAsync(restaurant.Id);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var restaurantCategoryViewModel = new RestaurantCategoryViewModel
            {
                RestaurantId = restaurant.Id
            };

            return View(restaurantCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> AddCategory(RestaurantCategoryViewModel restaurantCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurantCategory = new RestaurantCategory
                {
                    RestaurantId = restaurantCategoryViewModel.RestaurantId,
                    CategoryId = restaurantCategoryViewModel.CategoryId
                };

                var exsistingRestaurantCategory = await _restaurantCategoryRepository.GetByIdAsync((int)restaurantCategory.RestaurantId, (int)restaurantCategory.CategoryId);

                if (exsistingRestaurantCategory != null)
                {
                    await _restaurantCategoryRepository.UpdateAsync((int)restaurantCategory.RestaurantId, (int)restaurantCategory.CategoryId, false);
                }
                else
                {
                    await _restaurantCategoryRepository.CreateAsync(restaurantCategory);
                }



                return RedirectToAction("GetAllCategories"); //Decide later
            }
            return View(restaurantCategoryViewModel);
        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            string ManagerIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(ManagerIdStr, out int managerId))
            {
                return Unauthorized("Manager not found.");
            }
            var restaurant = await RestaurantRepository.GetByManagerIdAsync(managerId);

            var restaurantCategory = await _restaurantCategoryRepository.GetByIdAsync(restaurant.Id, categoryId);

            if (restaurantCategory != null)
            {
                await _restaurantCategoryRepository.UpdateAsync(restaurant.Id, categoryId, true);

                return RedirectToAction("GetAllCategories");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
