using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Entity
{
    public class Topping
    {
        [Key]
        public int? ToppingId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
