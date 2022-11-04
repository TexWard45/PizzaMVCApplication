using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IOrderService
    {
        public Order GetById(int? OrderId);
        public Task UpdateAsync(Order order);
        public Task DeleteAsync(int OrderId);
        public IEnumerable<Order> Search(DateTime startDay, DateTime endDay);
        public IEnumerable<Order> GetAll();
        public IEnumerable<OrderDetail> GetListOrderDetail(int? OrderId);
    }
}
