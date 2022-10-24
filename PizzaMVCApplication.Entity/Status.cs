using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Entity
{
    public class Status
    {
        [Key]
        public int? StatusId { get; set; }
        [MaxLength(255)]
        public string Display { get; set; }
    }
}
