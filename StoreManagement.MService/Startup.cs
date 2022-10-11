
using MassTransit;
using MediatR;
using Messaging.InterfacesConstants.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagement.Data.Ef;
using ProductManagement.MService.Messages.Consumers;
using StoreManagement.Business.StoreBusiness.Handlers;
using System;

namespace StoreManagement.MService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            var conn = Configuration.GetConnectionString("StoreProductDbConnection");

            services.AddDbContext<StoreProductManagementContext>(options =>

              options.UseSqlServer(conn));//appjson alýnack
            services.AddMediatR(typeof(GeneralStoreOperationeHandlers));
            //  services.TryAddSingleton<ILogCommand, ILogCommand>();
            services.AddSwaggerGen();
            services.AddMassTransit(config =>
            {
                config.AddConsumer<RegisterStoreProductCommandConsumer>();

                config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("localhost", "/", h => { });
                    cfg.ReceiveEndpoint(RabbitMqMassTransitConstants.RegisterStoreProductServiceQueue, e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(x => x.Interval(2, TimeSpan.FromSeconds(10)));
                        //  e.Consumer<RegisterProductCommandConsumer>();
                        e.ConfigureConsumer<RegisterStoreProductCommandConsumer>(provider);
                    });
                    cfg.ConfigureEndpoints(provider);
                }));

            });



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreProductManagementContext>();
                context.Database.EnsureCreated();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
