using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoApp.Data;
using PhotoApp.Models;
using PhotoApp.Views.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace PhotoApp.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoInterface _userService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _userId;


        


            public PhotosController(ApplicationDbContext context, IPhotoInterface userInterface, UserManager<ApplicationUser> userManager, IHttpContextAccessor _httpContext)
        {
            this._httpContext = _httpContext;
            _userManager = userManager;
            _context = context;
            _userId = this._userManager.GetUserId(this._httpContext.HttpContext.User);
            _userService = userInterface;
        }   

        // GET: Photos
        public IActionResult Index()
        {
            var photos = _userService.GetPhotos();
            var followering = _context.Follows.Where(e => e.Following == _userId).ToList();
            var peopleIseePhotosOf = new List<string>();
            List<Photo> myPics = new List<Photo>();
            foreach (var userIds in followering)
            {
                peopleIseePhotosOf.Add(userIds.Followed);
            }

            foreach (var pic in photos) {
                if (peopleIseePhotosOf.Contains(pic.Id) || (pic.Id == _userId))
                {
                    myPics.Add(pic);
                }
                //         if(pic.Id == _userId){
            }
            return View(myPics);
            }

        // GET: Photos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var photo =  _userService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhotoViewModel photoViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = _userService.UploadedFile(photoViewModel);
                ApplicationUser applicationUser = new ApplicationUser();
               
                Photo photo = new Photo();
                photo.DateCreated = photoViewModel.DateCreated;
                photo.Tittle = photoViewModel.Tittle;
                photo.ProfilePicture = uniqueFileName;
                photo.Likes = photoViewModel.Likes;
                photo.Id= _userId ;
                




                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photoViewModel);
        }


        public IActionResult MoreUsers()
        {
            var users = _context.Users.ToList();
            var followers = new UserListViewModel();
            followers.Users = users;

            return View(followers);
        }


        public void Follow(string id, string followUserName)
        {
            var follow = new Follow();
            follow.Followed = id;
            follow.Following = _userId;
            follow.followedUserEmail = followUserName;
            var applicationUser = _context.Users.FirstOrDefault(e => e.Id == _userId);
            follow.ApplicationUser = (ApplicationUser)applicationUser;
            _context.Follows.Add(follow);
            _context.SaveChanges();
        } 
        public void UnFollow(string id)
        {
            var userToUnfollow = _context.Follows.Where(e => e.Followed == id).Where(s => s.Following == _userId).ToList();
            _context.Follows.RemoveRange(userToUnfollow);
            _context.SaveChanges();
        }

        public IActionResult PeopleIFollow()
        {
          
            var followering = _context.Follows.Where(e => e.Following == _userId).Include(e => e.ApplicationUser).ToList();
            var follow = new FollowViewModel();
            follow.Follows = followering;
            return View(follow);
        }


        public IActionResult MyFollowers()
        {
            var followers = _context.Follows.Where(e => e.Followed == _userId).Include(e=> e.ApplicationUser).ToList();
            var follow = new FollowViewModel();
            follow.Follows = followers;
            return View(follow);
        }




        // GET: Photos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = _userService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoId,Tittle,DateCreated,Likes")] Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.PhotoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = _userService.GetPhotoById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = _userService.GetPhotoById(id);
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.PhotoId == id);
        }
    }
}
