using System.ComponentModel.DataAnnotations;

namespace OrderSolution.Dtos
{
    public class CreateOrderDto
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string Product { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}
