using System.Collections.Generic;
using static WebApplication1.Models.MediaModels;

namespace WebApplication1.Models
{
    public class MediaCollection
    {
        public List<video> mediaVideos { get; set; }
        public List<photo> mediaPhotos { get; set; }
        public List<video> mediaAudios { get; set; }

    }
}