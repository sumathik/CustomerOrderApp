using CustomerOrderApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly OrderContext _dbContext;

        public OrderController(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            if (_dbContext.Orders == null)
            {
                return NotFound();
            }
            var check = (from wf in _dbContext.Orders
                         where wf.orderNumber == 456 
                         select new
                         {
                             product = wf.orderNumber,
                             orderDate = wf.orderDate,
                             deliveryAddress = wf.deliveryAddress,
                             deliveryExpected = wf.deliveryExpected
                         }).ToList();
            
            return Ok(check);
        }

    }
}
