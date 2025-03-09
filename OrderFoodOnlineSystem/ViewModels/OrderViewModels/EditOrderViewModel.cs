using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.OrderViewModels
{
    public class EditOrderViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
