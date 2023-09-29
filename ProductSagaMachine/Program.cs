using MassTransit;
using Messaging.InterfacesConstants.Commands.Product.ProductSaga;
using System;
using MassTransit.Saga;
using Messaging.InterfacesConstants.Constants;

namespace ProductSagaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Saga";
            var productSaga = new ProductSaga();
            var repo = new InMemorySagaRepository<ProductState>();

         var bus=   Bus.Factory.CreateUsingRabbitMq(
                cfg =>
                {
                     cfg.Host("localhost", "/", h => { });

                   // cfg.Host("127.0.0.1", "/", h => { });
             
                    cfg.ReceiveEndpoint(RabbitMqMassTransitConstants.ProductSagaQ, e =>
                    {
                        e.StateMachineSaga(productSaga, repo);
                    });
         

                });

            bus.StartAsync();
            Console.WriteLine("Order saga started..");
            Console.ReadLine();
        }
    }
}
