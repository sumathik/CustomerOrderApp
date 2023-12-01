using CustomerOrderApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _dbContext;

        public CustomerController(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_dbContext.Customers == null)
            {
                return NotFound();
            }
            return await _dbContext.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string customerid)
        {
            if (_dbContext.Customers == null)
            {
                return NotFound();
            }
            var customer = await _dbContext.Customers.FindAsync(customerid);
            if(customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new {id = customer.customerId}, customer);
        }

        
    }
}
