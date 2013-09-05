using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IhorsSlaves.Models;

namespace IhorsSlaves.Models
{
    public class ShowPostsOnPages
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}