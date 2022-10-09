using MassTransit;
using MediatR;
using Messaging.InterfacesConstants.Constants;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Product.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBusControl _busControl;
        private  readonly IMediator _mediator;

     
        public ProductController(IBusControl busControl, IMediator mediator)
        {
            _busControl = busControl;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterProduction(CreateProductCommand command)
        {
            try
            {

                //await _mediator.Send(command);
                var sendToUri = new Uri($"{RabbitMqMassTransitConstants.RabbitMqUrl }" +

                     $"{RabbitMqMassTransitConstants.RegisterProductServiceQueue}");

                var endPoint = await _busControl.GetSendEndpoint(sendToUri);
               
                await endPoint.Send<CreateProductCommand>(command);
                return Ok();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
