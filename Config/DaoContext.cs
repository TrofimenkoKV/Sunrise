using System;
using Microsoft.EntityFrameworkCore;
using Sunrise.Database.Model;

namespace Sunrise.Config 
{
    public class DaoContext : DbContext 
    {
        public DbSet<City> Cities {get;set;}   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string[] args = Environment.GetCommandLineArgs();
            string server = args[1];
            string port = args[2];
            string database = args[3];
            string user = args[4];
            string password = args[5];

            string config = String.Format("server={0};port={1};database={2};user={3};password={4};", server, port, database, user, password);
            optionsBuilder.UseMySql(config);
        }

    }
}