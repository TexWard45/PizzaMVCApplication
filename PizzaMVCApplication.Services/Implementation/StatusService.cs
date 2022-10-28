using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Text.RegularExpressions;

namespace PizzaMVCApplication.Services.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;
        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(int StatusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int? OrderId)
        {
            int StatusId = GetLastStatusDetail(OrderId).StatusId;
            return _context.Status.Where(e => e.StatusId == StatusId).FirstOrDefault();
        }

        public StatusDetail GetByStatusId(int? OrderId, int StatusId)
        {
            StatusDetail Detail = _context.StatusDetails.ToList().Where(
                obj => obj.StatusId == StatusId && obj.OrderId == OrderId
             ).FirstOrDefault();
            return Detail;
        }

        public StatusDetail GetFirstStatusDetail(int? OrderId)
        {
            StatusDetail Detail = _context.StatusDetails.ToList().Where(
                obj => obj.OrderId == OrderId
             ).OrderBy(value => value.StatusId).FirstOrDefault();
            return Detail;
        }

        public StatusDetail GetLastStatusDetail(int? OrderId)
        {
            StatusDetail Detail = _context.StatusDetails.ToList().Where(
                obj => obj.OrderId == OrderId
             ).OrderByDescending(value => value.StatusId).FirstOrDefault();
            return Detail;
        }

        public IEnumerable<Status> Search(Status status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
