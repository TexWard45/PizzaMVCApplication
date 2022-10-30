using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IStatusService
    {
        public Status GetById(int? StatusId);
        public Status GetByOrderId(int? OrderId);
        public Task UpdateAsync(Status status);
        public Task DeleteAsync(int StatusId);
        public IEnumerable<Status> Search(Status status);
        public IEnumerable<Status> GetAll();
        public StatusDetail GetByStatusId(int? OrderId, int Length);
        public IEnumerable<StatusDetail> GetListStatusDetail(int? OrderId, int StatusId);
        public StatusDetail GetFirstStatusDetail(int? OrderId);
        public StatusDetail GetLastStatusDetail(int? OrderId);
    }
}
