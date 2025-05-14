using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using OrderFoodOnlineSystem.ViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.ViewModels.CartViewModels;


namespace OrderFoodOnlineSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ICategoryRepository CategoryRepository { get; }
        public IRestaurantRepository RestaurantRepository { get; }
        public IFavouriteRestaurantRepository FavouriteRestaurantRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public ICartRepository CartRepository { get; }
        public IMapper Mapper { get; }

        public HomeController(ICategoryRepository categoryRepository, IRestaurantRepository restaurantRepository,
            IFavouriteRestaurantRepository favouriteRestaurantRepository, IReviewRepository reviewRepository,
            ICartRepository cartRepository,IMapper mapper, ILogger<HomeController> logger)
        {
            CategoryRepository = categoryRepository;
            RestaurantRepository = restaurantRepository;
            FavouriteRestaurantRepository = favouriteRestaurantRepository;
            ReviewRepository = reviewRepository;
            CartRepository = cartRepository;
            Mapper = mapper;
            _logger = logger;
        }


        public async Task<ActionResult> Index()
        {
            //categories
            var categories = await CategoryRepository.GetAllAsync();

            //restaurants
            var restaurants = await RestaurantRepository.GetAllAsync();
            var restaurantVMs = Mapper.Map<List<RestaurantViewModel>>(restaurants).Take(6).ToList();

            foreach (var restaurantVM in restaurantVMs)
            {
                restaurantVM.NumOfReviews = await ReviewRepository.GetCountOfRestaurantReviewsAsync(restaurantVM.Id);
            }

            ViewBag.restaurantVMs = restaurantVMs;


            //favouriteRestaurants
            int cusId = 0;
            int.TryParse(User?.FindFirst("UserId")?.Value, out cusId);

            var favouriteRestaurants = await FavouriteRestaurantRepository.GetAllByCustomerAsync(cusId);

            ViewBag.favoriteRestaurants = favouriteRestaurants;

            return View(categories);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
