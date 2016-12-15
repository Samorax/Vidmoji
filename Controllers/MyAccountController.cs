using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.DAL;
using System.IO;
using static WebApplication1.Models.MediaModels;
using System.Threading.Tasks;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
      
        private MediaContext Media;
        private List<video> audios;
        private ApplicationUserManager UserManager;
        private List<string> VideoUploadsExt = new List<string> {"mp4","wmv","mpeg","mpg","flv","avi","rm","mov","m4v","dv","ogg","ogv","web"};
        private List<string> AudioUploadsExt = new List<string> { "mp3","wma","mp4","wmv","mpeg","mpg","flv","avi","rm","mov","mp4v","dv","ogg","ogv","webm" };
        private List<string> PhotoUploadsExt = new List<string> { "jpg","gif","png" };
        

        // GET: MyAccount
        public MyAccountController()
        {
            Media = new MediaContext();
        }
        public MyAccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            
        }

        /// <summary>
        /// This method presents a view with the current user and ability to uploads, view uploads and likes.
        /// sub-methods are: video section, audio section and photo section.
        /// </summary>
        /// <returns></returns>
        [Route("MyAccount")]
        public ActionResult Index()
        {
           var userId = User.Identity.GetUserId();
           var currentUser =  Media.Users.FirstOrDefault(u => u.Id == userId);
           return View(currentUser);
        }

        //=========================================================================Video Section ======================================================================================//
        [Route("MyAccount/UploadVideos")]
        public ActionResult UploadVideos()
        {
            var currentuser = User.Identity.GetUserName();
            var userVideoAlbums = Media.Albums.Where(a => a.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && a.type == 1);
            if (userVideoAlbums != null)
                return View(userVideoAlbums);
            else
                ViewBag.NoVideoAlbums = "<options value=''></options";
            return View();
        }

        [Route("MyAccount/VideoUploads")]
        public ActionResult UploadVideoMedia()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        [Route("MyAccount/VideoUploads/{file}")]
        public async Task<ActionResult> UploadedVideo(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength < 100 * 1000000)
                {
                    foreach (var ext in VideoUploadsExt)
                    {
                        if (file.ContentType.Contains(ext))
                        {
                            var _fileName = file.FileName;
                            var _fileStoragePath = Path.Combine(Server.MapPath("~/UploadedVideos"), _fileName);
                            var newVideo = Media.videos.Add(new video { type = 0, videofilename = _fileStoragePath, username = User.Identity.GetUserName(),date_added=DateTime.Now });
                            await Media.SaveChangesAsync();
                            file.SaveAs(_fileStoragePath);
                            ViewBag.UploadMessage = "Video File Successfully Uploaded";
                            RedirectToAction(nameof(ConfirmVideoUploads), new { id = newVideo.videoid, confirmation = ViewBag.UploadMessage });
                        }
                        else
                            ViewBag.UploadMessage = "Your file type is not supported"; continue;
                    }

                }
                else
                    ViewBag.UploadMessage = "Your file is greater than the Maximum Size (100mb) allowed";
            }
            catch (Exception)
            {
                ViewBag.UploadMessage = "File Upload Failed. Try Again.";
            }    
            
            return PartialView("_videoUploadResult");
        }

        [Route("MyAccount/Videos/VideoUploads/Confirm/{confirmation}/{id:int}")]
        public ActionResult ConfirmVideoUploads(string confirmation,int id)
        {
            var videoToConfirm = Media.videos.FirstOrDefault(p => p.videoid == id);
            if (videoToConfirm != null)
            {
                ViewBag.PhotoId = videoToConfirm.videoid;
                ViewBag.PhotoFilename = videoToConfirm.videofilename;
                ViewBag.UploadMessage = confirmation;
            }
            else
                ViewBag.ConfirmMessage = "The File You want to confrim does not exist";


            return View();
          
        }

        [HttpPost]
        [Route("MyAccount/Videos/VideoUploads/Confirm/{id:int}")]
        public async Task<ActionResult> ConfirmVideoUploads(MediaConfirmViewModel confirmUpload, int id)
        {
            if (ModelState.IsValid)
            {
                var video = Media.videos.FirstOrDefault(v => v.videoid == id);
                if (confirmUpload.Delete)
                {
                    Media.videos.Remove(video);
                    await Media.SaveChangesAsync();
                    ViewBag.ConfirmMessage = "Success: Video deleted";
                    RedirectToAction(nameof(MyVideos), new { confirmation = ViewBag.ConfirmMessage });
                }

                video.title = confirmUpload.Title;
                video.description = confirmUpload.Description;
                video.tags = confirmUpload.Tags;
                video.categories = confirmUpload.Category.ToString();
                Media.Entry(video).State = EntityState.Modified;
                Media.SaveChanges();
                ViewBag.ConfirmMessage = "Success: Video Successfully Updated";
                RedirectToAction(nameof(MyVideos), new { confirmation = ViewBag.ConfirmMessage });
            }

            return View(confirmUpload);
            
        }

        [Route("MyAccount/MyVideos")]
        public ActionResult MyVideos()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserVideos = Media.videos.Where(v => v.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && v.type == 0).ToList();
            if(currentuserVideos != null)
                return View(currentuserVideos);
            else
                ViewBag.NoVideos = "You have not uploaded any Videos";
            return View();
        }

        [Route("MyAccount/Video/CreateAlbum")]
        public ActionResult CreateVideoAlbum()
        {
            return View();
        }

        [HttpPost]
        [Route("MyAccount/Video/CreateAlbum")]
        public ActionResult CreatedVideoAlbum(AlbumViewModel album)
        {
            var currentUser = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                    Media.Albums.Add(new Galleries { UserName = currentUser, Categories = album.Categories,type=1, Title = album.Title, Description = album.Description, privacy = album.Privacy, Tags = album.Tags });
                    Media.SaveChanges();
                
                ViewBag.CreatedAlbumMessage = "Album Successfully Created.";
            }
            return View(album);
        }

        [Route("MyAccount/Video/MyAlbums")]
        public ActionResult MyVideoAlbums()
        {
            var currentuser = User.Identity.GetUserName();
           
                var currentuserVideoAlbums = Media.Albums.Where(g => g.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && g.type == 1);
                if (currentuserVideoAlbums != null)
                    return View(currentuserVideoAlbums);
                else
                    ViewBag.NoVideosinAlbum = "No Video Albums Created Yet";
            
                return View();
        }

        [Route("MyAccount/Video/MyAlbums/{id}")]
        public ActionResult SpecificVideoAlbums(int id)
        {
            
                var specificVideoAlbum = Media.Albums.FirstOrDefault(g => g.GalleriesId == id);
                if (specificVideoAlbum != null)
                    return View(specificVideoAlbum);
                else
                    ViewBag.NotExist = "This Album does not exist.";
            
                return View();
        }

        [Route("MyAccount/Video/MyLikedVideos")]
        public ActionResult MyLikedVideos()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedVideos = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 1 && u.rating == 0);
            if (currentuserLikedVideos != null)
                return View(currentuserLikedVideos);
            else
                ViewBag.NoLikedVideos = "You have no liked Videos.";
            return View();
        }

        [Route("MyAccount/Video/MyLikedAlbums")]
        public ActionResult MyLikedAlbums()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedAlbums = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 1 && u.rating == 9);
            if (currentuserLikedAlbums != null)
                return View(currentuserLikedAlbums);
            else
                ViewBag.NoLikedAblums = "You have no liked Albums";
            return View();
        }

        [Route("MyAccount/Video/favVideos")]
        public ActionResult FavVideos()
        {
            var currentUser = User.Identity.GetUserName();
            var favVidoes = Media.favorites.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase) && v.type == 1).ToList();
            if (favVidoes != null)
                return View(favVidoes);
            else
                ViewBag.NoFavVideos = "No Videos Favorited Yet.";
            return View();
        }
        //=============================================================================================Audio Section ========================================================================//

        [Route("MyAccount/AudioUploads")]
        public ActionResult UploadAudioMedia()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        [Route("MyAccount/AudioUploads")]
        public ActionResult UploadedAudio(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength < 50 * 1000000)
                {
                    foreach (var ext in AudioUploadsExt)
                    {
                        if (file.ContentType.Contains(ext))
                        {
                            var _fileName = file.FileName;
                            var _fileStoragePath = Path.Combine(Server.MapPath("~/UploadedAudios"), _fileName);
                            var newVideo = Media.videos.Add(new video { type = 1, videofilename = _fileStoragePath, username = User.Identity.GetUserName(),date_added=DateTime.Now });
                            Media.SaveChanges();
                            file.SaveAs(_fileStoragePath);
                            ViewBag.UploadMessage = "Audio File Successfully Uploaded";
                            RedirectToAction("ConfirmAudio", new { UploadMessage = ViewBag.UploadMessage });
                        }
                        else
                            ViewBag.UploadMessage = "Your file type is not supported"; continue;
                    }

                }
                else
                    ViewBag.UploadMessage = "Your file is greater than the Maximum Size (100mb) allowed";
            }
            catch (Exception)
            {
                ViewBag.UploadMessage = "File Upload Failed. Try Again.";
            }

            return PartialView("_videoUploadResult");
        }

        [Route("MyAccount/UploadAudios")]
        public ActionResult UploadAudios()
        {
            var currentuser = User.Identity.GetUserName();
            var userAudioAlbums = Media.Albums.Where(a => a.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && a.type == 2);
            if (userAudioAlbums != null)
                return View(userAudioAlbums);
            else
                ViewBag.NoVideoAlbums = "<options value=''></options";
            return View();
        }

        [Route("MyAccount/MyAudios")]
        public ActionResult MyAudios()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserAudios = Media.videos.Where(v => v.type == 0 && v.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase));
            if (currentuserAudios != null)
                return View(currentuserAudios);
            else
                ViewBag.NoAudios = "You have not uploaded any audios";
            return View();
        }

        [Route("MyAccount/Audio/CreateAlbum")]
        public ActionResult CreateAudioAlbum()
        {
            return View();
        }

        [HttpPost]
        [Route("MyAccount/Audio/CreateAlbum")]
        public ActionResult CreatedAudioAlbum(AlbumViewModel album)
        {
            var currentUser = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                
                    Media.Albums.Add(new Galleries { UserName = currentUser, Categories = album.Categories, type = 2, Title = album.Title, Description = album.Description, privacy = album.Privacy, Tags = album.Tags });
                    Media.SaveChanges();
                    ViewBag.CreatedAlbumMessage = "Album Successfully Created.";
            }
            return View(album);
        }

        [Route("MyAccount/Audio/MyAlbums")]
        public ActionResult MyAudioAlbums()
        {
            var currentuser = User.Identity.GetUserName();
            
                var currentuserAudioAlbums = Media.Albums.Where(g => g.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && g.type == 2);
                if (currentuserAudioAlbums != null)
                    return View(currentuserAudioAlbums);
                ViewBag.NoAudiosinAlbum = "No Audio Albums Created Yet";
            

                return View();
        }   

        [Route("MyAccount/Audio/MyAlbums/{id}")]
        public ActionResult SpecificAudioAlbums(int id)
        {
            
                var specificAudioAlbum = Media.Albums.FirstOrDefault(g => g.GalleriesId == id);
                if (specificAudioAlbum != null)
                    return View(specificAudioAlbum);
                ViewBag.NotExist = "This Album does not exist.";
            
                return View();
        }

        [Route("MyAccount/Audio/MyLikedAudios")]
        public ActionResult MyLikedAudios()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedAudios = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 2 && u.rating == 0);
            if (currentuserLikedAudios != null)
                return View(currentuserLikedAudios);
            ViewBag.NoLikedAudios = "You have no liked Videos.";
            return View();
        }

        [Route("MyAccount/Audio/MyLikedAlbums")]
        public ActionResult MyLikedAudioAlbums()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedAlbums = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 1 && u.rating == 9);
            if (currentuserLikedAlbums != null)
                return View(currentuserLikedAlbums);
            ViewBag.NoLikedAblums = "You have no liked Audio Albums";
            return View();
        }

        [Route("MyAccount/Audio/favAudios")]
        public ActionResult FavAudios()
        {
            var currentUser = User.Identity.GetUserName();
            var favAudios = Media.favorites.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase) && v.type == 2).ToList();
            if (favAudios != null)
                return View(favAudios);
            ViewBag.NoFavAudios = "No Audios Favorited Yet.";
            return View();
        }
        //=============================================================================================Photo Section ========================================================================//
        [Route("MyAccount/PhotoUploads")]
        public ActionResult UploadPhotoMedia()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        [Route("MyAccount/PhotoUploads")]
        public ActionResult UploadedPhoto(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength < 11 * 1000000)
                {
                    foreach (var ext in PhotoUploadsExt)
                    {
                        if (file.ContentType.Contains(ext))
                        {
                            var _fileName = file.FileName;
                            var _fileStoragePath = Path.Combine(Server.MapPath("~/UploadedPhotos"), _fileName);
                            var newVideo = Media.photos.Add(new photo { filename = _fileStoragePath, username = User.Identity.GetUserName(),added_date=DateTime.Now });
                            Media.SaveChanges();
                            file.SaveAs(_fileStoragePath);
                            ViewBag.UploadMessage = "Photo File Successfully Uploaded";
                            RedirectToAction(nameof(ConfirmPhotoUploads), new { id = newVideo.imageid });

                        
                        }
                        else
                            ViewBag.UploadMessage = "Your file type is not supported"; continue;
                    }

                }
                else
                    ViewBag.UploadMessage = "Your file is greater than the Maximum Size (100mb) allowed";
            }
            catch (Exception)
            {
                ViewBag.UploadMessage = "File Upload Failed. Try Again.";
            }

            return PartialView("_videoUploadResult");
        }
        [Route("MyAccount/UploadPhotos")]
        public ActionResult UploadPhotos()
        {
            var currentuser = User.Identity.GetUserName();
            var userPhotoAlbums = Media.Albums.Where(a => a.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && a.type == 0);
            if (userPhotoAlbums != null)
                return View(userPhotoAlbums);
            ViewBag.NoVideoAlbums = "<options value=''></options";
            return View();
        }

        [Route("MyAccount/Photos/PhotoUploads/Confirm/{id:int}")]
        public ActionResult ConfirmPhotoUploads(int id)
        {
            var photoToConfirm = Media.photos.FirstOrDefault(p => p.imageid == id);
            if (photoToConfirm != null)
            {
                ViewBag.PhotoId = photoToConfirm.imageid;
                ViewBag.PhotoFilename = photoToConfirm.filename;
            }
            else
                ViewBag.ConfirmMessage = "The File You want to confrim does not exist";


            return View();
        }

        [HttpPost]
        [Route("MyAccount/Photos/PhotoUploads/Confirm/{id:int}")]
        public ActionResult ConfirmPhotoUploads(MediaConfirmViewModel confirmMedia,int id)
        {
            if (ModelState.IsValid)
            {
                var photoToConfirm = Media.photos.FirstOrDefault(p => p.imageid == id);
                photoToConfirm.description = confirmMedia.Description;
                photoToConfirm.tags = confirmMedia.Title;
                photoToConfirm.categories = confirmMedia.Category.ToString();

                Media.Entry(photoToConfirm).State = EntityState.Modified;
                Media.SaveChanges();

                ViewBag.ConfirmationMessage = "Success: Photo Files has been Updated";
                RedirectToAction("MyPhoto", new { confirmation = ViewBag.ConfirmationMessage });
            }

            return View(confirmMedia);
        }

        [Route("MyAccount/MyPhotos/{confirmation}")]
        public ActionResult MyPhotos(string confirmation)
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserphotos = Media.photos.Where(p => p.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase));
            if (currentuserphotos != null)
            {
                if(confirmation == null)
                    ViewBag.ConfirmationMessage = "Success: Photo Files has been Updated";
                return View(currentuserphotos);
            }
                
            ViewBag.NoPhotos = "You have not uploaded any photos";
            return View();

        }
        [Route("MyAccount/Photo/CreateAlbum")]
        public ActionResult CreatePhotoAlbum()
        {
            return View();
        }

        [HttpPost]
        [Route("MyAccount/Photo/CreateAlbum")]
        public ActionResult CreatedPhotoAlbum(AlbumViewModel album)
        {
            var currentUser = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                
                    Media.Albums.Add(new Galleries { UserName = currentUser, Categories = album.Categories, type = 0, Title = album.Title, Description = album.Description, privacy = album.Privacy, Tags = album.Tags });
                    Media.SaveChanges();
                
                ViewBag.CreatedAlbumMessage = "Album Successfully Created.";
            }
                return View(album);
        }

        [Route("MyAccount/Photo/MyAlbums")]
        public ActionResult MyPhotoAlbums()
        {
            var currentuser = User.Identity.GetUserName();
           
                var currentuserPhotoAlbums = Media.Albums.Where(g => g.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && g.type == 0);
                if (currentuserPhotoAlbums != null)
                    return View(currentuserPhotoAlbums);
                ViewBag.NoPhotosinAlbum = "No Photo Albums Created Yet";
            

                return View();
        }

        [Route("MyAccount/Photo/MyAlbums/{id}")]
        public ActionResult SpecificPhotoAlbums(int id)
        {
            
                var specificPhotoAlbum = Media.Albums.FirstOrDefault(g => g.GalleriesId == id);
                if (specificPhotoAlbum != null)
                    return View(specificPhotoAlbum);
                ViewBag.NotExist = "This Album does not exist.";
            
            return View();
        }

        [Route("MyAccount/Photo/MyLikedPhotos")]
        public ActionResult MyLikedPhotos()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedPhotos = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 2 && u.rating == 0);
            if (currentuserLikedPhotos != null)
                return View(currentuserLikedPhotos);
            ViewBag.NoLikedVideos = "You have no liked Videos.";
            return View();
        }

        [Route("MyAccount/Photo/MyLikedPhotoAlbums")]
        public ActionResult MyLikedPhotoAlbums()
        {
            var currentuser = User.Identity.GetUserName();
            var currentuserLikedPhotoAlbums = Media.user_ratings.Where(u => u.username.Equals(currentuser, StringComparison.OrdinalIgnoreCase) && u.type == 2 && u.rating == 9);
            if (currentuserLikedPhotoAlbums != null)
                return View(currentuserLikedPhotoAlbums);
            ViewBag.NoLikedAblums = "You have no liked Albums";
            return View();
        }

        [Route("MyAccount/Photo/favPhotos")]
        public ActionResult FavPhotos()
        {
            var currentUser = User.Identity.GetUserName();
            var favPhotos = Media.favorites.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase) && v.type == 1).ToList();
            if (favPhotos != null)
                return View(favPhotos);
            ViewBag.NoFavPhotos = "No Photos Favorited Yet.";
            return View();
        }
        //============================================================================================= Other Section========================================================================//
        [Route("MyAccount/ProfileSetup")]
        public ActionResult ProfileSetup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MyAccount/ProfileSetup")]
        public ActionResult ProfileSetup(MyProfileSetupViewModel profileModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var currentUser = Media.Users.FirstOrDefault(u => u.Id == userId);
                currentUser.aboutme = profileModel.AboutMe; currentUser.books = profileModel.favBooks; currentUser.picturename = profileModel.ProfilePic;
                currentUser.website = profileModel.Website;currentUser.zipcode = profileModel.PostalCode; currentUser.gender = profileModel.gender;
                currentUser.firstname = profileModel.firstName; currentUser.lastname = profileModel.lastName; currentUser.occupations = profileModel.Occupation;
                currentUser.musics = profileModel.favMusics; currentUser.movies = profileModel.favMovies; currentUser.interests = profileModel.Interests;
                currentUser.companies = profileModel.Companies; currentUser.hometown = profileModel.HomeTown; currentUser.relationshipstatus = profileModel.relStatus;
                
                using(var newUser = new ApplicationDbContext())
                {
                    newUser.Entry(currentUser).State = EntityState.Modified;
                    newUser.SaveChanges();
                    ViewBag.ProfileSetupSuccess = "Your Profile has been successfully Updated";
                    return View();
                }
                
            }
            return View(profileModel);
        }

        [Route("MyAccount/EmailOptions")]
        public ActionResult EmailOptions()
        {
            if (Request.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var user = Media.Users.FirstOrDefault(u => u.Id == userid );
                ViewBag.userEmail = user.Email;
                
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("MyAccount/EmailOptions")]
        public ActionResult EmailOptions(EmailOptionsModel emailoptions)
        {

                if (ModelState.IsValid)
                {
                    var userid = User.Identity.GetUserId();
                    var user = Media.Users.FirstOrDefault(u => u.Id == userid);
                    user.Email = emailoptions.NewEmail;
                   
                    using (var newUser = new ApplicationDbContext())
                    {
                        newUser.Entry(user).State = EntityState.Modified;
                        newUser.SaveChanges();
                        ViewBag.SuccessMessage = "Email Options Successfully Updated.";
                    return View();
                    }
                }

                return View(emailoptions);                
        }
        
        [Route("MyAccount/ManageAccount")]
        public ActionResult ManageAccount()
        {
            var currentUser = User.Identity.GetUserName();
            ViewBag.UserName = currentUser;
            return View();
        }

        [HttpPost]
        [Route("MyAccount/ManageAccount")]
        public async Task<ActionResult> ManageAccount([Bind(Include ="NewPassword,ConfirmPassword,OldPassword")] ChangePasswordViewModel manageChange)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), manageChange.OldPassword, manageChange.NewPassword);
                if (result.Succeeded)
                {
                    ViewBag.ManageAccountMessage = "Your Password has been Successfuly Changed";
                    //Might want to send verification email to user to confirm whether they are the author of the change.
                }

                return View();
            }

            return View(manageChange);
        }


        [Route("MyAccount/Settings")]
        public ActionResult Settings()
        {
            
            return View();
        }

        [Route("MyAccount/Library/MyAlbums")]
        public ActionResult MyAlbums()
        {
            var currentuser = User.Identity.GetUserName();
            
                var albums = Media.Albums.Where(g => g.UserName.Equals(currentuser, StringComparison.OrdinalIgnoreCase)).ToList();
                if (albums != null)
                    return View(albums);
                ViewBag.Noalbums = "You have not created any albums";
            
                return View();
        }

        [Route("MyAccount/Library/Videos")]
        public ActionResult LibraryVideos()
        {
            //return user videos as the default view
            var currentUser = User.Identity.GetUserName();
            var myVideos = Media.videos.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase)).ToList();
            if (myVideos != null)
                return View(myVideos);
            ViewBag.NoVideos = "You have not uploaded any Videos.";
            return View();
        }

        [Route("MyAccount/Library/Audios")]
        public ActionResult LibraryAudios()
        {
            var currentUser = User.Identity.GetUserName();
            audios = Media.videos.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase) && v.type == 0).ToList();
           
            if (audios != null)
                return View(audios);
            ViewBag.NoAudios = "You have not uploaded any Audios.";
            return View();
        }

        [Route("MyAccount/Library/Photos")]
        public ActionResult LibraryPhotos()
        {
            var currentUser = User.Identity.GetUserName();
            var myphotos = Media.photos.Where(v => v.username.Equals(currentUser, StringComparison.OrdinalIgnoreCase)).ToList();
            if (myphotos != null)
                return View(myphotos);
            ViewBag.NoPhotos = "You have not uploaded any Photos.";
            return View();
        }
    }
}