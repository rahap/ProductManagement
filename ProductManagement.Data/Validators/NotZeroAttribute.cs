using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.ValidatorAttributes
{
   public class NotZeroAttribute : ValidationAttribute
    {

        public string ExceptionMessage { get; set; }

        public NotZeroAttribute(string message)
        {
            ExceptionMessage = message;
        }

        public override bool IsValid(object value)
        {
            var i = Convert.ToInt32(value);
            if (i == 0)
                throw new Exception(ExceptionMessage);
            return true;
        }
    }
}
