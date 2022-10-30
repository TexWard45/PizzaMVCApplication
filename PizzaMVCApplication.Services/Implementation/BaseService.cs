using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class BaseService : IBaseService
    {
        private readonly ApplicationDbContext _context;
        public BaseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task DeleteAsync(int BaseId)
        {
            throw new NotImplementedException();
        }

        public Base GetById(int? BaseId)
        {
            return _context.Bases.Where(e => e.BaseId == BaseId).FirstOrDefault();
        }

        public Task UpdateAsync(Base Base)
        {
            throw new NotImplementedException();
        }
    }
}
