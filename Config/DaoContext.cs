using Microsoft.EntityFrameworkCore;
using Sunrise.Database.Model;

namespace Sunrise.Config 
{
    public class DaoContext : DbContext 
    {
    
        public DbSet<City> Cities {get;set;}   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string config = "server=localhost;port=3306;database=dotnet;user=root;password=password;";
            optionsBuilder.UseMySql(config);
        }

    }
}