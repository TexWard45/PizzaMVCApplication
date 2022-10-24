using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Text.RegularExpressions;

namespace PizzaMVCApplication.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _context.Users.ToList();

            foreach (User user in users)
            {
                user.UserGroup = _context.UserGroups.Where(e => e.GroupId == user.UserGroupId).FirstOrDefault();
            }

            return users;
        }
    }
}
