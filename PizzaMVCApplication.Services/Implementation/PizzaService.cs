using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Security;
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

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public IEnumerable<PizzaDetail> GetAllDetail()
        {
            return _context.PizzaDetails.ToList();
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
        public async Task CreatePizzaAsync(Pizza Pizza)
        {
            _context.Add(Pizza);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrUpdatePizzaDetailAsync(PizzaDetail PizzaDetail)
        {
            PizzaDetail _PizzaDetail = GetPizzaDetail(PizzaDetail.PizzaId, PizzaDetail.SizeId, PizzaDetail.BaseId);

            if (_PizzaDetail == null)
            {
                await _context.PizzaDetails.AddAsync(PizzaDetail);
                await _context.SaveChangesAsync();
            }
            else
            {
                _PizzaDetail.Price = PizzaDetail.Price;
                _PizzaDetail.Quantity = PizzaDetail.Quantity;
                _context.PizzaDetails.Update(_PizzaDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(List<int?> PizzaIdList)
        {
            foreach (int PizzaId in PizzaIdList)
            {
                DeletePizzaDetailAsync(PizzaId);

                var pizza = GetById(PizzaId);
                _context.Remove(pizza);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePizzaDetailAsync(int PizzaId)
        {
            foreach (PizzaDetail pizzaDetail in GetAllPizzaDetail(PizzaId))
            {
                _context.Remove(pizzaDetail);
            }
        }

        public PizzaDetail GetPizzaDetail(int? PizzaId, int? SizeId, int? BaseId)
        {
            return _context.PizzaDetails.Where(e => e.PizzaId == PizzaId && e.SizeId == SizeId && e.BaseId == BaseId).FirstOrDefault();
        }

        public IEnumerable<PizzaDetail> GetAllPizzaDetail(int? PizzaId)
        {
            IEnumerable<PizzaDetail> list = _context.PizzaDetails.Where(e => e.PizzaId == PizzaId);

            foreach (PizzaDetail pizzaDetail in list)
            {
                pizzaDetail.Base = _context.Bases.Where(e => e.BaseId == pizzaDetail.BaseId).FirstOrDefault();
                pizzaDetail.Size = _context.Sizes.Where(e => e.SizeId == pizzaDetail.SizeId).FirstOrDefault();
            }

            return list;

        }

        public IEnumerable<Pizza> Search(Pizza pizza)
        {
            IEnumerable<Pizza> list = _context.Pizzas.ToList();

            string Display = pizza.Display;

            if (Display != null)
            {
                return list.Where(obj =>
                        (Display != null && obj.Display.Contains(Display)));
            }
            return list;
        }
    }
}
