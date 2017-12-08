using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Web.Models
{
    public class UserAuthModel
    {
        public UserLoginViewModel loginModel { get; set; }
        public UserRegisterViewModel regModel { get; set; }
    }
}