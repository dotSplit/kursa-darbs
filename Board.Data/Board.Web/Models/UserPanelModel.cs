using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class UserPanelModel
    {
        public User User { get; set; }
        public UserEditViewModel UserEdit { get; set; }
        public List<Post> Posts { get; set; }
        public Comment NewComment { get; set; }
    }
}