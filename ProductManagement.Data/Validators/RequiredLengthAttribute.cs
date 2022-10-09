using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.ValidatorAttributes
{
   public class RequiredLengthAttribute : ValidationAttribute
    {

        public string ExceptionMessage { get; set; }
        private int Length { get; set; }

        public RequiredLengthAttribute(string message,int length)
        {
            ExceptionMessage = message;
            Length = length;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var s = value.ToString();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (value.ToString().Length > Length)
                        throw new Exception(string.Format(ExceptionMessage, Length));
                }
            }
            return true;
        }
    }
}