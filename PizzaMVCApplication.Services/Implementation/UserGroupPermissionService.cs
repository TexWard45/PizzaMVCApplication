using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace PizzaMVCApplication.Services.Implementation
{
    public class UserGroupPermissionService : IUserGroupPermissionService
    {
        private readonly ApplicationDbContext _context;
        public UserGroupPermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserGroupPermission GetPermissionByGroupIdAndPermission(int GroupId, string Permission)
        {
            return _context.UserGroupPermissions.Where(e => e.UserGroupId == GroupId && e.Permission == Permission).FirstOrDefault();
        }

        public IEnumerable<UserGroupPermission> GetPermissionsByGroupId(int GroupId)
        {
            return _context.UserGroupPermissions.Where(e => e.UserGroupId == GroupId);
        }

        public async Task CreateOrUpdateAsync(UserGroupPermission Permission)
        {
            UserGroupPermission oldPermission = GetPermissionByGroupIdAndPermission(Permission.UserGroupId, Permission.Permission);

            if (oldPermission == null)
            {
                await _context.UserGroupPermissions.AddAsync(Permission);
                await _context.SaveChangesAsync();
            }else
            {
                oldPermission.Value = Permission.Value;
                _context.UserGroupPermissions.Update(oldPermission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateOrUpdatePermissionsAsync(IEnumerable<UserGroupPermission> Permissions)
        {
            foreach (UserGroupPermission Permission in Permissions)
            {
                UserGroupPermission OldPermission = GetPermissionByGroupIdAndPermission(Permission.UserGroupId, Permission.Permission);

                if (OldPermission == null)
                {
                    await _context.UserGroupPermissions.AddAsync(Permission);
                }
                else
                {
                    OldPermission.Value = Permission.Value;
                    _context.UserGroupPermissions.Update(OldPermission);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int GroupId)
        {
            IEnumerable<UserGroupPermission> list = GetPermissionsByGroupId(GroupId);

            foreach (UserGroupPermission permission in list) {
                _context.Remove(permission);
            }

            await _context.SaveChangesAsync();
        }
    }
}
