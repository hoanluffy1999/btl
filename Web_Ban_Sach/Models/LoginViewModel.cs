using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Ban_Sach.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Phải nhập user name")]
        [Display(Name = "UserName")]
        [Key]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Không được để trống mật khẩu")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}