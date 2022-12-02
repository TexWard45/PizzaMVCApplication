using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IBaseService
    {
        public Base GetById(int? BaseId);
        public Task CreateAsync(Base Base);
        public Task UpdateAsync(Base Base);
        public Task DeleteAsync(int BaseId);
        public Task DeleteAsync(List<int> BaseIdList);
        public IEnumerable<Base> Search(Base Base);
        public IEnumerable<Base> GetAll();
    }
}
