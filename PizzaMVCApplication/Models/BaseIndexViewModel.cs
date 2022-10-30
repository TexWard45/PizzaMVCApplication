using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Models
{
    public class BaseIndexViewModel
    {
        public int? BaseId { get; set; }
        public string Display { get; set; }
        public bool Checked { get; set; }
    }
}
