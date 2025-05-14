using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class RestaurantManager
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Account")]
        [Display(Name = "Account")]
        public string? AccountId { get; set; }
        public virtual Account? Account { get; set; }

    }
}
