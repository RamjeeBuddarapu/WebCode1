using WebCode.Entities;
using Microsoft.EntityFrameworkCore;
namespace WebCode.Database
{
    public class MyContext : DbContext
    {
        //define entity set
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
        //configure connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=MSI/DATAMODEL;database=webcode;trusted_connection=true;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
    }
}
