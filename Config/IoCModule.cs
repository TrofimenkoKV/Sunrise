using Autofac;
using Sunrise.Service;
using Sunrise.Database.Dao;
using Sunrise.Api.Dao;

namespace Sunrise.Config
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<CityService>().AsSelf();
            builder.RegisterType<EventTimeService>().AsSelf();
            builder.RegisterType<CityDao>().AsSelf();
            builder.RegisterType<SunriseSunsetHttpDao>().AsSelf();
        }
    }
}