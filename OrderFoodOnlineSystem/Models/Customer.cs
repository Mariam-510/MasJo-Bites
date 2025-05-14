using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name must contain only letters.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name must contain only letters.")]
        public string? LastName { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Account")]
        [Display(Name = "Account")]
        public string? AccountId { get; set; }
        public virtual Account? Account { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }

        [Display(Name = "Favourite Restaurants")]
        public virtual ICollection<FavouriteRestaurant>? FavouriteRestaurants { get; set; }
    }

}
