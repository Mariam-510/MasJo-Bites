using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.CartViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public int? SelectedAddressId { get; set; }
        public virtual Address? SelectedAddress { get; set; }
        public IEnumerable<OrderItemViewModel>? OrderItems { get; set; }

    }
}
