using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class FavouriteRestaurant
    {
        public DateTime DateTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Display(Name = "Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
