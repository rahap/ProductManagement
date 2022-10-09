using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.ValidatorAttributes
{
   public class CheckEnumAttribute : ValidationAttribute
    {

        public string ExceptionMessage { get; set; }
        public Type T { get; set; }

        public CheckEnumAttribute(string message,Type _t)
        {
            ExceptionMessage = message;
            T = _t;
        }

        public override bool IsValid(object value)
        {
            if (value!=null)
            {
                object result = null;
                var s = value.ToString();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    Enum.TryParse(T, value.ToString(), out result);
                    if (result == null)
                        throw new Exception(ExceptionMessage);
                }
            }
            return true;
        }
    }
}
