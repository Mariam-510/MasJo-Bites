using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class RestaurantCategory
    {        
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }


}
