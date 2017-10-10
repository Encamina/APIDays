using Microsoft.EntityFrameworkCore;
using taller.Model;
using Microsoft.Extensions.Configuration;

namespace taller.Data
{
    public class EFCoreWebDemoContext : DbContext
    {
        public  IConfiguration config {get;set;}
        public DbSet<Characters> Characters { get; set; }
        public DbSet<Films> Films { get; set; }

        public EFCoreWebDemoContext(IConfiguration configuration)
        {
             config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(config,"LocalDB"));  
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ApiDayDemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer("Server=tcp:apidaydemoserver.database.windows.net,1433;Initial Catalog=ApiDayDemoDB;Persist Security Info=False;User ID=admindb;Password=12345.aa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}