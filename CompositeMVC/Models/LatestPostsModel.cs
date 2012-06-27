using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompositeMVC.Models
{
    public class LatestPostsModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}