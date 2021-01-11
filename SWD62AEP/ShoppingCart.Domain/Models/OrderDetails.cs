﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class OrderDetails
    {
        //autogenerated
        public int Id { get; set; }


        //foreign key attribute
        [Required]
        public Guid ProductFk { get; set; }
        public virtual Product Product {get; set;}



        //foreign key attribute
        [Required]
        public Guid OrderFk { get; set; }
        public virtual Order Order { get; set; }


        public int Quantity { get; set; }

        public double Price { get; set; }

    }
}
