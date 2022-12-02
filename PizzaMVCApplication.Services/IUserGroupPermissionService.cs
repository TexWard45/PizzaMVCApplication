using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IUserGroupPermissionService
    {
        public UserGroupPermission GetPermissionByGroupIdAndPermission(int GroupId, string Permission);
        public IEnumerable<UserGroupPermission> GetPermissionsByGroupId(int GroupId);
        public Task CreateOrUpdatePermissionsAsync(IEnumerable<UserGroupPermission> Permissions);
        public Task CreateOrUpdateAsync(UserGroupPermission Permission);
        public Task DeleteAsync(int GroupId);
    }
}
