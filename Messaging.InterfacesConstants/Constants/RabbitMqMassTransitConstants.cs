using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.InterfacesConstants.Constants
{
   public class RabbitMqMassTransitConstants
    {
        //{
       // public const string RabbitMqUri = "rabbitmq://rabbitmq/";
        public const string RabbitMqUrl = "rabbitmq://rabbitmq:5672";
        public const string User = "guest";
        public const string Password = "guest";
        public const string RegisterProductServiceCommand= "/register.product.command";
        public const string RegisterProductServiceQueue = "productManagement.register.product";
    }
}
