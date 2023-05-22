using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
