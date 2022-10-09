using MediatR;
using SharedModels.Store.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Store.Commands
{
   public class CreateStoreProductCommand : IRequest<PmResponseModel<CreateStoreProductResponse>>
    {
    }
}
