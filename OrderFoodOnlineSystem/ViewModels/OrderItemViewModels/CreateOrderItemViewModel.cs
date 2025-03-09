using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderFoodOnlineSystem.Models.Attributes;

namespace OrderFoodOnlineSystem.ViewModels.OrderItemViewModels
{
    public class CreateOrderItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NonNegative]
        public int Quantity { get; set; }

        [ForeignKey("MenuItem")]
        [Display(Name = "Menu Item")]

        public int MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }

    }
}
