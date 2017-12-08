using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Board.Web.Helpers
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException()
        {
            
        }

        public NoUserFoundException(string message) : base(message)
        {
            
        }
    }
}