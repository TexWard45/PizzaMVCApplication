using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Linq;

namespace PizzaMVCApplication.Services.Implementation
{
    public class BaseService : IBaseService
    {
        private readonly ApplicationDbContext _context;
        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Base GetById(int BaseId)
        {
            return _context.Bases.Where(e => e.BaseId == BaseId).FirstOrDefault();
        }

        public async Task CreateAsync(Base base)
        {
            await _context.Bases.AddAsync(base);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Base base)
        {
            _context.Update(base);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int BaseId)
        {
            var base = GetById(BaseId);
            _context.Remove(base);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<int>BaseIdList)
        {
            foreach (int BaseId in BaseIdList)
            {
                var base = GetById(BaseId);
                _context.Remove(base);
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Base> Search(Base base)
        {
            IEnumerable<Base> list = _context.Bases.ToList();

            int? BaseId = base.BaseId;
            string Display = base.Display;

            if (BaseId != null || Display != null)
            {
                return list.Where(obj =>
                        (BaseId != null && ("" + obj.BaseId).Contains("" + BaseId)) ||
                        (Display != null && obj.Display.Contains(Display)));
            }
            return list;
        }
        public IEnumerable<Base> GetAll()
        {
            return _context.Bases.ToList();
        }
    }
}
