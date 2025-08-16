using System.ComponentModel.DataAnnotations;

namespace Pub_Mangement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(120)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? MobileNo { get; set; }
    }
}
