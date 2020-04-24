using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Sunrise.Config
{
    public class WebStartup
    {
        public WebStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddAuthentication(opt => 
            {
                opt.DefaultAuthenticateScheme = "JwtBearer";
                opt.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtOptions => 
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters() 
                {
                    IssuerSigningKey = SecurityConfig.SIGNING_KEY,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true//,
                    //ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
            services.AddDbContext<DaoContext>();
            services.AddAutofac();
            services.AddLogging();




            var builder = new ContainerBuilder();   
            builder.RegisterModule<ContainerModule>();
            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<DaoContext>().Database.Migrate();
            }

        }

    }
}
