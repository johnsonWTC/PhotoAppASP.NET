using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Like> Likes { get; set; }

        public int numberofviews { get; set; }

        public List<Comment> comments { get; set; }

        public string id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
