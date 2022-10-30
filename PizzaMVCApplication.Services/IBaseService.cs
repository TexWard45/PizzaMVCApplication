using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IBaseService
    {
        public Base GetById(int? BaseId);
        public Task UpdateAsync(Base Base);
        public Task DeleteAsync(int BaseId);
    }
}
