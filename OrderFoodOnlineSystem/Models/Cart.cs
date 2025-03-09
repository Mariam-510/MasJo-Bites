using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Customer")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }


        [ForeignKey("Restaurant")]
        [Display(Name = "Restaurant")]
        public int? RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }


        [ForeignKey("SelectedAddress")]
        [Display(Name = "Delivery Address")]
        public int? SelectedAddressId { get; set; }
        public virtual Address? SelectedAddress { get; set; }


        [Display(Name = "Order Items")]
        public virtual IEnumerable<OrderItem>? OrderItems { get; set; }
    }

}
