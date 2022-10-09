using MassTransit;
using MediatR;
using Messaging.InterfacesConstants.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductManagement.Business.Product.Handlers;
using ProductManagement.Data.Ef;
using ProductManagement.MService.Messages.Consumers;
using ProductManagement.MService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.MService
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

            services.AddMassTransit(config =>
            {
                config.AddConsumer<RegisterProductCommandConsumer>();
                // config.AddConsumer<DenemeCommandConsumer>();
                config.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(RabbitMqMassTransitConstants.RabbitMqUrl), hostConfigurator =>
                    {
                        hostConfigurator.Username(RabbitMqMassTransitConstants.User);
                        hostConfigurator.Password(RabbitMqMassTransitConstants.Password);
                        //hostConfigurator.UseCluster(cluster =>
                        //{
                        //    var nodes = rabbitConfig.Node.Split(",");
                        //    foreach (var node in nodes)
                        //    {
                        //        cluster.Node(node);
                        //    }
                        //});
                    });

                    cfg.ReceiveEndpoint(RabbitMqMassTransitConstants.RegisterProductServiceQueue, e =>
                    {

                        e.PrefetchCount = 16;
                        e.UseMessageRetry(x => x.Exponential(3, TimeSpan.FromSeconds(30), TimeSpan.FromMinutes(100), TimeSpan.FromSeconds(30)));
                        e.ConfigureConsumer<RegisterProductCommandConsumer>(provider);
                        //   e.ConfigureConsumer<DenemeCommandConsumer>(provider);

                        EndpointConvention.Map<RegisterProductCommandConsumer>(e.InputAddress);
                        // EndpointConvention.Map<DenemeCommand>(e.InputAddress);
                    });
                    cfg.ConfigureEndpoints(provider);
                }));

                services.AddSingleton<IHostedService, BusService>();
                var conn = Configuration.GetConnectionString("ProductDbConnecton");

                services.AddDbContext<ProductManagementContext>(options =>

                  options.UseSqlServer(conn));//appjson alýnack
                services.AddMediatR(typeof(GeneralProductOperationeHandlers));
                //  services.TryAddSingleton<ILogCommand, ILogCommand>();
                services.AddSwaggerGen();
                services.AddControllers();
                // services.AddAutoMapper(typeof(VehicleModel));
            });
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
                var context = serviceScope.ServiceProvider.GetRequiredService<ProductManagementContext>();
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
