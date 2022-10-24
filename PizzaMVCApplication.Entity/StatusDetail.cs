using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class StatusDetail
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
