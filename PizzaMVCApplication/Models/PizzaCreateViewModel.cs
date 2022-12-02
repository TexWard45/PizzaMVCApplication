using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;
using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApplication.Models
{
    public class PizzaCreateSizeBaseViewModel
    {
        public int? SizeId { get; set; }
        public string? SizeDisplay { get; set; }
        public int? BaseId { get; set; }
        public string? BaseDisplay { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class PizzaCreateViewModel
    {
        public PizzaCreateViewModel()
        {
            CategoryList = new List<SelectListItem>();
        }
        public int? PizzaId { get; set; }
        public string Display { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public IList<PizzaCreateSizeBaseViewModel> SizeBaseList { get; set; }
    }
}
