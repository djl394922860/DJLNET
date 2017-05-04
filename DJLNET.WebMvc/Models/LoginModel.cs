using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(maximumLength: 18, MinimumLength = 6)]
        [RegularExpression(@"^[\u4E00-\u9FA5A-Za-z0-9]+$", ErrorMessage = "用户名格式错误")]
        [DataType(DataType.Text)]
        [DisplayName("用户名")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 18, MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage ="密码格式错误，只能包含数字和字母")]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}