using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;
        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task DeleteAsync(int PizzaId)
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int? PizzaId)
        {
            return _context.Pizzas.Where(e => e.Id == PizzaId).FirstOrDefault();
        }

        public PizzaDetail GetByPizzaDetailId(int? PizzaDetailId)
        {
            return _context.PizzaDetails.Where(e => e.Id == PizzaDetailId).FirstOrDefault();
        }

        public Task UpdateAsync(Pizza Pizza)
        {
            throw new NotImplementedException();
        }
    }
}
