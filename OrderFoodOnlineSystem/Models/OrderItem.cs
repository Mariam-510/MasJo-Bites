using OrderFoodOnlineSystem.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFoodOnlineSystem.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NonNegative]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [NonNegative]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Order")]
        [Display(Name = "Order")]
        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }


        [ForeignKey("Cart")]
        [Display(Name = "Order")]
        public int? CartId { get; set; }
        public virtual Cart? Cart { get; set; }


        [ForeignKey("MenuItem")]
        [Display(Name = "Menu Item")]

        public int? MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }

    }

}
