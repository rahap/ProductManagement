using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.ValidatorAttributes
{
   public class RequiredAttribute : ValidationAttribute
    {

        public string ExceptionMessage { get; set; }

        public RequiredAttribute(string message)
        {
            ExceptionMessage = message;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                throw new Exception(ExceptionMessage);
              else
                {
                    var s = value.ToString();
                    if(string.IsNullOrWhiteSpace(s))
                        throw new Exception(ExceptionMessage);
                }
            return true;
        }
    }
}