using MediatR;
using Messaging.InterfacesConstants.Commands;
using SharedModels.Store.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Store.Commands
{
   public class CreateStoreProductCommand : ICommandMessageBase,IRequest<PmResponseModel<CreateStoreProductResponse>>
    {
        public int ProductId { get; set; }
         public string ProductName { get; set; }
    }
}
