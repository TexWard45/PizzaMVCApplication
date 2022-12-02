using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IPizzaService
    {
        public Pizza GetById(int? PizzaId);
        public IEnumerable<Pizza> GetAll();
        public IEnumerable<PizzaDetail> GetAllDetail();
        public Task UpdateAsync(Pizza Pizza); 
        public Task DeleteAsync(int PizzaId);
        public Task DeleteAsync(List<int?> PizzaIdList);
        public Task DeletePizzaDetailAsync(int PizzaId);
        public Task UpdatePizzaDetail(PizzaDetail PizzaDetail);
        public PizzaDetail GetByPizzaDetailId(int? PizzaDetailId);
        public Task CreatePizzaAsync(Pizza Pizza);
        public Task CreateOrUpdatePizzaDetailAsync(PizzaDetail PizzaDetail);
        public PizzaDetail GetPizzaDetail(int? PizzaId, int? SizeId, int? BaseId);
        public IEnumerable<PizzaDetail> GetAllPizzaDetail(int? PizzaId);
        public IEnumerable<Pizza> Search(Pizza pizza);
    }
}
