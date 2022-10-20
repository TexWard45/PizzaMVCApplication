﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVCApplication.Entity
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [MaxLength(255)]
        public string Permission { get; set; }
        [Range(0, 1)]
        public int Value { get; set; }
    }
}
