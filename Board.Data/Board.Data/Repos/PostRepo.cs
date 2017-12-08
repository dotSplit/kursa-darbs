using System;
using System.Collections.Generic;
using System.Linq;
using Board.Data.Models;
using System.Data.Entity;


namespace Board.Data.Repos
{
    public class PostRepo
    {
        public int GetCount(int userId)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                int count = 0;
                count = context.Posts.Count(c => c.Id == userId);
                return count;
            }
        }

        public void Add(Post post)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                var id = post.User.Id;
                post.User = context.Users.Single(o => o.Id == id);
                post.Channel = context.Channels.Single(c => c.Id == post.Channel.Id);
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        public Post Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Posts.Include(p => p.User).Include(p => p.Channel).Single(a => a.Id == index);
            }
        }

        public List<Post> Get(Channel channel)
        {
            using (var context = new BoardContext())
            {
                return context.Posts.Include(p => p.Channel).Include(p => p.User).Where(p => p.Channel.Id == channel.Id).OrderByDescending(p => p.Date).ToList();
            }
        }

        public List<Post> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Posts.Include(p => p.User).Include(p => p.Channel).ToList();
            }
        }

        public List<Post> Get(string Username)
        {
            using (var context = new BoardContext())
            {
                return context.Posts.Include(p => p.User).Include(p => p.Channel).ToList();
            }
        }

        public void Drop(Post post)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dPost = context.Posts.SingleOrDefault(p => p.Id == post.Id);
                if (dPost != null)
                {
                    context.Posts.Remove(dPost);
                }

                context.SaveChanges();
            }
        }

        public void Drop(int post)
        {
            using (var context = new BoardContext())
            {
                context.Posts.Remove(context.Posts.Single(p => p.Id == post));
                context.SaveChanges();
            }
        }

        public void Edit(Post post)
        {
            using (var context = new BoardContext())
            {
                Post dbPost = context.Posts.Include(p => p.User).Include(p => p.Channel).Single(p => p.Id == post.Id);
                dbPost.Content = post.Content;
                dbPost.Title = post.Title;
                context.Entry(dbPost).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
