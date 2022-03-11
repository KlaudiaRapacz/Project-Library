﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Biblioteka.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        
        public AppUser User { get; set; }

        //Relationships
        public List<OrderItem> OrderItems { get; set; }
    }
}