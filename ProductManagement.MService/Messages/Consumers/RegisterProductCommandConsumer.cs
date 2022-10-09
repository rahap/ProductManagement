

using MassTransit;
using MediatR;
using ProductManagement.Data.Ef;
using SharedModels.Product.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.MService.Messages.Consumers
{
    public class RegisterProductCommandConsumer : IConsumer<CreateProductCommand>
    {
        private readonly IMediator _mediator;

        private readonly ProductManagementContext _context;

        public RegisterProductCommandConsumer(
          IMediator mediator
        )
        {
         
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<CreateProductCommand> context)
        {
            var z = this._context;
            
             _mediator.Send(new CreateProductCommand { Name= context.Message.Name });
            throw new NotImplementedException();
        }
    }
}
