using FleetManagement.Utils;
using ProductManagement.Data.Ef;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductManagement.Data.Entities.StoreManagementEntities
{
   

    [Table("tb_Product", Schema = "dbo")]
    public class Product : Entity<Product>
    {

        protected Product()
        {
        }

        public Product(int productId,string name)
        {

            IsDeleted = false;
            Name = name;
            ProductId = productId;

        }


        [ValidatorAttributes.RequiredAttribute(Constants.Exception.NotFoundProductName)]
        public virtual string Name { get; set; }
        [ValidatorAttributes.NotZero(Constants.Exception.NotFoundProduct)]
        public virtual int ProductId { get; set; }

    }
}
