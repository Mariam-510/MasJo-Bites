using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantViewModels
{
    public class EditRestaurantViewModel
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

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]

        public IFormFile? Image { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public TimeOnly DateOpen { get; set; }

        [Required]
        public TimeOnly DateColse { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Delivery Fees")]
        public decimal DeliveryFees { get; set; }

        [Display(Name = "Restaurant Manager")]
        public int? RestaurantManagerId { get; set; }


    }
}
