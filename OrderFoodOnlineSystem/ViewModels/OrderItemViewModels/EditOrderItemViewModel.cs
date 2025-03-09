using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.ViewModels.OrderItemViewModels
{
    public class EditOrderItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NonNegative]
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public decimal? TotalPrice { get; set; }

    }
}
