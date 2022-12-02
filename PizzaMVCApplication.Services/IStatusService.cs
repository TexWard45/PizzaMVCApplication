using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IStatusService
    {
        public Status GetById(int? StatusId);
        public Status GetByOrderId(int? OrderId);
        public Task UpdateAsync(Status Status);
        public Task UpdateStatusDetailAsync(StatusDetail StatusDetail);
        public Task DeleteAsync(int StatusId);
        public Task CreateAsync(Status Status);
        public Task CreateStatusDetailAsync(StatusDetail StatusDetail);
        public IEnumerable<Status> Search(Status status);
        public IEnumerable<Status> GetAll();
        public IEnumerable<StatusDetail> GetAllDetail();
        public StatusDetail GetByStatusId(int? OrderId, int Length);
        public IEnumerable<StatusDetail> GetListStatusDetail(int? OrderId, int StatusId);
        public StatusDetail GetFirstStatusDetail(int? OrderId);
        public StatusDetail GetLastStatusDetail(int? OrderId);
    }
}
