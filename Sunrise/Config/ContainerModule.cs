using Autofac;
using Sunrise.Service;
using Sunrise.Database.Dao;
using Sunrise.Api.Dao;
using Microsoft.Extensions.Logging;

namespace Sunrise.Config
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            
            builder.RegisterType<CityService>().AsSelf().SingleInstance();
            builder.RegisterType<EventTimeService>().AsSelf().SingleInstance();
            
            builder.RegisterType<CityDao>().AsSelf().SingleInstance();
            
            builder.RegisterType<SunriseSunsetHttpDao>().AsSelf().SingleInstance();
            
            builder.RegisterInstance(new LoggerFactory()).As<ILoggerFactory>();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();

            builder.RegisterType<SecurityService>().AsSelf().SingleInstance();
        }
    }
}