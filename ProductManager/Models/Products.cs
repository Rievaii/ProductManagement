using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class Products
    {
        [Required]
        public string Name { get; set; }

        [Key]
        public int Id { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

    }
}
