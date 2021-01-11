using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }
        public string Followed { get; set; }
        public string Following { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Id { get; set; }
    }
}
