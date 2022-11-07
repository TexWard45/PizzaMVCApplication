﻿using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IPizzaService
    {
        public Pizza GetById(int? PizzaId);
        public IEnumerable<Pizza> GetAll();
        public IEnumerable<PizzaDetail> GetAllDetail();
        public Task UpdateAsync(Pizza Pizza); 
        public Task DeleteAsync(int PizzaId);
        public Task UpdatePizzaDetail(PizzaDetail PizzaDetail);
        public PizzaDetail GetByPizzaDetailId(int? PizzaDetailId);
    }
}
