using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sunrise.Config;

namespace Sunrise
{
    class Program
    {
        static void Main(string[] args)
        {
              CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<WebStartup>();
                });
    }
}
