using PizzaMVCApplication.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaMVCApplication.Models
{
    public class UserInfoViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string GroupDisplay { get; set; }
        public string Fullname { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
