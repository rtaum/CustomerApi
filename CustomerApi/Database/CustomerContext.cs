using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Database
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
