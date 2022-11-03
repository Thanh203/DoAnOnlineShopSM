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
        [Required(ErrorMessage = "Ban phai nhap tai khoan")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Ban phai nhap mat khau")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}