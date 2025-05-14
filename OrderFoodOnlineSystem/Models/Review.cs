using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(300)]
        public string? Comment { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Customer")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }


        [ForeignKey("Restaurant")]
        [Display(Name = "Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }

}