using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.ValidatorAttributes
{
   public class NotUndefinedDateAttribute : ValidationAttribute
    {

        public string ExceptionMessage { get; set; }

        public NotUndefinedDateAttribute(string message)
        {
            ExceptionMessage = message;
        }

        public override bool IsValid(object value)
        {
            var i = Convert.ToDateTime(value);
            if (DateTime.MinValue==i)
                throw new Exception(ExceptionMessage);
            return true;
        }
    }
}
