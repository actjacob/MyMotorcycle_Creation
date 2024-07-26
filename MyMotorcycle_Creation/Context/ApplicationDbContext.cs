using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyMotorcycle_Creation.Entities;

namespace MyMotorcycle_Creation.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Motorcycle> Motorcycles{ get; set; }
 
    }
    
}
