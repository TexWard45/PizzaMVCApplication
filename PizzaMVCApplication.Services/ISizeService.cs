using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface ISizeService
    {
        public Size GetById(int? SizeId);
        public Task UpdateAsync(Size Size);
        public Task DeleteAsync(int SizeId);
    }
}
