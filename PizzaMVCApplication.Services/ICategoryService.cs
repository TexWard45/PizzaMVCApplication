using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface ICategoryService
    {
        public Category GetById(int? CategoryId);
        public Category GetByName(string Display);
        public IEnumerable<Category> GetAll();
        public IEnumerable<Category> SearchByName(string Display);
        public Task UpdateAsync(Category Category);
        public Task DeleteAsync(int CategoryId);
        public Task DeleteCategories(List<int> ArrayId);
        public Task CreateAsync(Category Category);
        public IEnumerable<SelectListItem> GetAllToSelectListItem();
    }
}
