using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class OrderDetail
    {
        [Key]
        public int? OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("PizzaDetail")]
        public int PizzaDetailId { get; set; }
        public PizzaDetail PizzaDetail { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
