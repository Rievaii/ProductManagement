using MessagePack;
using Microsoft.Build.Framework;

namespace ProductManager.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
