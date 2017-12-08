using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class ReputationRepo
    {
        public void Add(Reputation rep)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var repExists =
                    context.Reputations.Any(r => r.Sender.Username == rep.Sender.Username && r.Receiver.Username == rep.Receiver.Username);

                if (!repExists)
                {
                    rep.Receiver = context.Users.Single(r => r.Username == rep.Receiver.Username);
                    rep.Sender = context.Users.Single(r => r.Username == rep.Sender.Username);
                    context.Reputations.Add(rep);
                }
                else
                {
                    var existingRep = context.Reputations.First(r => r.Sender.Id == rep.Sender.Id && r.Receiver.Id == rep.Receiver.Id);

                    if (existingRep.Amount != rep.Amount)
                    {
                        existingRep.Amount = rep.Amount;
                        context.Entry(existingRep).State = EntityState.Modified;
                    }
                }
                context.SaveChanges();

                var user = context.Users.Single(u => u.Username == rep.Receiver.Username);

                user.Reputation =
                    context.Reputations.Where(u => u.Receiver.Username == rep.Receiver.Username).Sum(r => r.Amount);

                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

            }
        }

        public Reputation Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Reputations.First(a => a.Id == index);
            }
        }

        public List<Reputation> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Reputations.ToList();
            }
        }

        public void Drop(Reputation rep)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dRep = context.Reputations.Single(u => u.Id == rep.Id);
                if (dRep != null)
                {
                    context.Reputations.Remove(dRep);
                }

                context.SaveChanges();
            }
        }

        public int GetRep(User user)
        {
            using (var context = new BoardContext())
            {
                return context.Reputations.Count(a => a.Receiver.Id == user.Id);
            }
        }
    }
}
