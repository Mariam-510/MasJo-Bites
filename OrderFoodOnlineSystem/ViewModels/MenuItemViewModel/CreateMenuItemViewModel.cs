using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrderFoodOnlineSystem.Models.Attributes;

namespace OrderFoodOnlineSystem.ViewModels.MenuItemViewModel
{
    public class CreateMenuItemViewModel
    {
        [DisplayName("Item ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Item Name")]
        [Length(1, 50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("Item Description")]
        [Length(1, 200)]
        [Required]
        public string Description { get; set; }

        [DisplayName("Item Price")]
        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        [DisplayName("Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
