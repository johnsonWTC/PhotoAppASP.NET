using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PhotoApp.Data;
using PhotoApp.Models;
using PhotoApp.Views.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp
{
    public class UserService : IPhotoInterface
    {
        
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext _context;


        public UserService(IWebHostEnvironment hostEnvironment, ApplicationDbContext dbContext)
        {
           
            webHostEnvironment = hostEnvironment;
            _context = dbContext;
        }

        public Photo GetPhotoById(int?id)
        {
            return  _context.Photos.Find(id);
        }

        public List<Photo> GetPhotos()
        {
            return _context.Photos.Include(e => e.ApplicationUser).Include(e => e.Likes).ToList();
        }

        public string UploadedFile(PhotoViewModel photoViewModel)
        {
            string uniqueFileName = null;

            if (photoViewModel.ProfileImage != null)
            {
                string uploadsFolder = System.IO.Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photoViewModel.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photoViewModel.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
