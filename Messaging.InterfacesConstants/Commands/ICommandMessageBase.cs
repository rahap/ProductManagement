using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.InterfacesConstants.Commands
{
   public abstract class ICommandMessageBase
    {
        public Guid MessageId { get; set; }
    }
}
