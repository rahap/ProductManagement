using MediatR;
using ProductManagement.Data.Ef;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Entities.ProductManagementEntities;
using SharedModels;
using SharedModels.Product.Commands;
using SharedModels.Product.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Business.ProductBusiness.Handlers
{

    public class GeneralProductOperationeHandlers : IRequestHandler<CreateProductCommand, PmResponseModel<CreateProductResponse>>


    {

        
        IMediator _mediator;
        private readonly ProductManagementContext _context;
        public GeneralProductOperationeHandlers( IMediator mediator,
            ProductManagementContext context)
        {
            _context = context;
             _mediator = mediator;
        }
        public async Task<PmResponseModel<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var returnObject = new PmResponseModel<CreateProductResponse>();
            var returnValue = new CreateProductResponse();
            try
            {
              

                var pr = new Product(request.Name);
                _context.AddCustom(pr);
                await _context.SaveChangesAsync();
                returnValue.Id = pr.Id;
                returnValue.Name = pr.Name;
                returnObject.Data = returnValue;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
            return returnObject;
         
        }
    }
}
