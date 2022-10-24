using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMVCApplication.Entity
{
    public class User
    {
        [Key]
        [MaxLength(32)]
        public string Username { get; set; }
        [ForeignKey("UserGroup")]
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(255)]
        public string Fullname { get; set; }
        public DateTime Birth { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(320)]
        public string Email { get; set; }
        public IEnumerable<Order> CustomerOrders { get; set; }
        public IEnumerable<Order> HandlerOrders { get; set; }
    }
}
