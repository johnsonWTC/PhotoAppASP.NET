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
        public  string PhotoOwner { get; set; }

        public string PhotoLiker { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }


    }
}
