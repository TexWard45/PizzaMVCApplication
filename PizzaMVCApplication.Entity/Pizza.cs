using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class Pizza
    {
        [Key]
        public int? Id { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
    }
}
