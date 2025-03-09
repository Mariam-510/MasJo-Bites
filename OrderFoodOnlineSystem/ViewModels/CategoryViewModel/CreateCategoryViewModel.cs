using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.ViewModels.CategoryViewModel
{
    public class CreateCategoryViewModel
    {
        [DisplayName("Category ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
