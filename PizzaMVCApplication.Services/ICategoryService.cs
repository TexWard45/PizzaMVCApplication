using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface ICategoryService
    {
        public Category GetById(int CategoryId);
        public Task CreateAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(int CategoryId);

        public IEnumerable<Category> Search(Category category);
        public IEnumerable<Category> GetAll();
    }
}
