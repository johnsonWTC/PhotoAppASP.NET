using Microsoft.AspNetCore.Mvc;
using PhotoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Views.Service.Interface
{
   public interface IPhotoInterface
    {
        string UploadedFile(PhotoViewModel photoViewModel);
        Photo GetPhotoById(int? id);

        List<Photo> GetPhotos ();

    }
}
