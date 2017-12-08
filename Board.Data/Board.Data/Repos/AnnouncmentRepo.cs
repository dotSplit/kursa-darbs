using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class AnnouncmentRepo
    {
        public void Add(Announcement announcement)
        {
            using (var context = new BoardContext())
            {
                announcement.Administrator = context.Administrators.Single(o => o.Id == announcement.Id);
                context.Announcments.Add(announcement);
                context.SaveChanges();
            }
        }

        public Announcement Get(int id)
        {
            using (var context = new BoardContext())
            {
                return context.Announcments.Single(a => a.Id == id);
            }
        }

        public List<Announcement> Get()
        {
            using (var context = new BoardContext())
            {
                return context.Announcments.ToList();
            }
        }

        public void Drop(Announcement announcement)
        {
            using (var context = new BoardContext())
            {
                var dAnn = context.Announcments.Single(a => a.Id == announcement.Id);
                if (dAnn != null)
                {
                    context.Announcments.Remove(dAnn);
                }

                context.SaveChanges();
            }
        }
    }
}
