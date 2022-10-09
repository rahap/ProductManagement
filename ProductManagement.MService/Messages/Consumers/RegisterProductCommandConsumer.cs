using MassTransit;
using SharedModels.Product.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.MService.Messages.Consumers
{
    public class RegisterProductCommandConsumer : IConsumer<CreateProductCommand>
    {
        public Task Consume(ConsumeContext<CreateProductCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
