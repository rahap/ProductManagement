using FleetManagement.Utils;
using ProductManagement.Data.Ef;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductManagement.Data.Entities.ProductManagementEntities
{
   

    [Table("tb_Product", Schema = "dbo")]
    public class Product : Entity<Product>
    {

        protected Product()
        {
        }

        public Product(string name)
        {

            IsDeleted = false;
            Name = name;
         

        }


        [ValidatorAttributes.RequiredAttribute(Constants.Exception.NotFoundProductName)]
        public virtual string Name { get; set; }

    
    }
}
