using Microsoft.EntityFrameworkCore;
using static zooland.Models.MainProductConfig;
using zooland.Models;

namespace zooland.DataBaseContext
{
    public class ZoolandDbContext: DbContext
    {
        public class VendingMachineContext : DbContext
        {
            public VendingMachineContext(DbContextOptions<VendingMachineContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
            
            public DbSet<Brand> Brands { get; set; }    
            public DbSet<Coin> Coins { get; set; }
            public DbSet<Order> Orders { get; set; }
        }



    }
}
    