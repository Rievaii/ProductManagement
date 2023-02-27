using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Text.Json.Serialization;

namespace ProductManager.Data.Models
{
    public class Orders
    {

        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int Amount { get; set; }


        public decimal TotalSum { get; set; }


        [JsonIgnore]
        public  Products Products { get; set; }
    }
}
