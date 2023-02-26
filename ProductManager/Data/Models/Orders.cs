using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;


namespace ProductManager.Data.Models
{
    public class Orders
    {

        public int Id { get; set; }
       
        //get price and name from products

        [Required]
        public long CustomerId { get; set; }

        [Required]
        public int Amount { get; set; }

        public Products product { get; set; }
    }
}
