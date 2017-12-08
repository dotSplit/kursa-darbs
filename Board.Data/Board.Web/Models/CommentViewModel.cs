using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class CommentViewModel
    {
        public List<CVMExtra> Comments;
    }

    public class CVMExtra
    {
        public Comment Comment;
        public int CommentRating;
    }
}