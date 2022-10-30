using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IBaseService
    {
        public Base GetById(int BaseId);
        public Task CreateAsync(Base base);
        public Task UpdateAsync(Base base);
        public Task DeleteAsync(int BaseId);
        public Task DeleteAsync(List<int> BaseIdList);
        public IEnumerable<Base> Search(Base base);
        public IEnumerable<Base> GetAll();
    }
}
