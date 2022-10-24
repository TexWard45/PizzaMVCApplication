using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IOrderService
    {
        public Order GetById(int GroupId);
        public Task UpdateAsync(Order order);
        public Task DeleteAsync(int OrderId);
        public IEnumerable<Order> Search(Order order);
        public IEnumerable<Order> GetAll();
    }
}
