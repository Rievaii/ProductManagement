using MessagePack;
using Microsoft.Build.Framework;


namespace ProductManager.Data.Models
{
    public class Orders
    {

        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
