using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }  
        public string Tittle { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Like> Likes { get; set; }
       
        [Required(ErrorMessage = "Please choose profile image")]
        public string ProfilePicture { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Id { get; set; }



    }
}
