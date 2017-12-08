using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Board.Data.Models;
using Board.Web.Helpers;

namespace Board.Data.Repos
{
    public class UserRepo
    {
        public void Add(User user)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Users.First(a => a.Id == index);
            }
        }

        public User Get(string uname)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Users.First(a => a.Username == uname);
            }
        }

        public List<User> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Users.ToList();
            }
        }

        public void Drop(User user)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dUser = context.Users.First(u => u.Id == user.Id);
                if (dUser != null)
                {
                    context.Users.Remove(dUser);
                }

                context.SaveChanges();
            }
        }

        public void Edit(User user)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Dictionary<string, string> Login(string login, string pass)
        {
            var result = new Dictionary<string, string>();
            using (var context = new BoardContext())
            {
                var usr = context.Users.SingleOrDefault(u => (u.Username == login || u.EMail == login) && u.Password == pass);
                if (usr != null)
                {
                    var isAdmin = context.Administrators.Any(u => u.User.Id == usr.Id);
                    result.Add("Username", usr.Username);
                    result.Add("Screenname", usr.Screenname);
                    result.Add("Admin", isAdmin.ToString());
                    return result;
                }
            }
            throw new NoUserFoundException("Your Username/E-mail or Password are incorrect");
        }

        public bool EmailTaken(string EMail)
        {
            using (var context = new BoardContext())
            {
                var test = context.Users.Any(u => u.EMail == EMail);
                return test;
            }
        }

        public bool UsernameTaken(string Username)
        {
            using (var context = new BoardContext())
            {
                var test = context.Users.Any(u => u.Username == Username);
                return test;
            }
        }

        public bool ScreennameTaken(string Screenname, string OriginalScreenname)
        {
            using (var context = new BoardContext())
            {
                if (OriginalScreenname == null || Screenname != OriginalScreenname)
                {
                    var test = context.Users.Any(u => u.Screenname == Screenname);
                    return test;
                }
                return false;
            }
        }

        public List<User> GetTop()
        {
            using (var context = new BoardContext())
            {
                return context.Users.OrderByDescending(u => u.Reputation).Take(10).ToList();
            }
        }

        public List<User> GetBottom()
        {
            using (var context = new BoardContext())
            {
                return context.Users.OrderBy(u => u.Reputation).Take(10).ToList();
            }
        }

        public User Get(int? Id)
        {
            if (Id != null)
            {
                return Get(Id);
            }
            return null;
        }
    }
}
