using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.Infrastructure.Data;
using OrdersApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext ordersContext;

        public OrdersController(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;

            if (ordersContext.Orders.Count() == 0)
            {
                ordersContext.Orders.Add(new Order { Id = "1", Amount = 500 });
                ordersContext.Orders.Add(new Order { Id = "2", Amount = 1000 });
                ordersContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var orders = await ordersContext.Orders.AsNoTracking().ToListAsync();
            return Ok(orders);
        }

        public async Task<IActionResult> Post([FromBody]Order order)
        {
            if (ModelState.IsValid)
            {
                ordersContext.Orders.Add(order);
                await ordersContext.SaveChangesAsync();
                return Ok(order.Id);
            }

            return BadRequest(ModelState);
        }
    }
}
