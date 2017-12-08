using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board.Data.Models;

namespace Board.Data.Repos
{
    public class AttachmentRepo
    {
        public void Add(Attachment attach)
        {
            using (var context = new BoardContext())
            {
                context.Attachments.Add(attach);
                context.SaveChanges();
            }
        }

        public Attachment Get(int index)
        {
            using (var context = new BoardContext())
            {
                return context.Attachments.Single(a => a.Id == index);
            }
        }

        public List<Attachment> Get(Post post)
        {
            using (var context = new BoardContext())
            {
                return context.Attachments.Where(a => a.Post.Id == post.Id).ToList();
            }
        }

        public void Drop(Attachment attach)
        {
            using (var context = new BoardContext())
            {
                var dAttach = context.Attachments.Single(a => a.Id == attach.Id);
                if (dAttach != null)
                {
                    context.Attachments.Remove(dAttach);
                }

                context.SaveChanges();
            }
        }
    }
}
