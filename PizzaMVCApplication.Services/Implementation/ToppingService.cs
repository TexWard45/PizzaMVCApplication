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
        public async Task CreateAsync(Topping Topping)
        {
            await _context.Toppings.AddAsync(Topping);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ToppingId)
        {
            var topping = GetById(ToppingId);
            _context.Remove(topping);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToppings(List<int> ArrayId)
        {
            for (int i = 0; i < ArrayId.Count; i++)
            {
                var detail = _context.ToppingDetails.Where(e => e.ToppingId == ArrayId[i]).ToList();
                if (detail.Count > 0)
                    continue;
                var topping = GetById(ArrayId[i]);
                _context.Remove(topping);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Topping> GetAll()
        {
            return _context.Toppings.ToList();
        }

        public Topping GetById(int? ToppingId)
        {
            return _context.Toppings.Where(e => e.ToppingId == ToppingId).FirstOrDefault();
        }

        public Topping GetByName(string Display)
        {
            return _context.Toppings.Where(e => e.Display.Equals(Display)).SingleOrDefault();
        }

        public IEnumerable<Topping> SearchByName(string Display)
        {
            return _context.Toppings.Where(e => e.Display.Contains(Display)).ToList();
        }

        public async Task UpdateAsync(Topping Topping)
        {
            _context.Update(Topping);
            await _context.SaveChangesAsync();
        }
    }
}
