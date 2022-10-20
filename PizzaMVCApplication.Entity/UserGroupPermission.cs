using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaMVCApplication.Entity
{
    public class UserGroupPermission
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserGroup")]
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        [MaxLength(255)]
        public string Permission { get; set; }
        [Range(0, 1)]
        public int Value { get; set; }
    }
}
