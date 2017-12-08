using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class PostViewModel
    {
        public List<PVMExtra> Posts;
        public PVMChannels ChannelModel;
        public PostCreateViewModel NewPost;
        public Comment NewComment;
    }

    public class PVMExtra
    {
        public Post Post;
        public int PostRating;
    }

    public class PVMChannels
    {
        public List<Channel> Channels;
        public int CurrentChannel;
        public Channel NewChannel;
    }
}