using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }
        public string PhotoOwner { get; set; }

        public string PhotoSharer { get; set; }

        public int PhotoId { get; set; }

        public Photo Photo { get; set; }
    }
}
