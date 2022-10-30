using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Linq;

namespace PizzaMVCApplication.Services.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly ApplicationDbContext _context;
        public SizeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Size GetById(int SizeId)
        {
            return _context.Sizes.Where(e => e.SizeId == SizeId).FirstOrDefault();
        }

        public async Task CreateAsync(Size size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Size size)
        {
            _context.Update(size);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int SizeId)
        {
            var size = GetById(SizeId);
            _context.Remove(size);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<int> SizeIdList)
        {
            foreach (int SizeId in SizeIdList)
            {
                var size = GetById(SizeId);
                _context.Remove(size);
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Size> Search(Size size)
        {
            IEnumerable<Size> list = _context.Sizes.ToList();

            int? SizeId = size.SizeId;
            string Display = size.Display;

            if (GroupId != null || Display != null)
            {
                return list.Where(obj =>
                        (SizeId != null && ("" + obj.SizeId).Contains("" + SizeId)) ||
                        (Display != null && obj.Display.Contains(Display)));
            }
            return list;
        }
        public IEnumerable<Size> GetAll()
        {
            return _context.Sizes.ToList();
        }
    }
}
