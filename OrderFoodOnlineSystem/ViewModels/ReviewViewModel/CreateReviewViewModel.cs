using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.ReviewViewModel
{
    public class CreateReviewViewModel
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(300)]
        public string? Comment { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("Customer")]
        [Required]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }


        [ForeignKey("Restaurant")]
        [Display(Name = "Restaurant")]
        [Required]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
