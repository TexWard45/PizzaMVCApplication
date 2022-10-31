using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IOrderService
    {
        public Order GetById(int? OrderId);
        public Task UpdateAsync(Order Order);
        public Task DeleteAsync(int OrderId);
        public IEnumerable<Order> Search(DateTime StartDay, DateTime EndDay);
        public IEnumerable<Order> GetAll();
        public IEnumerable<OrderDetail> GetListOrderDetail(int? OrderId);
    }
}
