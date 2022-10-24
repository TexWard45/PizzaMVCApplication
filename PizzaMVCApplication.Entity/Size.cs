using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Entity
{
    public class Size
    {
        [Key]
        public int? SizeId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
