using Microsoft.EntityFrameworkCore;
using UserRegistrationService.Model;

namespace UserRegistrationService.Data
{
    public class CustomerDataContext : DbContext
    {

        public CustomerDataContext()
        {
        }

        public CustomerDataContext(DbContextOptions<CustomerDataContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }

       
        
    }
}
