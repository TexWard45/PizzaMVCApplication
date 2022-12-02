using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Models
{
    public class OrderDetailViewModel
    {
        public string DisplayPizza  { get; set; }
        public string DisplaySize { get; set; }
        public string DisplayBase { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; } 
    }
}
