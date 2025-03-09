using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Restaurant
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
        [RegularExpression(@".*\.(jpg|jpeg|png|gif)$", ErrorMessage = "The file must be an image with a valid extension (.jpg, .jpeg, .png, .gif).")]
        public string ImageUrl { get; set; }

        [Required]
        public TimeOnly DateOpen { get; set; }

        [Required]
        public TimeOnly DateColse { get; set; }

        public double AverageRating { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Delivery Fees")]
        public decimal DeliveryFees { get; set; } = 0;

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("RestaurantManager")]
        [Display(Name = "Restaurant Manager")]
        public int? RestaurantManagerId { get; set; }
        public virtual RestaurantManager? RestaurantManager { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        [Display(Name = "Restaurant Categories")]
        public virtual ICollection<RestaurantCategory>? RestaurantCategories { get; set; }

        [Display(Name = "Menu Items")]
        public virtual ICollection<MenuItem>? MenuItems { get; set; }
        
        public virtual ICollection<Review>? Reviews { get; set; }
        
        public virtual ICollection<FavouriteRestaurant>? FavouriteRestaurants { get; set; }
    }

}
