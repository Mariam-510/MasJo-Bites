using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetAllByRestaurantAsync(int restaurantManagerId); //restaurant id
        Task<List<Order>> GetAllByCustomerAsync(int customerId); //customer id
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
