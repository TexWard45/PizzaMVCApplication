using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace PizzaMVCApplication.Services.Implementation
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly ApplicationDbContext _context;
        public UserPermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserPermission GetPermissionByUsernameAndPermission(string Username, string Permission)
        {
            return _context.UserPermissions.Where(e => e.Username == Username && e.Permission == Permission).FirstOrDefault();
        }

        public IEnumerable<UserPermission> GetPermissionsByUsername(string Username)
        {
            return _context.UserPermissions.Where(e => e.Username == Username);
        }

        public async Task CreateOrUpdateAsync(UserPermission Permission)
        {
            UserPermission oldPermission = GetPermissionByUsernameAndPermission(Permission.Username, Permission.Permission);

            if (oldPermission == null)
            {
                await _context.UserPermissions.AddAsync(Permission);
                await _context.SaveChangesAsync();
            }
            else
            {
                oldPermission.Value = Permission.Value;
                _context.UserPermissions.Update(oldPermission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateOrUpdatePermissionsAsync(IEnumerable<UserPermission> Permissions)
        {
            foreach (UserPermission Permission in Permissions)
            {
                UserPermission OldPermission = GetPermissionByUsernameAndPermission(Permission.Username, Permission.Permission);

                if (OldPermission == null)
                {
                    await _context.UserPermissions.AddAsync(Permission);
                }
                else
                {
                    OldPermission.Value = Permission.Value;
                    _context.UserPermissions.Update(OldPermission);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Username)
        {
            IEnumerable<UserPermission> list = GetPermissionsByUsername(Username);

            foreach (UserPermission permission in list)
            {
                _context.Remove(permission);
            }

            await _context.SaveChangesAsync();
        }
    }
}
