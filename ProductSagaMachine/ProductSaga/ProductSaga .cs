

using Automatonymous;
using MassTransit;
using ProductSagaMachine;
using SharedModels.Product.Commands;
using SharedModels.Store.Commands;
using System;
using System.Runtime.ConstrainedExecution;

namespace Messaging.InterfacesConstants.Commands.Product.ProductSaga
{
    public class ProductSaga : MassTransitStateMachine<ProductState>
    {
    

        public State Received { get; set; }
        public State Processed { get; set; }

        public Event<CreateProductCommand> CreateProductCommand { get; set; }
        public Event<CreateStoreProductCommand> ProductProcessed { get; set; }

        public ProductSaga()
        {
           
          InstanceState(x => x.CurrentState, Received, Processed);


            // Event(() => (Event)Received, x => x.CorrelateBy(context => context.Message.OrderId));

          
           Event(() => CreateProductCommand,
                x =>
                //x.CorrelateBy((instance, context) => instance.Name == context.Message.Name)
                //   .SelectId(selector => Guid.NewGuid()));

                        x.CorrelateBy(state => state.Name, context => context.Message.Name)
                        .SelectId(selector => Guid.NewGuid()));

            Event(() => ProductProcessed, cec => cec.CorrelateById(selector =>
                        selector.Message.MessageId));


            Initially(
               When(CreateProductCommand)
                   .Then(context =>
                   {
                       context.Instance.Name = context.Data.Name;
                      
                   })
                   .ThenAsync(
                       context => Console.Out.WriteLineAsync($"{context.Data.MessageId} order id is received..")
                   )
                   .TransitionTo(Received)
                   .Publish(context => new CreateProductEvent(context.Instance))
               );


            During(Received,
                When(ProductProcessed)
                .ThenAsync(
                    context => Console.Out.WriteLineAsync($"{context.Data.ProductId} order id is processed.."))
                .Finalize()
                );

            SetCompletedWhenFinalized();
        }
    }
}
