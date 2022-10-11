using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels.Store.Responses
{
    public class CreateStoreProductResponse
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProductionId { get; set; }

    }
}

