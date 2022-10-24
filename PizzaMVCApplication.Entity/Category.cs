using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Entity
{
    public class Category
    {
        [Key]
        public int? CategoryId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
