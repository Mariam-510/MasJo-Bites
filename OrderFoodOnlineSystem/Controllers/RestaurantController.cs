using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.Services;
using OrderFoodOnlineSystem.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using NuGet.Packaging.Signing;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;
using OrderFoodOnlineSystem.ViewModels.AdminViewModels;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;


namespace OrderFoodOnlineSystem.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository RestaurantRepository;
        private readonly IRestaurantManagerRepository RestaurantManagerRepository;
        private readonly IRestaurantCategoryRepository _restaurantCategoryRepository;

        public FileService FileService { get; }
        public IFavouriteRestaurantRepository FavouriteRestaurantRepository { get; }
        public IReviewRepository ReviewRepository { get; }

        public RestaurantController(IMapper mapper, IRestaurantRepository restaurantRepository,
            FileService fileService, IRestaurantManagerRepository restaurantManagerRepository,
            IFavouriteRestaurantRepository favouriteRestaurantRepository, IReviewRepository reviewRepository,
            IRestaurantCategoryRepository restaurantCategoryRepository)
        {
            _mapper = mapper;
            RestaurantRepository = restaurantRepository;
            FileService = fileService;
            RestaurantManagerRepository = restaurantManagerRepository;
            FavouriteRestaurantRepository = favouriteRestaurantRepository;
            ReviewRepository = reviewRepository;
            _restaurantCategoryRepository = restaurantCategoryRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            var restaurants = await RestaurantRepository.GetAllAsync();
            var restaurantVMs = _mapper.Map<List<RestaurantViewModel>>(restaurants);

            return View(restaurantVMs);
        }

        public async Task<ActionResult> GetAll(string? restaurantName = null, string? filter = null)
        {
            //restaurants
            ViewBag.restaurantName = restaurantName;
            var restaurants = await RestaurantRepository.GetAllAsync(restaurantName, filter);
            var restaurantVMs = _mapper.Map<List<RestaurantViewModel>>(restaurants);
            ViewBag.HasRestaurants = restaurantVMs.Any();

            //restaurants reviwes
            foreach (var restaurantVM in restaurantVMs)
            {
                restaurantVM.NumOfReviews = await ReviewRepository.GetCountOfRestaurantReviewsAsync(restaurantVM.Id);
            }

            //favoriteRestaurants
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            var favouriteRestaurants = await FavouriteRestaurantRepository.GetAllByCustomerAsync(cusId);

            ViewBag.favoriteRestaurants = favouriteRestaurants;

            return View(restaurantVMs);
        }

        public async Task<ActionResult> Details(int id)
        {
            //restaurant
            var restaurant = await RestaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            var restaurantVM = _mapper.Map<RestaurantViewModel>(restaurant);

            //categories
            var categories = await _restaurantCategoryRepository.GetAllCategoriesByRestaurantAsync(id);

            List<CategoryMenuItem> categoryMenuItems = new List<CategoryMenuItem>();

            //menuItems
            foreach (var category in categories)
            {
                categoryMenuItems.Add(
                    new CategoryMenuItem()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        MenuItems = restaurant.MenuItems.Where(m => !m.IsDeleted && m.CategoryId == category.Id).OrderBy(m => m.Name).ToList(),
                    }
                    );
            }

            restaurantVM.CategoryMenuItems = categoryMenuItems;

            //Reviews Num
            restaurantVM.NumOfReviews = await ReviewRepository.GetCountOfRestaurantReviewsAsync(restaurantVM.Id);

            //Reviews
            var reviews = await ReviewRepository.GetAllByRestaurantAsync(restaurantVM.Id);

            ViewBag.Reviews = reviews;

            //favoriteRestaurants
            int cusId = 0;
            int.TryParse(User.FindFirst("UserId")?.Value, out cusId);

            var favouriteRestaurants = await FavouriteRestaurantRepository.GetAllByCustomerAsync(cusId);

            ViewBag.favoriteRestaurants = favouriteRestaurants;

            return View(restaurantVM);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            string AdminIdStr = User.FindFirst("UserId")?.Value;

            if (!int.TryParse(AdminIdStr, out int adminId))
            {
                return Unauthorized("Admin not found.");
            }

            var managers = await RestaurantManagerRepository.GetAllAsync();
            ViewBag.ResID = new SelectList(managers, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(AddRestaurantViewModel restaurantFormViewModel)
        {
            try
            {
                var managers = await RestaurantManagerRepository.GetAllAsync();
                ViewBag.ResID = new SelectList(managers, "Id", "Name", restaurantFormViewModel.RestaurantManagerId);

                if (ModelState.IsValid)
                {
                    var restaurant = restaurantFormViewModel.AddRestaurant();
                    restaurant.ImageUrl = FileService.UploadFile("RestaurantImages", restaurantFormViewModel.Image);

                    if (restaurant.ImageUrl != null)
                    {
                        await RestaurantRepository.CreateAsync(restaurant);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred. Please try again.");
                        return View(restaurantFormViewModel);
                    }

                }

                return View(restaurantFormViewModel);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(restaurantFormViewModel);
            }

        }

        [Authorize(Roles = "RestaurantManager")]
        public async Task<ActionResult> Edit(int id)
        {
            var restaurant = await RestaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var managers = await RestaurantManagerRepository.GetAllAsync();
            ViewBag.ResID = new SelectList(managers, "Id", "Name");

            var editRestaurantViewModel = restaurant.EditRestaurantVM();

            return View(editRestaurantViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantManager")]
        public async Task<ActionResult> Edit(int id, EditRestaurantViewModel editRestaurantViewModel)
        {
            var managers = await RestaurantManagerRepository.GetAllAsync();
            ViewBag.ResID = new SelectList(managers, "Id", "Name", editRestaurantViewModel.RestaurantManagerId);
            try
            {
                if (ModelState.IsValid)
                {
                    var restuarant = editRestaurantViewModel.EditVMToRestaurant();
                    if (editRestaurantViewModel.Image != null)
                    {
                        restuarant.ImageUrl = FileService.UpdateFile("RestaurantImages", editRestaurantViewModel.Image, editRestaurantViewModel.ImageUrl);
                        if (restuarant.ImageUrl == null)
                        {
                            ModelState.AddModelError("", "An error occurred. Please try again.");
                            return View(editRestaurantViewModel);
                        }
                    }
                    var editedProduct = await RestaurantRepository.UpdateAsync(id, restuarant);
                    if (editedProduct == null)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Index));

                }
                return View(editRestaurantViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred. Please try again.");
                return View(editRestaurantViewModel);
            }
        }

        [Authorize(Roles = "Admin, RestaurantManager")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                string AdminIdStr = User.FindFirst("UserId")?.Value;

                if (!int.TryParse(AdminIdStr, out int adminId))
                {
                    return Unauthorized("Admin not found.");
                }

                var restaurant = await RestaurantRepository.GetByIdAsync(id);
                if (restaurant == null)
                {
                    return NotFound();
                }
                else
                {
                    restaurant = await RestaurantRepository.DeleteAsync(id);
                    FileService.DeleteFile(restaurant.ImageUrl);
                    if (restaurant == null)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }

        }
    }
}
