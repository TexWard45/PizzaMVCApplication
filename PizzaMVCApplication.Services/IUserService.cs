using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public IEnumerable<User> Search(User user);
        public User GetByUsername(string Username);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(string Username);
        public Task DeleteAsync(List<string> Username);
        public bool HasUsername(string username);
        public Task CreateAsync(User user);
    }
}
