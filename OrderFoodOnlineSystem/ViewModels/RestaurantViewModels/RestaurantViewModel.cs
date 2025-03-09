using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderFoodOnlineSystem.Models.Attributes;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public TimeOnly DateOpen { get; set; }

        public TimeOnly DateColse { get; set; }
        public double AverageRating { get; set; }
        public int NumOfReviews { get; set; }
        public decimal DeliveryFees { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Restaurant Manager")]
        public int? RestaurantManagerId { get; set; }
        public virtual RestaurantManager? RestaurantManager { get; set; }

        [Display(Name = "Menu Items")]
        public virtual ICollection<CategoryMenuItem>? CategoryMenuItems { get; set; }


    }
}

