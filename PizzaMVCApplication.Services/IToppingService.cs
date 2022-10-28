using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IToppingService
    {
        public Topping GetById(int ToppingId);
        public Task CreateAsync(Topping topping);
        public Task UpdateAsync(Topping topping);
        public Task DeleteAsync(int ToppingId);
     
        public IEnumerable<Topping> Search(Topping topping);
        public IEnumerable<Topping> GetAll();
    }
}
