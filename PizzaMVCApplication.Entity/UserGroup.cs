using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVCApplication.Entity
{
    public class UserGroup
    {
        [Key]
        public int GroupId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
