using PizzaMVCApplication.Entity;

namespace PizzaMVCApplication.Models
{
    public class UserIndexViewModel
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string GroupDisplay { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Checked { get; set; }
    }
}
