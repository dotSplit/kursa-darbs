using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Web.Models
{
    public class CommentCreateViewModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}