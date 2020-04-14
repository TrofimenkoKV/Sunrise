using Autofac;
using Sunrise.Service;

namespace Sunrise.Config
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterType<CityService>().AsSelf();
        }
    }
}