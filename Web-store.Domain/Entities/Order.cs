﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web_store.Domain.Entities
{
    public class Order
    {

        public Order(int id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<OrderItem> OrderItems { get; set;}
        public List<Payment> ProductItems { get;}
    }
}
