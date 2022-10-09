using ProductManagement.Data.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManagement.Data.Ef
{
   public class Entity : Entity<int>
    {
    }
    public class Entity<T> : BaseSelfValidateObject
    {
        //[BsonId]
        //[BsonElement("_Id")]
        [Key]
        public int Id { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;



    }
}
