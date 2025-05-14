using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.ViewModels.OrderItemViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; } // Make sure this exists
        public int? OrderId { get; set; }
        public int? MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }


    }
}
