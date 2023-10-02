using Microsoft.EntityFrameworkCore;

namespace IpManagement.Models
{
    public class IpDbcontext : DbContext
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IpDbcontext(DbContextOptions<IpDbcontext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<IpAddressModel> IpAddresses { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

      
    }
}
