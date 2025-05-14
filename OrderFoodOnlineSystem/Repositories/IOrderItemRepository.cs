using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();
        Task<OrderItem?> GetByIdAsync(int id);
        Task<OrderItem> CreateAsync(OrderItem orderItem);
        Task<OrderItem?> UpdateOrderItemQuantityAsync(OrderItem orderItem);
        Task<OrderItem?> UpdateAsync(OrderItem orderItem);
        Task DeleteAsync(int id);
        Task<OrderItem?> Exists(int cartId, int menuItemId);
    }
}
