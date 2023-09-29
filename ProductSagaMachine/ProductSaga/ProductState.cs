using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSagaMachine
{
   public class ProductState :SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
    public  string Name { get; set; }
    public  int ProductId { get; set; }
}
}
