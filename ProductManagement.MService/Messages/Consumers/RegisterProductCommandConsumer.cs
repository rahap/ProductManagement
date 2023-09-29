

using MassTransit;
using MediatR;
using Messaging.InterfacesConstants.Constants;
using ProductManagement.Data.Ef;
using SharedModels.Product.Commands;
using SharedModels.Store.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductManagement.MService.Messages.Consumers
{
    public class RegisterProductCommandConsumer : IConsumer<CreateProductCommand>
    {
        private readonly IMediator _mediator;

        private readonly ProductManagementContext _context;
        private readonly IBusControl _busControl;
        public RegisterProductCommandConsumer(
          IMediator mediator,IBusControl busControl
        )
        {
         
            _mediator = mediator;
            _busControl = busControl;
        }
        public async Task Consume(ConsumeContext<CreateProductCommand> context)
        {

            
            var result= _mediator.Send(new CreateProductCommand { Name= context.Message.Name }).Result.Data;
            //var sendToUri = new Uri($"{RabbitMqMassTransitConstants.RabbitMqUrl }" +

            //        $"{RabbitMqMassTransitConstants.RegisterStoreProductServiceCommand}");

            //var endPoint = await _busControl.GetSendEndpoint(sendToUri);

            //await endPoint.Send<CreateStoreProductCommand>(new CreateStoreProductCommand
            //{ ProductId=result.Id, ProductName=result.Name});
            await context.Publish<CreateStoreProductCommand>(
              new { ProductId = result.Id, ProductName= result.Name, 
                  MessageId = context.Message.MessageId, });
        
        }
    }
}
