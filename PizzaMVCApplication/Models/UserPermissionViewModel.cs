using PizzaMVCApplication.Entity;
using System.Collections.Generic;

namespace PizzaMVCApplication.Models
{
    public class UserPermissionViewModel
    {
        public IEnumerable<PermissionModel> Permissions { get; set; }
        public string Username { get; set; }
        public string AdminLogin { get; set; } = "auto";
        public string AdminUserGroup { get; set; } = "auto";
        public string AdminUser { get; set; } = "auto";
        public string AdminCategory { get; set; } = "auto";
        public string AdminSize { get; set; } = "auto";
        public string AdminBase { get; set; } = "auto";
        public string AdminTopping { get; set; } = "auto";
        public string AdminPizza { get; set; } = "auto";
        public string AdminOrder { get; set; } = "auto";
        public string AdminStatistic { get; set; } = "auto";

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

        public static UserPermissionViewModel From(string Username, IEnumerable<UserPermission> userPermissionList)
        {
            UserPermissionViewModel model = new UserPermissionViewModel();
            model.Permissions = PermissionModel.Values;
            model.Username = Username;

            foreach (UserPermission permission in userPermissionList)
            {
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

        public static IEnumerable<UserPermission> To(UserPermissionViewModel Model)
        {
            string Username = Model.Username;
            IList<UserPermission> list = new List<UserPermission>();

            Add(list, Username, PermissionModel.AdminLogin, Model.AdminLogin);
            Add(list, Username, PermissionModel.AdminUserGroup, Model.AdminUserGroup);
            Add(list, Username, PermissionModel.AdminUser, Model.AdminUser);
            Add(list, Username, PermissionModel.AdminCategory, Model.AdminCategory);
            Add(list, Username, PermissionModel.AdminSize, Model.AdminSize);
            Add(list, Username, PermissionModel.AdminBase, Model.AdminBase);
            Add(list, Username, PermissionModel.AdminTopping, Model.AdminTopping);
            Add(list, Username, PermissionModel.AdminPizza, Model.AdminPizza);
            Add(list, Username, PermissionModel.AdminOrder, Model.AdminOrder);
            Add(list, Username, PermissionModel.AdminStatistic, Model.AdminStatistic);

            return list;
        }

        private static void Add(IList<UserPermission> List, string Username, PermissionModel Permission, string Value)
        {
            List.Add(new UserPermission
            {
                Username = Username,
                Permission = Permission.Permission,
                Value = Value
            });
        }
    }
}
