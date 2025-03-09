using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Length(1, 50)]
        [Required]
        public string Name { get; set; }

        [Length(1, 200)]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        [DisplayName("Restaurant")]
        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
