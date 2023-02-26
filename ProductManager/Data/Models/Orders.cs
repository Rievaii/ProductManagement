using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;


namespace ProductManager.Data.Models
{
    public class Orders
    {

        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int Amount { get; set; }
       
        public  Products Products { get; set; }
    }
}
