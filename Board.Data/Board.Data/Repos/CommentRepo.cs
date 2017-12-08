using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class CommentRepo
    {
        public void Add(Comment comment)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                comment.Post = context.Posts.Single(p => p.Id == comment.Post.Id);
                comment.User = context.Users.Single(u => u.Id == comment.User.Id);
                comment.Date = DateTime.Now;

                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public Comment Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Comments.Single(a => a.Id == index);
            }
        }

        public List<Comment> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Comments.ToList();
            }
        }

        public List<Comment> Get(Post post)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Comments.Where(c => c.Post.Id == post.Id).Include(c => c.User).Include(c => c.Post).OrderByDescending(c => c.Date).ToList();
            }
        }

        public void Drop(Comment comment)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dComment = context.Comments.Single(u => u.Id == comment.Id);
                if (dComment != null)
                {
                    context.Comments.Remove(dComment);
                }

                context.SaveChanges();
            }
        }

        public void Drop(int index)
        {
            using (var context = new BoardContext())
            {
                context.Comments.Remove(context.Comments.Single(c => c.Id == index));
                context.SaveChanges();
            }
        }

        public void Edit(Comment comment)
        {
            using (var context = new BoardContext())
            {
                var dbComment = context.Comments.Include(u => u.User).Include(p => p.Post).Single(c => c.Id == comment.Id);
                dbComment.Content = comment.Content;
                
                context.Entry(dbComment).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
