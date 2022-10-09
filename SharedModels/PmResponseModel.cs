using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels
{
   public class PmResponseModel<T> : ResponseModel<T>
    {
        public string Message { get; set; }
        public bool IsSuccess = true;

    }
}