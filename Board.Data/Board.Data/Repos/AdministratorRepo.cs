using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class AdministratorRepo
    {
        public void Add(Administrator admin)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Administrators.Add(admin);
                context.SaveChanges();
            }
        }

        public Administrator Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Administrators.First(a => a.Id == index);
            }
        }

        public List<Administrator> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Administrators.ToList();
            }
        }

        public void Drop(Administrator admin)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dAdmin = context.Administrators.Single(u => u.Id == admin.Id);
                if (dAdmin != null)
                {
                    context.Administrators.Remove(dAdmin);
                }

                context.SaveChanges();
            }
        }
    }
}
