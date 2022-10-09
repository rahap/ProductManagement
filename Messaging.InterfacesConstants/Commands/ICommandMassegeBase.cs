using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.InterfacesConstants.Commands
{
   public abstract class ICommandMassegeBase
    {
        public Guid MessageId { get; set; }
    }
}
