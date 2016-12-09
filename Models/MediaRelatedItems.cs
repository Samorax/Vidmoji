using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MediaRelatedItems
    {
        public enum VideoSortProperties
        {
            Recent,
            Viewed,
            Favorites,
            Liked,
            Comments
        }

        public enum PhotoSortProperties
        {
            Recent,
            Popular,
            Viewed,
            Liked
        }

        
    }
}