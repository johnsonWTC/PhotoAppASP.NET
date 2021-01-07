using Microsoft.AspNetCore.Hosting;
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
    public class UserService : IUserInterface
    {
        
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserService(IWebHostEnvironment hostEnvironment)
        {
           
            webHostEnvironment = hostEnvironment;
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
