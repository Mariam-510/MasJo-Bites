using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderFoodOnlineSystem.Models.Attributes;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantViewModels
{
    public class AddRestaurantViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Restaurant Name Requiered")]
        [Display(Name = "Restaurant Name")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant Description Requiered")]
        [Display(Name = "Restaurant Description")]
        [MaxLength(200)]
        [MinLength(1)]
        public string Description { get; set; }

        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]

        public IFormFile Image { get; set; }

        [Required]
        public TimeOnly DateOpen { get; set; }

        [Required]
        public TimeOnly DateColse { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Delivery Fees")]
        public decimal DeliveryFees { get; set; } = 0;

        [Display(Name = "Restaurant Manager")]
        public int? RestaurantManagerId { get; set; }


    }
}
