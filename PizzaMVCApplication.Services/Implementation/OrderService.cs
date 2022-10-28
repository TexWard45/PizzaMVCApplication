using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Collections.Immutable;
using System.Linq;
namespace PizzaMVCApplication.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private StatusService _statusService;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
            _statusService = new StatusService(_context);
        }

        public Task DeleteAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int OrderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Search(DateTime startDay, DateTime endDay)
        {
            IEnumerable<Order> list = _context.Orders.ToList();

            //var query = from ord in _context.Orders
            //            join detail in _context.StatusDetails on ord.OrderId equals detail.OrderId
            //            where detail.StatusId == 1 && detail.TimeCreated >= startDay && detail.TimeCreated <= endDay
            //            select new Order

            List<Order> newList = new List<Order>();
            foreach (Order order in list) {
                StatusDetail status = _statusService.GetFirstStatusDetail(order.OrderId);

                DateTime orderTimeCreated = status.TimeCreated;

                if (orderTimeCreated >= startDay && orderTimeCreated <= endDay)
                {
                    newList.Add(order);
                }
            }

            return newList;
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
