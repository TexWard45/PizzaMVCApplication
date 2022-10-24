using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class PizzaDetail
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; }
        [ForeignKey("Base")]
        public int BaseId { get; set; }
        public Base Base { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
