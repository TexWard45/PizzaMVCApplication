using PizzaMVCApplication.Entity;
namespace PizzaMVCApplication.Models
{
    public class OrderInfoViewModel
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int PaymentType { get; set; }
        public DateTime OrderTime { get; set; }
        public string Display { get; set; }
        //public Status Status { get; set; }
        public string Note { get; set; }
    }
}

