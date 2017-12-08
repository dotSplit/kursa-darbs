using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class ChannelRepo
    {
        public void Add(Channel channel)
        {
            using (var context = new BoardContext())
            {
                context.Channels.Add(channel);
                context.SaveChanges();
            }
        }


        public Channel Get(int index)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Channels.First(a => a.Id == index);
            }
        }

        public List<Channel> Get()
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Channels.ToList();
            }
        }

        public void Drop(Channel channel)
        {
            using (var context = new BoardContext())
            {
                context.Database.Log = Console.WriteLine;

                var dChannel = context.Channels.Single(u => u.Id == channel.Id);
                if (dChannel != null)
                {
                    context.Channels.Remove(dChannel);
                }

                context.SaveChanges();
            }
        }

        public void Drop(int channel)
        {
            using (var context = new BoardContext())
            {
                var dChannel = context.Channels.Single(c => c.Id == channel);
                if (dChannel != null)
                {
                    context.Channels.Remove(dChannel);
                }
                context.SaveChanges();
            }
        }
    }
}
