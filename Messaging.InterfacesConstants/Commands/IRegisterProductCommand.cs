using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.InterfacesConstants.Commands
{
   public interface IRegisterProductCommand
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
    }
}
