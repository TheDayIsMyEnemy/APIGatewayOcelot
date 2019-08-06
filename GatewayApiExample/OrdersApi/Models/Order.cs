using System.ComponentModel.DataAnnotations;

namespace OrdersApi.Models
{
    public class Order
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
