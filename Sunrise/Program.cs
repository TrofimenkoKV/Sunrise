using System.IO;
using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sunrise.Config;
using Microsoft.Extensions.Logging;

namespace Sunrise
{
    class Program
    {
        private static readonly int RequiredArgsSize = 5;
        static void Main(string[] args)
        {
            ValidateArgs(args);

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

        private static void ValidateArgs(string[] args) {
            if(args.Length < RequiredArgsSize)
                throw new ArgumentException(String.Format("Not enougth arguments. Required {0} but was {1}", RequiredArgsSize, args.Length));
        }

        
    }
}
