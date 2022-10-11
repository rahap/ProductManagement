using MediatR;
using ProductManagement.Data.Ef;
using ProductManagement.Data.Entities.StoreManagementEntities;
using SharedModels;
using SharedModels.Store.Commands;
using SharedModels.Store.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Business.StoreBusiness.Handlers
{

    public class GeneralStoreOperationeHandlers : IRequestHandler<CreateStoreProductCommand, PmResponseModel<CreateStoreProductResponse>>
    {

        
        IMediator _mediator;
        private readonly StoreProductManagementContext _context;
        public GeneralStoreOperationeHandlers( IMediator mediator,
            StoreProductManagementContext context)
        {
            _context= context;
            _mediator = mediator;
        }

        public async Task<PmResponseModel<CreateStoreProductResponse>> Handle(CreateStoreProductCommand request, CancellationToken cancellationToken)
        {

            var returnObject = new PmResponseModel<CreateStoreProductResponse>();
           
            var returnValue = new CreateStoreProductResponse();
            try
            {
                var pr = new Product(request.ProductId, request.ProductName);
                _context.AddCustom(pr);
                await _context.SaveChangesAsync();
                returnValue.Id = pr.Id;
                returnValue.Name = pr.Name;
                returnValue.ProductionId = pr.ProductId;
                returnObject.Data = returnValue;
                return returnObject;
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
