using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;
using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Models
{
    public class PizzaInfoSizeBaseViewModel
    {
        public int? SizeId { get; set; }
        public string? SizeDisplay { get; set; }
        public int? BaseId { get; set; }
        public string? BaseDisplay { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class PizzaInfoViewModel
    {
        public PizzaInfoViewModel()
        {
            CategoryList = new List<SelectListItem>();
        }
        public int? PizzaId { get; set; }
        public string Display { get; set; }
        public string CategoryDisplay { get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IList<PizzaInfoSizeBaseViewModel> SizeBaseList { get; set; }
    }
}
