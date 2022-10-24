using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}
