using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Models
{
    public class PizzaIndexViewModel
    {
        public int? PizzaId { get; set; }
        public string ImageUrl { get; set; }
        public string Display { get; set; }
        public string CategoryDisplay { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
    }
}
