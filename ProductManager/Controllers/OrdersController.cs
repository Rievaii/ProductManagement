using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProductManager.Data;
using ProductManager.Data.Models;

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
            //проверка на то, хватит ли продуктов в бд
            var products = await _context.Products.FindAsync(ProductId);
            Console.WriteLine(products.Name);

            if (products == null)
            {
                return NotFound();
            }
            else if (products.Amount < _Amount)
            {
                return BadRequest("Не хватает количества товаров");
            }

            products.Amount -= _Amount;

            var orders = _context.Orders.Add(new Orders
            {
                Amount = _Amount,
                CustomerId = _CustomerId,
                Products = products
            });

            await _context.SaveChangesAsync();
            return Ok(orders);

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

