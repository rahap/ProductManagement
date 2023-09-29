using MediatR;
using Messaging.InterfacesConstants.Commands;
using Messaging.InterfacesConstants.Commands.Product.ProductSaga;
using ProductSagaMachine;
using SharedModels.Product.Responses;
using SharedModels.Store.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Product.Commands
{
    public class CreateProductEvent : CreateProductCommand
    {




        private readonly ProductState _productState;

        public CreateProductEvent(ProductState productState)
        {
            _productState = productState;
           MessageId =_productState.CorrelationId;
        }

     

        public string Name => _productState.Name;

        public int ProductId => _productState.ProductId;


    }  
   
}
