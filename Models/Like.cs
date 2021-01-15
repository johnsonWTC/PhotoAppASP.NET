using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public  string PostOwner { get; set; }
    }
}
