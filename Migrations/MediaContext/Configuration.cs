using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using static WebApplication1.Models.MediaModels;

namespace WebApplication1.Migrations.MediaContext
{
  

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DAL.MediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MediaContext";
        }

        protected override void Seed(WebApplication1.DAL.MediaContext context)
        {
            IList<photo> SeedPhotos = new List<photo>
            {
                new photo {filename="SeedContent/55079936.jpg",tags="honey",username="AAT",caption="honey",language="Yoruba",added_date=DateTime.Today },
                new photo {filename="SeedContent/55388500.jpg",tags="CatAndDog",username="KKT",caption="CatAndDog",language="Italian",added_date=DateTime.Today },
                new photo {filename="SeedContent/59773425.jpg",tags="Live",username="BBC",caption="Live",language="Spanish",added_date=DateTime.Today }
            };

            IList<video> SeedVideos = new List<video>
            {
                new video {videofilename="SeedContent/VID-20150928-WA0004.mp4",tags="Dog",username="Ken",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today },
                new video {videofilename="SeedContent/VID-20150928-WA0005.mp4",tags="Cat",username="balze",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today },
                new video { videofilename="SeedContent/VID-20150928-WA0010.mp4",tags="Monk",username="Jack",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today},
                new video {videofilename="SeedContent/3.im disgusted.mp3",tags="disgusted",username="blake",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today,coverurl="Images/speaker-icon.png" },
                new video { videofilename="SeedContent/hello 3.mp3",tags="hello",username="Daze",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today,coverurl="Images/speaker-icon.png"},
                new video { videofilename="SeedContent/lol audio.mp3",tags="lol",username="Eve",flv_url="WA0004.mp4",org_url="WA0004.mp4",language="Yoruba",thumbfilename="DogFood",thumb_url="WA0004.mp4",date_added=DateTime.Today,coverurl="Images/speaker-icon.png"}
            };

            foreach (var video in SeedVideos)
                context.videos.Add(video);

            foreach (var photo in SeedPhotos)
                context.photos.Add(photo);

            base.Seed(context);
        }
    }
}
