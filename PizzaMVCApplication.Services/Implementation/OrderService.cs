using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;

namespace PizzaMVCApplication.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int GroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Search(Order order)
        {
            IEnumerable<Order> list = _context.Orders.ToList();

            int? OrderId = order.OrderId;
            
            return list;
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
