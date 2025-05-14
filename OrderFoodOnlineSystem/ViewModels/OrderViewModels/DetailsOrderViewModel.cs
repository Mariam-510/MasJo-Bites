using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;

namespace OrderFoodOnlineSystem.ViewModels.OrderViewModels
{
    public class DetailsOrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer? Customer { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Address? Address { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public IEnumerable<OrderItemViewModel>? OrderItems { get; set; } 


    }
}
