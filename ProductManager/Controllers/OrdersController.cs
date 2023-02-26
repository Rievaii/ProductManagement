using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<Orders>> PostOrders(int _CustomerId, int _Amount, int _ProductId)
        {
            //проверка на то, хватит ли продуктов в бд
            var products = await _context.Products.FindAsync(_ProductId);
            if (products == null)
            {
                return NotFound();
            }
            else if (products.Amount < _Amount)
            {
                return BadRequest("не хватает количества товаров");
            }
            else
            {
                var orders = _context.Orders.Add(new Orders()
                {
                    CustomerId = _CustomerId,
                    Amount = _Amount,
                    product = products

                });
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostOrders", orders);
            }
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

//for getting all заказы with id 
//var restaurants = await _dbContext.Restaurants
//                .AsNoTracking()
//                .AsQueryable()
//                .Include(m => m.Reservations).ToListAsync();