using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using static WebApplication1.Models.MediaModels;
using System.Web;
using Microsoft.AspNet.Identity;
using System;
using static WebApplication1.Models.UserRelatedModel;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private static MediaContext Media;
       
        private static MediaCollection mediaCollection;
        private static List<video> videos;
        private static List<photo> photos;
        private static List<video> audios;
        private static List<video> indexPageVideos;
        private static List<photo> indexPagePhotos;
        private static List<video> indexPageAudios;
        private static List<video> getVideosItems;
        private static List<video> videoItems;
        private static List<video> audioItems;
        private static List<photo> photoItems;
        
        public HomeController()
        {
            Media = new MediaContext();
            
        }


        public static List<T> ReturnLatestEightMedia<T>(List<T> mediaSource)
        {
            var LatestEight = new List<T>();
            for (int i = 0; i < mediaSource.Count; i++)
            {
                if (i <= 7)
                {
                    LatestEight.Add(mediaSource[i]);
                    continue;
                }
                    
                break;
            }

            return LatestEight;
            
        }

        private static List<photo> GetPhotoMediaRelatedItems(string mediaRelatedString)
        {
            List<photo> MediaRelatedItem = null;

            if (mediaRelatedString.Equals("liked", System.StringComparison.OrdinalIgnoreCase))
            {
                List<photo> MostEightLikedPhotos = null;
                if (photos != null)
                    MostEightLikedPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.liked) as List<photo>);
                photos = Media.photos.ToList();
                MostEightLikedPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.liked) as List<photo>);
                MediaRelatedItem = MostEightLikedPhotos;
            }
            else if (mediaRelatedString.Equals("viewed", System.StringComparison.OrdinalIgnoreCase))
            {
                List<photo> MostEightViewedPhotos = null;
                if (photos != null)
                    MostEightViewedPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.views) as List<photo>);
                photos = Media.photos.ToList();
                MostEightViewedPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.views) as List<photo>);
                MediaRelatedItem = MostEightViewedPhotos;
            }
            else if (mediaRelatedString.Equals("favorites", System.StringComparison.OrdinalIgnoreCase))
            {
                List<photo> MostEightFavoritePhotos = null;
                if (photos != null)
                    MostEightFavoritePhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.favorites) as List<photo>);
                photos = Media.photos.ToList();
                MostEightFavoritePhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.favorites) as List<photo>);
                MediaRelatedItem = MostEightFavoritePhotos;
            }
            else if (mediaRelatedString.Equals("comments", System.StringComparison.OrdinalIgnoreCase))
            {
                List<photo> MostEightCommentPhotos = null;
                if (photos != null)
                    MostEightCommentPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.comments) as List<photo>);
                photos = Media.photos.ToList();
                MostEightCommentPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.comments) as List<photo>);
                MediaRelatedItem = MostEightCommentPhotos;
            }
            else if (mediaRelatedString.Equals("recent", System.StringComparison.OrdinalIgnoreCase))
            {
                List<photo> MostEightRecentPhotos = null;
                if (photos != null)
                    MostEightRecentPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.added_date) as List<photo>);
                photos = Media.photos.ToList();
                MostEightRecentPhotos = ReturnLatestEightMedia(photos.OrderByDescending(v => v.added_date) as List<photo>);
                MediaRelatedItem = MostEightRecentPhotos;
            }

            return MediaRelatedItem;
        }
        private static List<video> GetVideoMediaRelatedItems(string mediaRelatedString)
        {
            List<video> MediaRelatedItem = null;
            
            if(mediaRelatedString.Equals("liked", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightLikedVideos = null;
                if(videos != null)
                    MostEightLikedVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.liked) as List<video>);
                videos = Media.videos.Where(v=>v.type==0).ToList();
                MostEightLikedVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.liked) as List<video>);
                MediaRelatedItem = MostEightLikedVideos;    
            }
            else if (mediaRelatedString.Equals("viewed", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightViewedVideos = null;
                if (videos != null)
                    MostEightViewedVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.views) as List<video>);
                videos = Media.videos.Where(v => v.type == 0).ToList();
                MostEightViewedVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.views) as List<video>);
                MediaRelatedItem = MostEightViewedVideos;
            }
            else if (mediaRelatedString.Equals("favorites", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightFavoriteVideos = null;
                if (videos != null)
                    MostEightFavoriteVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.favorites) as List<video>);
                videos = Media.videos.Where(v => v.type == 0).ToList();
                MostEightFavoriteVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.favorites) as List<video>);
                MediaRelatedItem = MostEightFavoriteVideos;
            }
            else if (mediaRelatedString.Equals("comments", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightCommentVideos = null;
                if (videos != null)
                    MostEightCommentVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.comments) as List<video>);
                videos = Media.videos.Where(v => v.type == 0).ToList();
                MostEightCommentVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.comments) as List<video>);
                MediaRelatedItem = MostEightCommentVideos;
            }
            else if (mediaRelatedString.Equals("recent", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightRecentVideos = null;
                if (videos != null)
                    MostEightRecentVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.date_added) as List<video>);
                videos = Media.videos.Where(v => v.type == 0).ToList();
                MostEightRecentVideos = ReturnLatestEightMedia(videos.OrderByDescending(v => v.date_added) as List<video>);
                MediaRelatedItem = MostEightRecentVideos;
            }

            return MediaRelatedItem;

        }

        private static List<video> GetAudioMediaRelatedItems(string mediaRelatedString)
        {
            List<video> MediaRelatedItem = null;

            if (mediaRelatedString.Equals("liked", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightLikedaudios = null;
                if (audios != null)
                    MostEightLikedaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.liked) as List<video>);
                audios = Media.videos.Where(v => v.type == 1).ToList();
                MostEightLikedaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.liked) as List<video>);
                MediaRelatedItem = MostEightLikedaudios;
            }
            else if (mediaRelatedString.Equals("viewed", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightViewedaudios = null;
                if (audios != null)
                    MostEightViewedaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.views) as List<video>);
                audios = Media.videos.Where(v => v.type == 1).ToList();
                MostEightViewedaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.views) as List<video>);
                MediaRelatedItem = MostEightViewedaudios;
            }
            else if (mediaRelatedString.Equals("favorites", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightFavoriteaudios = null;
                if (audios != null)
                    MostEightFavoriteaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.favorites) as List<video>);
                videos = Media.videos.Where(v => v.type == 1).ToList();
                MostEightFavoriteaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.favorites) as List<video>);
                MediaRelatedItem = MostEightFavoriteaudios;
            }
            else if (mediaRelatedString.Equals("comments", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightCommentaudios = null;
                if (audios != null)
                    MostEightCommentaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.comments) as List<video>);
                audios = Media.videos.Where(v => v.type == 1).ToList();
                MostEightCommentaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.comments) as List<video>);
                MediaRelatedItem = MostEightCommentaudios;
            }
            else if (mediaRelatedString.Equals("recent", System.StringComparison.OrdinalIgnoreCase))
            {
                List<video> MostEightRecentaudios = null;
                if (audios != null)
                    MostEightRecentaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.date_added) as List<video>);
                videos = Media.videos.Where(v => v.type == 1).ToList();
                MostEightRecentaudios = ReturnLatestEightMedia(audios.OrderByDescending(v => v.date_added) as List<video>);
                MediaRelatedItem = MostEightRecentaudios;
            }

            return MediaRelatedItem;

        }
        private static List<video> GetVideosItemTimings(string mediaRelatedString)
        {
            List<video> videosOfTimes = null;
            mediaRelatedString = HttpUtility.UrlDecode(mediaRelatedString);
            //check if video cache is empty.
            //if the user havent filtered items by item properties, use the default items presented on page load.
            if (videoItems == null)
                videoItems = videos.Where(v=> v.type == 0).ToList();
      
            if(mediaRelatedString != null)
            {
                if (mediaRelatedString.Equals("today", StringComparison.OrdinalIgnoreCase))
                    videosOfTimes = videoItems.Where(v => v.date_added.Value.Date == DateTime.Today).ToList();

                else if (mediaRelatedString.Equals("this week", StringComparison.OrdinalIgnoreCase))
                    videosOfTimes = videoItems.Where(v => v.date_added.Value.Date.Subtract(DateTime.Today).TotalDays == 7).ToList();

                else if (mediaRelatedString.Equals("this month", StringComparison.OrdinalIgnoreCase))
                    videosOfTimes = videoItems.Where(v => v.date_added.Value.Date.Month == DateTime.Now.Month).ToList();

                else if (mediaRelatedString.Equals("all the time", StringComparison.OrdinalIgnoreCase))
                    videosOfTimes = videoItems;
            }
            return videosOfTimes;
        }

        private static List<photo> GetPhotosItemsTimings(string mediaRelatedString)
        {
            
            List<photo> photosOfTimes = null;
            mediaRelatedString = HttpUtility.UrlDecode(mediaRelatedString);
            //check if photo cache is empty.
            //if empty, if the user havent filtered the items by items properties, use the default items presented on page load.
            if (photoItems == null)
                photoItems = photos;

            if(mediaRelatedString != null)
            {
                if (mediaRelatedString.Equals("today", StringComparison.OrdinalIgnoreCase))
                    photosOfTimes = photoItems.Where(v => v.added_date.Value.Date == DateTime.Today).ToList();

                else if (mediaRelatedString.Equals("this week", StringComparison.OrdinalIgnoreCase))
                    photosOfTimes = photoItems.Where(v => v.added_date.Value.Date.Subtract(DateTime.Today).TotalDays == 7).ToList();

                else if (mediaRelatedString.Equals("this month", StringComparison.OrdinalIgnoreCase))
                    photosOfTimes = photoItems.Where(v => v.added_date.Value.Date.Month == DateTime.Now.Month).ToList();

                else if (mediaRelatedString.Equals("all the time", StringComparison.OrdinalIgnoreCase))
                    photosOfTimes = photoItems;
            }

            return photosOfTimes;
        }

        private static List<video> GetAudioItemsTimings(string mediaRelatedString)
        {

            List<video> audiosOfTimes = null;
            mediaRelatedString = HttpUtility.UrlDecode(mediaRelatedString);
            //check if photo cache is empty.
            //if empty, if the user havent filtered the items by items properties, use the default items presented on page load.
            if (audioItems == null)
                audioItems = audios.Where(a=>a.type==1).ToList();

            if (mediaRelatedString != null)
            {
                if (mediaRelatedString.Equals("today", StringComparison.OrdinalIgnoreCase))
                    audiosOfTimes = audioItems.Where(v => v.date_added.Value.Date == DateTime.Today).ToList();

                else if (mediaRelatedString.Equals("this week", StringComparison.OrdinalIgnoreCase))
                    audiosOfTimes = audioItems.Where(v => v.date_added.Value.Date.Subtract(DateTime.Today).TotalDays == 7).ToList();

                else if (mediaRelatedString.Equals("this month", StringComparison.OrdinalIgnoreCase))
                    audiosOfTimes = audioItems.Where(v => v.date_added.Value.Date.Month == DateTime.Now.Month).ToList();

                else if (mediaRelatedString.Equals("all the time", StringComparison.OrdinalIgnoreCase))
                    audiosOfTimes = audioItems;
            }

            return audiosOfTimes;
        }



        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route(nameof(IndexMediaCollection))]
        public JsonResult IndexMediaCollection()
        {
            //Get list of videos, audios and photos from database.
            videos = Media.videos.Where(v=>v.type==0).OrderByDescending(v => v.date_added).ToList();
            audios = Media.videos.Where(v => v.type == 1).OrderByDescending(v => v.date_added).ToList();
            photos = Media.photos.OrderByDescending(v => v.added_date).ToList();

            //Return the latest eight of media.
            indexPageVideos = ReturnLatestEightMedia(videos);
            indexPagePhotos = ReturnLatestEightMedia(photos);
            indexPageAudios = ReturnLatestEightMedia(audios);

            mediaCollection = new MediaCollection { mediaVideos = indexPageVideos, mediaPhotos = indexPagePhotos, mediaAudios = indexPageAudios };
            //Pass Collection to view.
            return Json(mediaCollection, JsonRequestBehavior.AllowGet);
        }

        [Route(nameof(QuickSearch))]
        public ActionResult QuickSearch(string term)
        {
            var values = GetSearchRequests(term).mediaAudios.Select(a => new { value = a.username });
            return Json(values, JsonRequestBehavior.AllowGet);
        }

        [Route(nameof(Search))]
        public ActionResult Search(string searchTerm)
        {
            GetSearchRequests(searchTerm);
            return Json(mediaCollection, JsonRequestBehavior.AllowGet);
        }

        private static MediaCollection GetSearchRequests(string searchTerm)
        {
            List<video> audioSearchTags = null;
            List<video> videoSearchTags = null;
            List<photo> photoSearchTags = null;

            //otherwise, update video and photo cache and find search term.
            videos = Media.videos.Where(v=>v.type==0).OrderByDescending(v=>v.date_added).ToList();
            audios = Media.videos.Where(v => v.type == 1).OrderByDescending(v => v.date_added).ToList();
            photos = Media.photos.OrderByDescending(v => v.added_date).ToList();
            
            audioSearchTags = audios.FindAll(a => a.tags.Contains(searchTerm) || a.username.Contains(searchTerm));
            videoSearchTags = videos.FindAll(v => v.tags.Contains(searchTerm) || v.username.Contains(searchTerm));
            photoSearchTags = photos.FindAll(p => p.tags.Contains(searchTerm) || p.username.Contains(searchTerm));
            return mediaCollection = new MediaCollection { mediaAudios = audioSearchTags, mediaPhotos = photoSearchTags, mediaVideos = videoSearchTags };
        }

        [Route("GetVideosItems/{ItemsProps}")]
        public  ActionResult GetVideoItems(string ItemsProps)
        {
            videoItems = GetVideoMediaRelatedItems(ItemsProps);
            return PartialView("_GetVideoItems",videoItems);
        }

        [Route("GetAudiosItems/{itemsProps}")]
        public ActionResult GetAudioItems(string ItemsProps)
        {
            videoItems = GetAudioMediaRelatedItems(ItemsProps);
            return PartialView("_GetAudioItems",audioItems);
        }

        [Route("GetPhotosItems/{ItemsProps}")]
        public ActionResult GetPhotoItems(string ItemsProps)
        {
            photoItems = GetPhotoMediaRelatedItems(ItemsProps);
            return PartialView("_GetPhotoItems",photoItems);
        }

        [Route("GetVideosTime/{Filter}")]
        public ActionResult GetVideosTime(string Filter)
        {
            var mediaItems = GetVideosItemTimings(Filter);
            return PartialView("_GetVideosTime",mediaItems);
        }

        [Route("GetAudiosTime/{Filter}")]
        public ActionResult GetAudiosTime(string Filter)
        {
            var mediaItems = GetAudioItemsTimings(Filter);
            
            return PartialView("_GetAudiosTime",audios);
        }

        [Route("GetPhotosTime/{Filter}")]
        public ActionResult GetPhotosTime(string Filter)
        {
            var mediaItems = GetPhotosItemsTimings(Filter);
            return PartialView("_GetPhotosTime",mediaItems);
        }

        //==============================================================Video Section============================================================================================================//
        /// <summary>
        /// Return the videos view.
        /// </summary>
        /// <returns></returns>
        [Route(nameof(HomeController.Video))]
        public ActionResult Video()
        {
            return View();
        }

        /// <summary>
        /// return the list of videos for the video view in a json formart.
        /// </summary>
        /// <returns></returns>
        [Route(nameof(GetVideos))]
        public JsonResult GetVideos()
        {
            if (videos != null)
                return Json(videos, JsonRequestBehavior.AllowGet);
            
            videos = Media.videos.Where(v=>v.type==0).OrderByDescending(v => v.date_added).ToList();
            return Json(videos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("Video/{Id}")]
        public ActionResult VideoDetail(int Id)
        {
            //Look inside cache for the video with the requested Id and pass to view.
            //check if the videos is not null: in case the cache has been cleared due to loss in connection.
            if(videos != null)
                foreach (var video in videos)
                {
                    if (video.videoid == Id)
                        return View(video);
                    ViewBag.Message = "Not Found";
                }
            //otherwise load videos gain from Media.
            videos = Media.videos.Where(v => v.type == 0).ToList();
            foreach (var video in videos)
            {
                if (video.videoid == Id)
                    return View(video);
                ViewBag.Message = "Not Found";
            }
            //otherwise return an exception page.
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("VideoLikeness/thumbsUp/{id}")]
        public async Task<ActionResult> VideothumbsUp(int id)
        {
            var ToupdateVideo = Media.videos.FirstOrDefault(v => v.videoid == id);
            var VideoLikedCount = 0;
            

            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdateVideo.liked = ToupdateVideo.liked + 1;
                VideoLikedCount = ToupdateVideo.liked;

                Media.user_ratings.Add(new user_ratings { username = username, type = 1, rating = 0 });


                Media.Entry(ToupdateVideo).State = EntityState.Added;
                await Media.SaveChangesAsync();
                ViewBag.likes = VideoLikedCount;
                

            }
            else
            {
                    ToupdateVideo.liked = ToupdateVideo.liked + 1;
                    VideoLikedCount = ToupdateVideo.liked;
                    
                     Media.Entry(ToupdateVideo).State = EntityState.Modified;
                     await Media.SaveChangesAsync();
                     ViewBag.likes = VideoLikedCount;
                    
                }
                return PartialView("_VideothumbsUp");
        }

        [Route("VideothumbsDown/thumbsDown/{id}")]
        public async Task<ActionResult> VideothumbsDown(int id)
        {
            var ToupdateVideo = Media.videos.FirstOrDefault(v => v.videoid == id);
            var VideoDislikedCount = 0;

            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdateVideo.disliked = ToupdateVideo.disliked + 1;
                VideoDislikedCount = ToupdateVideo.disliked;

                Media.user_ratings.Add(new user_ratings { username = username, type = 1, rating = 1 });

                Media.Entry(ToupdateVideo).State = EntityState.Added;
                await Media.SaveChangesAsync();
                ViewBag.dislikes = VideoDislikedCount;
                
            }
            else 
            {
                ToupdateVideo.disliked = ToupdateVideo.disliked + 1;
                VideoDislikedCount = ToupdateVideo.disliked;
                
                    Media.Entry(ToupdateVideo).State = EntityState.Modified;
                    await Media.SaveChangesAsync();
                    ViewBag.dislikes = VideoDislikedCount;
                
            }


            return PartialView("_VideothumbsDown");
        }
    
            

        

        /// <summary>
        /// Onclick event of the add to favorite button, should send an ajax request to this route address with the video id property.
        /// if user is autenticated, update the videos table of new favorite number and add new entry to favoorites table. Send feedback to user of update status.
        /// otherwise, send an error message to user to login.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AddVideoToFavorites/{id}")]
        public async Task<ActionResult> AddVideoToFavorites(int id)
        {
            var videoToUpdate = Media.videos.FirstOrDefault(v => v.videoid == id);
            if (Request.IsAuthenticated)
            {
                videoToUpdate.favorites = videoToUpdate.favorites + 1;
                Media.favorites.Add(new favorite { username = User.Identity.GetUserName(), type=1, date_added = DateTime.Now });
                
                 Media.Entry(videoToUpdate).State = EntityState.Modified;
                 await Media.SaveChangesAsync();
                
                return PartialView("_FavoritesUpdated",videoToUpdate);
            }
            else
            {
                return PartialView("_UserLoginNotification");
            }
            
        }

        [HttpPost]
        [Route("AddVideoTags/{id}")]
        public ActionResult AddVideoTags(int id,string tags)
        {
            if (Request.IsAuthenticated)
            {
                var videoToUpadte = Media.videos.FirstOrDefault(v => v.videoid == id);
                if(videoToUpadte != null)
                {
                    
                        Media.UserTags.Add(new UserTag { username = User.Identity.GetUserName(), tags = tags, contentid_ = id});
                        Media.SaveChanges();
                    

                    return PartialView("_AddTagsFeedback");
                }
                    
            }
            return PartialView("_UserLoginNotification");
        }
        /// <summary>
        /// Monitor onplay event of video on views.
        /// Send an ajax request with the video id of included to this route.
        /// modify the views properties of the video entity.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("VideoViews/{id}")]
        public ActionResult VideoViews(int id)
        {
            var video = Media.videos.FirstOrDefault(v => v.videoid == id);
            video.views = video.views + 1;
            using(var newdb = new MediaContext())
            {
                newdb.Entry(video).State = EntityState.Modified;
                newdb.SaveChanges();
            }

            return View();
        }
        //==============================================================Audio Section============================================================================================================//
        [Route(nameof(HomeController.Audio))]
        public ActionResult Audio()
        {
            return View();
        }

        [Route(nameof(GetAudios))]
        public JsonResult GetAudios()
        {
            if (audios != null)
                return Json(audios,JsonRequestBehavior.AllowGet );
            //otherwise if video table has been modified: query the table again, update audio cache, extract audio files and pass it to views.
            audios = Media.videos.Where(v=>v.type==1).OrderByDescending(v => v.date_added).ToList();
          
            return Json(audios, JsonRequestBehavior.AllowGet);
        }

        [Route("Audio/{Id}")]
        public ActionResult AudioDetail(int Id)
        {
            //Look inside the cache for the requested audio id and pass to view.
            if(audios != null)
                foreach(var audio in audios)
                {
                    if (audio.videoid == Id)
                        return View(audio);
                    ViewBag.Message = "Audio Not Found";
                }

            //load audios again from database.
            audios = Media.videos.Where(v => v.type == 1).ToList();
            
            foreach (var audio in audios)
            {
                if (audio.videoid == Id)
                    return View(audio);
                ViewBag.Message = "Audio Not Found";
            }
            //otherwise return exception page.
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AudioLikeness/thumbsUp/{id}")]
        public async Task<ActionResult> AudiothumbsUp(int id)
        {
            var ToupdateAudio = Media.videos.FirstOrDefault(v => v.videoid == id);
            var AudioLikedCount = 0;


            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdateAudio.liked = ToupdateAudio.liked + 1;
                AudioLikedCount = ToupdateAudio.liked;
                Media.user_ratings.Add(new user_ratings { username = username, type = 0, rating = 0 });
                Media.Entry(ToupdateAudio).State = EntityState.Added;
                await Media.SaveChangesAsync();
                 ViewBag.likes = AudioLikedCount;
                

            }
            else
            {
                ToupdateAudio.liked = ToupdateAudio.liked + 1;
                AudioLikedCount = ToupdateAudio.liked;
               
                
                Media.Entry(ToupdateAudio).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                ViewBag.likes = AudioLikedCount;
                
            }
            return PartialView("_VideothumbsUp");
        }

        [Route("AudiothumbsDown/thumbsDown/{id}")]
        public async Task<ActionResult> AudiothumbsDown(int id)
        {
            var ToupdateAudio = Media.videos.FirstOrDefault(v => v.videoid == id);
            var AudioDislikedCount = 0;

            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdateAudio.disliked = ToupdateAudio.disliked + 1;
                AudioDislikedCount = ToupdateAudio.disliked;
                    Media.user_ratings.Add(new user_ratings { username = username, type = 0, rating = 1 });
                 Media.Entry(ToupdateAudio).State = EntityState.Added;
                 await Media.SaveChangesAsync();
                 ViewBag.dislikes = AudioDislikedCount;
                
            }
            else
            {
                ToupdateAudio.disliked = ToupdateAudio.disliked + 1;
                AudioDislikedCount = ToupdateAudio.disliked;
                Media.Entry(ToupdateAudio).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                ViewBag.dislikes = AudioDislikedCount;
                
            }


            return PartialView("_VideothumbsDown");
        }





        /// <summary>
        /// Onclick event of the add to favorite button, should send an ajax request to this route address with the video id property.
        /// if user is autenticated, update the videos table of new favorite number and add new entry to favoorites table. Send feedback to user of update status.
        /// otherwise, send an error message to user to login.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AddAudioToFavorites/{id}")]
        public async Task<ActionResult> AddAudioToFavorites(int id)
        {
            var audioToUpdate = Media.videos.FirstOrDefault(v => v.videoid == id);
            if (Request.IsAuthenticated)
            {
                audioToUpdate.favorites = audioToUpdate.favorites + 1;
                Media.favorites.Add(new favorite { username = User.Identity.GetUserName(), type=2, date_added = DateTime.Now });
                Media.Entry(audioToUpdate).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                
                return PartialView("_FavoritesUpdated", audioToUpdate);
            }
            else
            {
                return PartialView("_UserLoginNotification");
            }

        }

        [HttpPost]
        [Route("AddVideoTags/{id}")]
        public ActionResult AddAudioTags(int id, string tags)
        {
            if (Request.IsAuthenticated)
            {
                var audioToUpadte = Media.videos.FirstOrDefault(v => v.videoid == id);
                if (audioToUpadte != null)
                {
                    
                        Media.UserTags.Add(new UserTag { username = User.Identity.GetUserName(), tags = tags, contentid_ = id });
                        Media.SaveChanges();
                    

                    return PartialView("_AddTagsFeedback");
                }

            }
            return PartialView("_UserLoginNotification");
        }


        //======================================================================================Photo Section=============================================================================//
        [Route(nameof(HomeController.Photo))]
        public ActionResult Photo()
        {
            return View();
        }

        [Route(nameof(GetPhotos))]
        public async Task<JsonResult> GetPhotos()
        {
            if (photos != null)
                return Json(photos,JsonRequestBehavior.AllowGet);
            photos = await Media.photos.OrderByDescending(v => v.added_date).ToListAsync();
            return Json(photos, JsonRequestBehavior.AllowGet);
        }

        [Route("Photo/id")]
        public ActionResult PhotoDetail(int id)
        {
            //Look inside the cache for the requested photo id and pass to view.
            if(photos != null)
                foreach (var photo in photos)
                {
                    if (photo.imageid == id)
                        return View(photo);
                    ViewBag.Message = "Photo Not found";
                }

            //load photos again from Media.
            photos = Media.photos.ToList();
            foreach (var photo in photos)
            {
                if (photo.imageid == id)
                    return View(photo);
                ViewBag.Message = "Photo Not found";
            }

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("PhotoLikeness/thumbsUp/{id}")]
        public async Task<ActionResult> PhotothumbsUp(int id)
        {
            var ToupdatePhoto = Media.videos.FirstOrDefault(v => v.videoid == id);
            var PhotoLikedCount = 0;

            //Authenticated Users.
            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdatePhoto.liked = ToupdatePhoto.liked + 1;
                PhotoLikedCount = ToupdatePhoto.liked;

                Media.user_ratings.Add(new user_ratings { username = username, type = 2, rating = 0 });
                Media.Entry(ToupdatePhoto).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                ViewBag.likes = PhotoLikedCount;
                

            }
            else
            {
                //Anonymous Users.
                ToupdatePhoto.liked = ToupdatePhoto.liked + 1;
                PhotoLikedCount = ToupdatePhoto.liked;
                Media.Entry(ToupdatePhoto).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                ViewBag.likes = PhotoLikedCount;
                
            }
            return PartialView("_VideothumbsUp");
        }

        [Route("PhotothumbsDown/thumbsDown/{id}")]
        public async Task<ActionResult> PhotothumbsDown(int id)
        {
            var ToupdatePhoto = Media.photos.FirstOrDefault(v => v.imageid == id);
            var PhotoDislikedCount = 0;

            //Authenticated Users
            if (Request.IsAuthenticated)
            {
                var username = User.Identity.GetUserName();
                ToupdatePhoto.disliked = ToupdatePhoto.disliked + 1;
                PhotoDislikedCount = ToupdatePhoto.disliked;

                Media.user_ratings.Add(new user_ratings { username = username, type = 2, rating = 1 });
                Media.Entry(ToupdatePhoto).State = EntityState.Modified;

                await Media.SaveChangesAsync();
                ViewBag.dislikes = PhotoDislikedCount;
                
            }
            else
            {
                //Anonymous users.
                ToupdatePhoto.disliked = ToupdatePhoto.disliked + 1;
                PhotoDislikedCount = ToupdatePhoto.disliked;
                Media.Entry(ToupdatePhoto).State = EntityState.Modified;
                Media.SaveChanges();
                ViewBag.dislikes = PhotoDislikedCount;
            }
            return PartialView("_VideothumbsDown");
        }





        /// <summary>
        /// Onclick event of the add to favorite button, should send an ajax request to this route address with the video id property.
        /// if user is autenticated, update the videos table of new favorite number and add new entry to favoorites table. Send feedback to user of update status.
        /// otherwise, send an error message to user to login.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AddPhotoToFavorites/{id}")]
        public async Task<ActionResult> AddPhotoToFavorites(int id)
        {
            var photoToUpdate = Media.photos.FirstOrDefault(v => v.imageid == id);
            if (Request.IsAuthenticated)
            {
                photoToUpdate.favorites = photoToUpdate.favorites + 1;
                Media.favorites.Add(new favorite { username = User.Identity.GetUserName(), type=1, date_added = DateTime.Now });
                Media.Entry(photoToUpdate).State = EntityState.Modified;
                await Media.SaveChangesAsync();
                
                return PartialView("_FavoritesUpdated", photoToUpdate);
            }
            else
            {
                return PartialView("_UserLoginNotification");
            }

        }

        [HttpPost]
        [Route("AddPhotoTags/{id}")]
        public ActionResult AddPhotoTags(int id, string tags)
        {
            if (Request.IsAuthenticated)
            {
                var photoToUpadte = Media.photos.FirstOrDefault(v => v.imageid == id);
                if (photoToUpadte != null)
                {
                    
                        Media.UserTags.Add(new UserTag { username = User.Identity.GetUserName(), tags = tags, contentid_ = id });
                        Media.SaveChanges();
                    

                    return PartialView("_AddTagsFeedback");
                }

            }
            return PartialView("_UserLoginNotification");
        }

       //===========================================================================ChopUpload==============================================================================//
        [Route("chop")]
        public ActionResult ChopUpload()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        //public async Task<ActionResult> DropBoxChopUpload(DropBoxValues values)
        //{
        //    //if the values are truly from dropBox api
        //    if (ModelState.IsValid)
        //    {
        //        //If the user has signed in.
        //        if (Request.IsAuthenticated)
        //        {
        //            Media = new ApplicationDbContext();
        //            //Get current user instanse from database.
        //            var currentUserRow = Media.Users.FirstOrDefault(u => u.Id == User.Identity.GetUserId());

        //            //check if the file type is video or audio. other filetypes have to be specified as well.
        //            if (values.name.EndsWith(".mp4")||values.name.EndsWith(".mp3"))
        //            {
        //                currentUserRow.movies.Add(new video { videofilename = values.name, username = currentUserRow.UserName });
        //                await Media.SaveChangesAsync();
        //                return PartialView("_FileUploaded");
        //            }
        //            //check if the file type is photo
        //            else if (values.name.EndsWith(".png") || values.name.EndsWith(".jpeg") || values.name.EndsWith(".gif")|| values.name.EndsWith(".tif"))
        //            {
        //                currentUserRow.photos.Add(new photo { filename = values.name, username = currentUserRow.UserName });
        //                await Media.SaveChangesAsync();
        //                return PartialView("_FileUploaded");
        //            }
        //            else
        //                return PartialView("_UnrecognizedFileType");

        //        }
        //        return PartialView("_LoginPartial");
        //    }

        //    return View(values);
        //}

        //[HttpPost]
        //public async Task<ActionResult> DriveChopUpload(driveUploadsValues values)
        //{
        //    //If the values are truly from drive api.
        //    if (ModelState.IsValid)
        //    {
        //        //If the user has signed in.
        //        if (Request.IsAuthenticated)
        //        {
        //            Media = new ApplicationDbContext();
        //            //Get current user instanse from database.
        //            var currentUserRow = Media.Users.FirstOrDefault(u => u.Id == User.Identity.GetUserId());

        //            //if type of file uploaded is video or audio.
        //            if (values.type.Equals("video",System.StringComparison.OrdinalIgnoreCase)|| values.type.Equals("audio", System.StringComparison.OrdinalIgnoreCase))
        //            {
        //                currentUserRow.movies.Add(new video { videofilename = values.embedUrl });
        //                await Media.SaveChangesAsync();
        //                return PartialView("_FileUploaded");
        //            }
                        
        //            //if type of file uploaded is a photo or picture.
        //            else if (values.type.Equals("photo",System.StringComparison.OrdinalIgnoreCase) || values.type.Equals("picture", System.StringComparison.OrdinalIgnoreCase))
        //            {
        //                currentUserRow.photos.Add(new photo { filename = values.embedUrl });
        //                await Media.SaveChangesAsync();
        //                return PartialView("_FileUploaded");
        //            }
        //            else
        //                return PartialView("_UnrecognizedFileType");

        //        }
        //        return PartialView("_LoginPartial");
        //    }
        //    return View(values);
        //}
       

        [Route(("about"))]
        public ActionResult About()
        {
            return View();
        }

        [Route("contactus")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("terms")]
        public ActionResult Terms()
        {
            return View();
        }

        [Route("privacy")]
        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }
    }
}