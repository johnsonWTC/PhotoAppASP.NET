using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Follow
    {
        public int FollowId { get; set; }
        public string Followed { get; set; }
        public string following { get; set; }
    }
}
