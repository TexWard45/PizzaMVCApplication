using PizzaMVCApplication.Entity;
using System.Collections.Generic;

namespace PizzaMVCApplication.Models
{
    public class UserGroupPermissionViewModel
    {
        public IEnumerable<PermissionModel> Permissions { get; set; }
        public int GroupId { get; set; }
        public string GroupDisplay { get; set; }
        public string AdminLogin { get; set; } = "false";
        public string AdminUserGroup { get; set; } = "false";
        public string AdminUser { get; set; } = "false";
        public string AdminCategory { get; set; } = "false"; 
        public string AdminSize { get; set; } = "false";
        public string AdminBase { get; set; } = "false";
        public string AdminTopping { get; set; } = "false";
        public string AdminPizza { get; set; } = "false";
        public string AdminOrder { get; set; } = "false";
        public string AdminStatistic { get; set; } = "false";

        public string ValueOf(string Name)
        {
            if (Name == PermissionModel.AdminLogin.Name) return AdminLogin;
            if (Name == PermissionModel.AdminUserGroup.Name) return AdminUserGroup;
            if (Name == PermissionModel.AdminUser.Name) return AdminUser;
            if (Name == PermissionModel.AdminCategory.Name) return AdminCategory;
            if (Name == PermissionModel.AdminSize.Name) return AdminSize;
            if (Name == PermissionModel.AdminBase.Name) return AdminBase;
            if (Name == PermissionModel.AdminTopping.Name) return AdminTopping;
            if (Name == PermissionModel.AdminPizza.Name) return AdminPizza;
            if (Name == PermissionModel.AdminOrder.Name) return AdminOrder;
            if (Name == PermissionModel.AdminStatistic.Name) return AdminStatistic;

            return "false";
        }

        public static UserGroupPermissionViewModel From(int GroupId, IEnumerable<UserGroupPermission> groupPermissionList)
        {
            UserGroupPermissionViewModel model = new UserGroupPermissionViewModel();
            model.Permissions = PermissionModel.Values;
            model.GroupId = GroupId;

            foreach (UserGroupPermission permission in groupPermissionList) {
                PermissionModel permissionModel = PermissionModel.ValueOf(permission.Permission);
                string value = permission.Value;

                if (permission == null)
                {
                    continue;
                }

                if (permissionModel.Name == PermissionModel.AdminLogin.Name)
                {
                    model.AdminLogin = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminUserGroup.Name)
                {
                    model.AdminUserGroup = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminUser.Name)
                {
                    model.AdminUser = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminCategory.Name)
                {
                    model.AdminCategory = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminSize.Name)
                {
                    model.AdminSize = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminBase.Name)
                {
                    model.AdminBase = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminTopping.Name)
                {
                    model.AdminTopping = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminPizza.Name)
                {
                    model.AdminPizza = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminOrder.Name)
                {
                    model.AdminOrder = value;
                }
                else if (permissionModel.Name == PermissionModel.AdminStatistic.Name)
                {
                    model.AdminStatistic = value;
                }
            }
            return model;
        }

        public static IEnumerable<UserGroupPermission> To(UserGroupPermissionViewModel Model)
        {
            int GroupId = Model.GroupId;
            IList<UserGroupPermission> list = new List<UserGroupPermission>();

            Add(list, GroupId, PermissionModel.AdminLogin, Model.AdminLogin);
            Add(list, GroupId, PermissionModel.AdminUserGroup, Model.AdminUserGroup);
            Add(list, GroupId, PermissionModel.AdminUser, Model.AdminUser);
            Add(list, GroupId, PermissionModel.AdminCategory, Model.AdminCategory);
            Add(list, GroupId, PermissionModel.AdminSize, Model.AdminSize);
            Add(list, GroupId, PermissionModel.AdminBase, Model.AdminBase);
            Add(list, GroupId, PermissionModel.AdminTopping, Model.AdminTopping);
            Add(list, GroupId, PermissionModel.AdminPizza, Model.AdminPizza);
            Add(list, GroupId, PermissionModel.AdminOrder, Model.AdminOrder);
            Add(list, GroupId, PermissionModel.AdminStatistic, Model.AdminStatistic);

            return list;
        }

        private static void Add(IList<UserGroupPermission> List, int GroupId, PermissionModel Permission, string Value)
        {
            List.Add(new UserGroupPermission
            {
                UserGroupId = GroupId,
                Permission = Permission.Permission,
                Value = Value
            });
        }
    }
}
