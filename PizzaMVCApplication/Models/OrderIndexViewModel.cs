using PizzaMVCApplication.Entity;
namespace PizzaMVCApplication.Models
{
    public class OrderIndexViewModel
    {
        public int? OrderId { get; set; }
        public Status EndStatus { get; set; }
        public StatusDetail StartStatusDetail { get; set; }
        public StatusDetail EndStatusDetail { get; set; }
        public string CustomerUsername { get; set; }
        public string HandlerUsername { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public bool Checked { get; set; }
       
    }
}
