using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Text.RegularExpressions;

namespace PizzaMVCApplication.Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;
        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int PizzaId)
        {
            var pizza = GetById(PizzaId);
            _context.Remove(pizza);
            await _context.SaveChangesAsync();
        }

        public Pizza GetById(int? PizzaId)
        {
            return _context.Pizzas.Where(e => e.Id == PizzaId).FirstOrDefault();
        }

        public PizzaDetail GetByPizzaDetailId(int? PizzaDetailId)
        {
            return _context.PizzaDetails.Where(e => e.Id == PizzaDetailId).FirstOrDefault();
        }

        public async Task UpdateAsync(Pizza Pizza)
        {
            _context.Update(Pizza);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePizzaDetail(PizzaDetail PizzaDetail)
        {
            _context.Update(PizzaDetail);
            await _context.SaveChangesAsync();
        }
    }
}
