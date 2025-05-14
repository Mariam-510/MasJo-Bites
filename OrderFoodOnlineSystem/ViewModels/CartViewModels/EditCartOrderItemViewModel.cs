using OrderFoodOnlineSystem.Models.Attributes;

namespace OrderFoodOnlineSystem.ViewModels.CartViewModels
{
    public class EditCartOrderItemViewModel
    {

        public int Id { get; set; }
        
        [NonNegative]
        public int Quantity { get; set; }


    }
}
