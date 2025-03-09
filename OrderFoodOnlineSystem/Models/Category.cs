using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Category
    {
        [DisplayName("Category ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<RestaurantCategory>? RestaurantCategories { get; set; }
    }
}
