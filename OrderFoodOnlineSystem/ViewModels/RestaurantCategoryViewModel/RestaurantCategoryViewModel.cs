using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantCategoryViewModel
{
    public class RestaurantCategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Restaurant Requiered")]
        [Display(Name = "Restaurant ")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        [Required(ErrorMessage = "Category Requiered")]
        [Display(Name = "Category ")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
