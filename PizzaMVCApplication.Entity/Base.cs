using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Entity
{
    public class Base
    {
        [Key]
        public int? BaseId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
