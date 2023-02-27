using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ProductManager.Data.Models
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
        public int? Amount { get; set; }

        public List<Orders> Orders { get; set; }
    }
}
