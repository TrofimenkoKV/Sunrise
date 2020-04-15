using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sunrise.Config;
using Microsoft.Extensions.Logging;

namespace Sunrise
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureLogging(factory => {
                    factory.AddFilter("Microsoft", LogLevel.Warning);
                    factory.AddFilter("System", LogLevel.Warning);
                    factory.AddFilter("Sunrise", LogLevel.Debug)
                        .AddConsole();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<WebStartup>()
                .Build();
            host.Run();
        }
        
    }
}
