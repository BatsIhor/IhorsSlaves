using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IhorsSlaves.Models;

namespace IhorsSlaves.Models
{
    public class ViewPostModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}