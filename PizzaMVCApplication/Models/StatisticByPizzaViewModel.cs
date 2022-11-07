using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Models
{
    public class StatisticByPizzaViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; }
        public List<double> ExpectedRevenue { get; set; }
        public List<double> ActualRevenue { get; set; }
        public List<int> ExpectedSales { get; set; }
        public List<int> ActualSales { get; set; }
        public double TotalExpectedRevenue { get; set; }
        public double TotalActualRevenue { get; set; }
        public int TotalExpectedSales { get; set; }
        public int TotalActualSales { get; set; }
    }
}
