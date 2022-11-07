using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface ICategoryService
    {
        public Category GetById(int? CategoryId);
        public IEnumerable<Category> GetAll();
        public Task UpdateAsync(Category Category);
        public Task DeleteAsync(int CategoryId);
    }
}
