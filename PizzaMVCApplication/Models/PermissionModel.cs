using PizzaMVCApplication.Entity;
using System.Security;

namespace PizzaMVCApplication.Models
{
    public class PermissionModel
    {
        private PermissionModel(string _Name, string _Permission, string _Label) { Name = _Name; Permission = _Permission; Label = _Label; }

        public string Name { get; private set; }
        public string Permission { get; private set; }
        public string Label { get; private set; }

        public static PermissionModel AdminLogin { get { return new PermissionModel("AdminLogin", "admin.login", "Đăng nhập trang quản trị"); } }
        public static PermissionModel AdminUserGroup { get { return new PermissionModel("AdminUserGroup", "admin.group", "Quản lý nhóm người dùng"); } }
        public static PermissionModel AdminUser { get { return new PermissionModel("AdminUser", "admin.user", "Quản lý người dùng"); } }
        public static PermissionModel AdminCategory { get { return new PermissionModel("AdminCategory", "admin.category", "Quản lý thể loại"); } }
        public static PermissionModel AdminSize { get { return new PermissionModel("AdminSize", "admin.size", "Quản lý kích thước"); } }
        public static PermissionModel AdminBase { get { return new PermissionModel("AdminBase", "admin.base", "Quản lý đế bánh"); } }
        public static PermissionModel AdminTopping { get { return new PermissionModel("AdminTopping", "admin.topping", "Quản lý nhân bánh"); } }
        public static PermissionModel AdminPizza { get { return new PermissionModel("AdminPizza", "admin.pizza", "Quản lý bánh pizza"); } }
        public static PermissionModel AdminOrder { get { return new PermissionModel("AdminOrder", "admin.order", "Quản lý đơn hàng"); } }
        public static PermissionModel AdminStatistic { get { return new PermissionModel("AdminStatistic", "admin.statistic", "Thống kê báo cáo"); } }

        public static IEnumerable<PermissionModel> Values = new PermissionModel[] { 
                AdminLogin,
                AdminUserGroup,
                AdminUser,
                AdminCategory,
                AdminSize,
                AdminBase,
                AdminTopping,
                AdminPizza,
                AdminOrder,
                AdminStatistic
            };

        public static PermissionModel ValueOf(string Permission)
        {
            foreach (PermissionModel PermissionModel in Values)
            {
                if (PermissionModel.Permission == Permission)
                {
                    return PermissionModel;
                }
            }
            return null;
        }
    }
}
