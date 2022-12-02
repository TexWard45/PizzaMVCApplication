using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category Category)
        {
            await _context.Categories.AddAsync(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int CategoryId)
        {
            var category = GetById(CategoryId);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategories(List<int> ArrayId)
        {    
            for(int i = 0; i < ArrayId.Count; i++)
            {
                var pizza = _context.Pizzas.Where(e => e.CategoryId == ArrayId[i]).ToList();
                if (pizza.Count > 0)
                    continue;
                var category = GetById(ArrayId[i]);
                _context.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int? CategoryId)
        {
            return _context.Categories.Where(e => e.CategoryId == CategoryId).FirstOrDefault();
        }

        public Category GetByName(string Display)
        {
            return _context.Categories.Where(e => e.Display.Equals(Display)).SingleOrDefault();
        }

        public IEnumerable<Category> SearchByName(string Display)
        {
            return _context.Categories.Where(e => e.Display.Contains(Display)).ToList();
        }

        public async Task UpdateAsync(Category Category)
        {
            _context.Update(Category);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllToSelectListItem()
        {
            IEnumerable<Category> list = GetAll();

            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Category category in list)
            {
                selectList.Add(new SelectListItem
                {
                    Text = category.Display,
                    Value = category.CategoryId.ToString()
                });
            }

            return selectList;
        }
    }
}
