using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProductManager.Data;
using ProductManager.Data.Models;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

namespace ProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Context _context;

        public OrdersController(Context context)
        {
            _context = context;
        }


        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(int _Amount, int ProductId, int _CustomerId)
        {
            var products = await _context.Products.FindAsync(ProductId);
            

            if (products == null)
            {
                return NotFound();
            }
            else if (products.Amount < _Amount)
            {
                return BadRequest("Не хватает количества товаров");
            }

            products.Amount -= _Amount;
            Orders order = new Orders() {
                Amount = _Amount,
                CustomerId = _CustomerId,
                Products = products,
                TotalSum = _Amount * products.Price
            };
            var orders = _context.Orders.Add(order);

            products.Orders.Add(order);
            
            await _context.SaveChangesAsync();
            return Ok("Customer Id " + _CustomerId + " \n Total Amount =  " + _Amount*products.Price+"руб. \n");

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }


            var products = await _context.Products.ToListAsync();
            if (products == null)
            {
                return NotFound();
            }
            foreach (var product in products)
            {
                var AssignedOrder = product.Orders = await _context.Orders.Where(p => p.Id == id).ToListAsync();
                foreach (var order in AssignedOrder)
                {
                    product.Amount += order.Amount;  
                }
            }
            
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}

