using System.Collections.Generic;

namespace IhorsSlaves.Models
{
    public class ShowPostsOnPages
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}