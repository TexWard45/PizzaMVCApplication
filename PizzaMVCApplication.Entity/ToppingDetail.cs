using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMVCApplication.Entity
{
    public class ToppingDetail
    {
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [ForeignKey("Topping")]
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
