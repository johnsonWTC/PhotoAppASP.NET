using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Comment
    {
        public int commentID { get; set; }
        public string commentContent { get; set; }

        public int commentLikes { get; set; }

        public int commentViews { get; set; }

        public int postID { get; set; }

        [JsonIgnore]
        public Post post { get; set; }
    }
}
