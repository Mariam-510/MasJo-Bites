using OrderFoodOnlineSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrderFoodOnlineSystem.ViewModels.AddressViewModel
{
    public class EditAddressViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Building Number")]
        public string BuildingNum { get; set; }

        [MaxLength(20)]
        public string Apartment { get; set; }

        [MaxLength(20)]
        public string Floor { get; set; }

        [MaxLength(15)]
        [DisplayName("Phone Number")]
        public string PhoneNum { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
