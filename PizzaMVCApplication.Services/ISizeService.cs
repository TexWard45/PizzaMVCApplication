using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface ISizeService
    {
        public Size GetById(int SizeId);
        public Task CreateAsync(Size size);
        public Task UpdateAsync(Size size);
        public Task DeleteAsync(int SizeId);
        public Task DeleteAsync(List<int> SizeIdList);
        public IEnumerable<Size> Search(Size size);
        public IEnumerable<Size> GetAll();
    }
}
