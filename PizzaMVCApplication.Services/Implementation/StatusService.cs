using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Collections.Generic;
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

        public async Task CreateAsync(Status Status)
        {
            await _context.Status.AddAsync(Status);
            await _context.SaveChangesAsync();
        }

        public async Task CreateStatusDetailAsync(StatusDetail StatusDetail)
        {
            await _context.StatusDetails.AddAsync(StatusDetail);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int StatusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int? StatusId)
        {
            return _context.Status.Where(e => e.StatusId == StatusId).FirstOrDefault();
        }

        public Status GetByOrderId(int? OrderId)
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

        public IEnumerable<StatusDetail> GetListStatusDetail(int? OrderId, int Length)
        {
            List<StatusDetail> newList = new List<StatusDetail>();
            for (int i = 1; i <= Length; i++) {
                StatusDetail statusDetail = this.GetByStatusId(OrderId, i);
                newList.Add(statusDetail);
            }
            return newList;    
        }

        public IEnumerable<Status> Search(Status status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStatusDetailAsync(StatusDetail StatusDetail)
        {
            await _context.StatusDetails.AddAsync(StatusDetail);
            await _context.SaveChangesAsync();
        }
    }
}
