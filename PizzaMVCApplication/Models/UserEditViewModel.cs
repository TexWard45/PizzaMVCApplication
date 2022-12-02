using PizzaMVCApplication.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaMVCApplication.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu không được để trống")]
        public string RetypePassword { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<SelectListItem>? GroupIdList { get; set; }
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string Fullname { get; set; }
        public DateTime Birth { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại chứa 10 chữ số")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Thư điện tử không được để trống")]
        [EmailAddress(ErrorMessage = "Thư điện tử không hợp lệ")]
        public string Email { get; set; }
    }
}
