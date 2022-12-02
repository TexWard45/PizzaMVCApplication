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

        public User GetByUsername(string Username)
        {
            User user = _context.Users.Where(e => e.Username == Username).FirstOrDefault();

            if (user != null)
            {
                user.UserGroup = _context.UserGroups.Where(e => e.GroupId == user.UserGroupId).FirstOrDefault();
            }

            return user;
        }

        public IEnumerable<User> Search(User user)
        {
            IEnumerable<User> list = GetAll();

            string Username = user.Username;

            if (Username != null)
            {
                return list.Where(obj =>
                        (Username != null && obj.Username.Contains(Username)));
            }
            return list;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Username)
        {
            var group = GetByUsername(Username);
            _context.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<string> UsernameList)
        {
            foreach (string Username in UsernameList)
            {
                var group = GetByUsername(Username);
                _context.Remove(group);
            }
            await _context.SaveChangesAsync();
        }

        public bool HasUsername(string username)
        {
            return _context.Users.Any(x => x.Username == username);
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
