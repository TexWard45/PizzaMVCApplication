using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class ToppingService : IToppingService
    {
        private readonly ApplicationDbContext _context;
        public ToppingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CreateAsync(Topping topping)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int ToppingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topping> GetAll()
        {
            return _context.Toppings.ToList();
        }

        public Topping GetById(int ToppingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topping> Search(Topping topping)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Topping topping)
        {
            throw new NotImplementedException();
        }
    }
}
