using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IUserPermissionService
    {
        public UserPermission GetPermissionByUsernameAndPermission(string Username, string Permission);
        public IEnumerable<UserPermission> GetPermissionsByUsername(string Username);
        public Task CreateOrUpdatePermissionsAsync(IEnumerable<UserPermission> Permissions);
        public Task CreateOrUpdateAsync(UserPermission Permission);
        public Task DeleteAsync(string Username);
    }
}
