using MassTransit;
using MediatR;
using ProductManagement.Data.Ef;
using SharedModels.Product.Commands;
using SharedModels.Store.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.MService.Messages.Consumers
{
    public class RegisterStoreProductCommandConsumer : IConsumer<CreateStoreProductCommand>
    {
        private readonly IMediator _mediator;

 

        public RegisterStoreProductCommandConsumer(
          IMediator mediator
        )
        {
         
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<CreateStoreProductCommand> context)
        {
          
            
            return  _mediator.Send(new CreateStoreProductCommand 
            {  ProductId=context.Message.ProductId,
                ProductName = context.Message.ProductName
            });
            
        
        }
    }
}
