using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class LoginModels
    {
        [Key]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}