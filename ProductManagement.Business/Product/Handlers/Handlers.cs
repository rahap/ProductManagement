using MediatR;

using SharedModels;
using SharedModels.Product.Commands;
using SharedModels.Product.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Business.Product.Handlers
{

    public class GeneralProductOperationeHandlers : IRequestHandler<CreateProductCommand, PmResponseModel<CreateProductResponse>>




    {

        
        IMediator _mediator;
        public GeneralProductOperationeHandlers( IMediator mediator)
        {
           
            _mediator = mediator;
        }
        public Task<PmResponseModel<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var x = request.Name;
            throw new NotImplementedException();
        }
    }
}
