using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMVCApplication.Services.Implementation
{
    public class UserGroupService : IUserGroupService
    {
        private readonly ApplicationDbContext _context;
        public UserGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserGroup GetById(int GroupId)
        {
            return _context.UserGroups.Where(e => e.GroupId == GroupId).FirstOrDefault();
        }

        public async Task CreateAsync(UserGroup userGroup)
        {
            await _context.UserGroups.AddAsync(userGroup);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserGroup userGroup)
        {
            _context.Update(userGroup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int GroupId)
        {
            var group = GetById(GroupId);
            _context.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(List<int> GroupIdList)
        {
            foreach (int GroupId in GroupIdList)
            {
                var group = GetById(GroupId);
                _context.Remove(group);
            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<UserGroup> Search(UserGroup userGroup)
        {
            IEnumerable<UserGroup> list = _context.UserGroups.ToList();

            int? GroupId = userGroup.GroupId;
            string Display = userGroup.Display;

            if (GroupId != null || Display != null)
            {
                return list.Where(obj =>
                        (GroupId != null && ("" + obj.GroupId).Contains("" + GroupId)) ||
                        (Display != null && obj.Display.Contains(Display)));
            }
            return list;
        }

        public IEnumerable<UserGroup> GetAll()
        {
            return _context.UserGroups.ToList();
        }

        public IEnumerable<SelectListItem> GetAllToSelectListItem()
        {
            IEnumerable<UserGroup> list = GetAll();

            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (UserGroup userGroup in list)
            {
                selectList.Add(new SelectListItem
                {
                    Text = userGroup.Display, Value = userGroup.GroupId.ToString()
                });
            }

            return selectList;
        }

        public IEnumerable<SelectListItem> GetAllToSelectListItem(int GroupIdSelected)
        {
            IEnumerable<UserGroup> list = GetAll();

            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (UserGroup userGroup in list)
            {
                selectList.Add(new SelectListItem
                {
                    Text = userGroup.Display,
                    Value = userGroup.GroupId.ToString(),
                    Selected = userGroup.GroupId == GroupIdSelected
                });
            }

            return selectList;
        }
    }
}
