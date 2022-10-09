using MediatR;
using SharedModels.Product.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Product.Commands
{
    public class CreateProductCommand : IRequest<PmResponseModel<CreateProductResponse>>
    {
        public string Name { get; set; }
    


    }  
   
}
