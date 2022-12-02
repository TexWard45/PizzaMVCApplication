using PizzaMVCApplication.Entity;
using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Models
{
    public class OrderInfoViewModel
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int PaymentType { get; set; }
        public int OrderType { get; set; }
        public DateTime OrderTime { get; set; }
        public string Note { get; set; }
        public IEnumerable<StatusDetail> ListStatusDetail { get; set; }
        public IEnumerable<OrderDetail> ListOrderDetail { get; set; }
        public IEnumerable<Status> ListStatus { get; set; }
        public IEnumerable<OrderDetailViewModel> OrderDetailViewModel { get; set; }
        public double Total { get; set; }
    }
}
