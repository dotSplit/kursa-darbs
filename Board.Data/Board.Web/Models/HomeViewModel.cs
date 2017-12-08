using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Board.Data.Models;

namespace Board.Web.Models
{
    public class HomeViewModel
    {
        public PVMChannels Channels;
        public List<User> TopUsers;
    }
}