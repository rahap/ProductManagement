using MediatR;
using Messaging.InterfacesConstants.Commands;
using SharedModels.Product.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Product.Commands
{
    public class CreateProductCommand : ICommandMessageBase, IRequest<PmResponseModel<CreateProductResponse>>
    {
        public string Name { get; set; }



    }  
   
}
