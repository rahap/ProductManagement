using MediatR;
using SharedModels;
using SharedModels.Store.Commands;
using SharedModels.Store.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Business.Store.Handlers
{

    public class GeneralStoreOperationeHandlers : IRequestHandler<CreateStoreProductCommand, PmResponseModel<CreateStoreProductResponse>>
    {

        
        IMediator _mediator;
        public GeneralStoreOperationeHandlers( IMediator mediator)
        {
           
            _mediator = mediator;
        }

        public Task<PmResponseModel<CreateStoreProductResponse>> Handle(CreateStoreProductCommand request, CancellationToken cancellationToken)
        {
            var y = request.ProductId;
            throw new NotImplementedException();
        }
    }
}
