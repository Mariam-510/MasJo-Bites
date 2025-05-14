using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.RestaurantManagerViewModels
{
    public class DeleteRestaurantManagerViewModel
    {
        public List<RestaurantManagerViewModel>? RestaurantManagers { get; set; } = new List<RestaurantManagerViewModel>();

        [Required(ErrorMessage = "Please select a restaurant manager.")]
        public int RestaurantManagerId { get; set; }
    }
}
