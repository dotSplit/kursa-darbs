using System.Data.Entity;
using Board.Data.Models;

namespace Board.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext()
            : base("name=BoardDbContext")
        {
        }


        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Announcement> Announcments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
