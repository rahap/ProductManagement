using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagement.API.Services;
using ProductManagement.Business.Product.Handlers;

namespace ProductManagement.API
{
    //https://stackoverflow.com/questions/47954136/masstransit-and-net-core-di-how-to-resolve-dependencies-with-parameterless-co
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

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });
            //services.AddMassTransit(c =>
            //{
            //    //c.AddConsumer<MyConsumer>();
            //    //c.AddConsumer<MyOtherConsumer>();

            //    //// or sagas
            //    //c.AddSaga<MySaga>();
            //});
     
            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
             {
                 cfg.Host("localhost", "/", h => { });
                 services.AddSingleton<IBusControl>(provider => provider.GetRequiredService<IBusControl>());
                 services.AddSingleton<IHostedService, BusService>();
             }));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddCors(options =>
            { options.AddPolicy("CorsPolicy",
                 builder => builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true).AllowCredentials());
            });
            services.AddMediatR(typeof(GeneralProductOperationeHandlers));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });
        }
    }
}
