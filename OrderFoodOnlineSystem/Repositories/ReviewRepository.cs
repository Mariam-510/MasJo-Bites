using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public OrderFoodDbContext _context { get; }

        public ReviewRepository(OrderFoodDbContext context, IRestaurantRepository restaurantRepository)
        {
            _context = context;
            _restaurantRepository = restaurantRepository;
        }

        public Task<List<Review>> GetAllAsync()
        {
            return _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .Where(r => r.IsDeleted == false)
                .ToListAsync();
        }

        public Task<List<Review>> GetAllByRestaurantAsync(int restaurantId)
        {
            return _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .Where(r => r.IsDeleted == false && r.RestaurantId==restaurantId)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public Task<int> GetCountOfRestaurantReviewsAsync(int restaurantId)
        {
            return _context.Reviews
                .Where(r => r.IsDeleted == false && r.RestaurantId == restaurantId)
                .CountAsync();
        }


        public Task<List<Review>> GetAllByCustomerAsync(int customerId)
        {
            return _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .Where(r => r.IsDeleted == false && r.CustomerId == customerId)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }


        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Review?> CreateAsync(Review Review)
        {
            if (Review != null)
            {
                _context.Reviews.Add(Review);
                await _context.SaveChangesAsync();
                await _restaurantRepository.CalculateAverageRating(Review.RestaurantId);
                return Review;
            }
            return null;
        }


        public async Task<Review?> UpdateAsync(int id, Review Review)
        {
            var updatedReview = await GetByIdAsync(id);

            if (updatedReview != null)
            {
                updatedReview.Rating = Review.Rating;
                updatedReview.Comment = Review.Comment;
                updatedReview.Date = Review.Date;

                await _context.SaveChangesAsync();

                await _restaurantRepository.CalculateAverageRating(Review.RestaurantId);
                return updatedReview;
            }
            else
                return null;
        }


        public async Task<Review?> DeleteAsync(int id)
        {
            var deletedRev = await GetByIdAsync(id);

            if (deletedRev != null)
            {
                deletedRev.IsDeleted = true;
                await _context.SaveChangesAsync();

                await _restaurantRepository.CalculateAverageRating(deletedRev.RestaurantId);
                return deletedRev;
            }
            return null;
        }


    }
}
