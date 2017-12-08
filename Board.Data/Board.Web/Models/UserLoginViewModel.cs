using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Board.Web.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Enter E-Mail or Username")]
        [Display(Name = "E-Mail or Username")]
        public string AuthString { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AuthPass { get; set; }
    }
}