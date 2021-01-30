using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }
        public string commentContent { get; set; }

        public int commentLikes { get; set; }

        public int commentViews { get; set; }

    [JsonIgnore]
        public Post post { get; set; }
        public int postID { get; set; }

    }
}
