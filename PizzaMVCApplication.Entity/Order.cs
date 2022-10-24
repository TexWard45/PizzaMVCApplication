using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class Order
    {
        [Key]
        public int? OrderId { get; set; }
        [ForeignKey("Customer")]
        [MaxLength(32)] 
        public string CustomerUsername { get; set; }
        public User Customer { get; set; }
        [ForeignKey("Handler")]
        [MaxLength(32)]
        public string HandlerUsername { get; set; }
        public User Handler { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        [MaxLength(255)]
        public string Fullname { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public int PaymentType { get; set; }
        public int OrderType { get; set; }
        public DateTime OrderTime { get; set; }
        public string Note { get; set; }
    }
}
