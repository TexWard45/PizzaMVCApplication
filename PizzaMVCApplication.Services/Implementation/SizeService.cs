using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly ApplicationDbContext _context;
        public SizeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task DeleteAsync(int SizeId)
        {
            throw new NotImplementedException();
        }

        public Size GetById(int? SizeId)
        {
            return _context.Sizes.Where(e => e.SizeId == SizeId).FirstOrDefault();
        }

        public Task UpdateAsync(Size Size)
        {
            throw new NotImplementedException();
        }
    }
}
