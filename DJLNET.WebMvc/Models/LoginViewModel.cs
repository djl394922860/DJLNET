using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DJLNET.WebMvc.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 18, MinimumLength = 1)]
        [RegularExpression(@"^[\u4E00-\u9FA5A-Za-z0-9]+$")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [StringLength(maximumLength: 18, MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}