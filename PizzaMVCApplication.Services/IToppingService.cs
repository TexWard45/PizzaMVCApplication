using PizzaMVCApplication.Entity;
namespace PizzaMVCApplication.Services
{
    public interface IToppingService
    {
        public Topping GetById(int? ToppingId);
        public Topping GetByName(string Display);
        public IEnumerable<Topping> GetAll();
        public IEnumerable<Topping> SearchByName(string Display);
        public Task UpdateAsync(Topping Topping);
        public Task DeleteAsync(int ToppingId);
        public Task DeleteToppings(List<int> ArrayId);
        public Task CreateAsync(Topping Topping);
    }
}
