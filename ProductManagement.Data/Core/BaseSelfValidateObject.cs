using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.Core
{
 public   class BaseSelfValidateObject
    {
        public virtual bool IsValid()
        {
            ValidationContext valContext = new ValidationContext(this, null, null);
            /// 3.- Create a container of results
            var validationsResults = new List<ValidationResult>();
            /// 4.- Validate entity
            var result = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(this, valContext, validationsResults, true);
            return result;
        }
    }
}
