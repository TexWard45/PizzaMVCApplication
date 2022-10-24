using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Services
{
    public interface IUserGroupService
    {
        public UserGroup GetById(int GroupId);
        public Task CreateAsync(UserGroup userGroup);
        public Task UpdateAsync(UserGroup userGroup);
        public Task DeleteAsync(int GroupId);
        public Task DeleteAsync(List<int> GroupIdList);
        public IEnumerable<UserGroup> Search(UserGroup userGroup);
        public IEnumerable<UserGroup> GetAll();
    }
}
