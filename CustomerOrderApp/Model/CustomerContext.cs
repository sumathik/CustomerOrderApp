using Microsoft.EntityFrameworkCore;

namespace CustomerOrderApp.Model
{
    public class CustomerContext: DbContext
    {        
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
