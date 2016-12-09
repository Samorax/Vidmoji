namespace WebApplication1.Migrations.MediaContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.photos",
                c => new
                    {
                        imageid = c.Long(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20, unicode: false),
                        filename = c.String(nullable: false, maxLength: 100, unicode: false),
                        categoryid = c.Short(nullable: false),
                        caption = c.String(nullable: false, maxLength: 100, unicode: false),
                        description = c.String(maxLength: 1000, unicode: false),
                        isdisabled = c.Byte(nullable: false),
                        isadult = c.Byte(nullable: false),
                        views = c.Int(nullable: false),
                        comments = c.Int(nullable: false),
                        total_ratings = c.Int(nullable: false),
                        ratings = c.Single(nullable: false),
                        avg_rating = c.Single(nullable: false),
                        tags = c.String(maxLength: 300, unicode: false),
                        added_date = c.DateTime(),
                        favorites = c.Int(nullable: false),
                        iscomments = c.Byte(nullable: false),
                        isapproved = c.Byte(nullable: false),
                        galleryid = c.Long(nullable: false),
                        liked = c.Int(nullable: false),
                        disliked = c.Int(nullable: false),
                        categories = c.String(maxLength: 200, unicode: false),
                        iswall = c.Byte(nullable: false),
                        editorchoice = c.Byte(nullable: false),
                        iscloud = c.Byte(nullable: false),
                        language = c.String(nullable: false, maxLength: 20, unicode: false),
                        mode = c.Byte(nullable: false),
                        nextid = c.Long(nullable: false),
                        previd = c.Long(nullable: false),
                        privacy = c.Byte(nullable: false),
                        authkey = c.String(maxLength: 10, unicode: false),
                        usertags = c.String(maxLength: 100, unicode: false),
                        instaID = c.String(maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.imageid);
            
            CreateTable(
                "dbo.videos",
                c => new
                    {
                        videoid = c.Long(nullable: false, identity: true),
                        categoryid = c.Short(),
                        username = c.String(nullable: false, maxLength: 20, unicode: false),
                        title = c.String(maxLength: 100, unicode: false),
                        search_term = c.String(maxLength: 100, unicode: false),
                        description = c.String(unicode: false, storeType: "text"),
                        tags = c.String(maxLength: 200, unicode: false),
                        duration = c.String(maxLength: 20, unicode: false),
                        views = c.Int(nullable: false),
                        favorites = c.Int(nullable: false),
                        total_rating = c.Int(nullable: false),
                        comments = c.Int(nullable: false),
                        responses = c.Int(nullable: false),
                        ratings = c.Single(nullable: false),
                        avg_rating = c.Single(nullable: false),
                        videofilename = c.String(nullable: false, maxLength: 50, unicode: false),
                        thumbfilename = c.String(nullable: false, maxLength: 50, unicode: false),
                        originalvideofilename = c.String(maxLength: 100, unicode: false),
                        embed_script = c.String(unicode: false, storeType: "text"),
                        isenabled = c.Byte(nullable: false),
                        isprivate = c.Byte(nullable: false),
                        iscomments = c.Byte(nullable: false),
                        isratings = c.Byte(nullable: false),
                        isresponse = c.Byte(nullable: false),
                        isfeatured = c.Byte(nullable: false),
                        isexternal = c.Byte(nullable: false),
                        isadult = c.Byte(nullable: false),
                        response_videoid = c.Int(nullable: false),
                        duration_sec = c.Int(nullable: false),
                        ispublished = c.Byte(nullable: false),
                        isreviewed = c.Byte(nullable: false),
                        flv_url = c.String(nullable: false, maxLength: 200, unicode: false),
                        org_url = c.String(nullable: false, maxLength: 200, unicode: false),
                        thumb_url = c.String(nullable: false, maxLength: 200, unicode: false),
                        errorcode = c.Byte(nullable: false),
                        date_added = c.DateTime(),
                        ipaddress = c.String(maxLength: 15, unicode: false),
                        type = c.Byte(nullable: false),
                        liked = c.Int(nullable: false),
                        disliked = c.Int(nullable: false),
                        youtubeid = c.String(maxLength: 150, unicode: false),
                        istagsreviewed = c.Byte(nullable: false),
                        categories = c.String(maxLength: 200, unicode: false),
                        language = c.String(nullable: false, maxLength: 20, unicode: false),
                        downloads = c.Int(nullable: false),
                        mode = c.Byte(nullable: false),
                        authkey = c.String(maxLength: 10, unicode: false),
                        galleryid = c.Long(nullable: false),
                        coverurl = c.String(maxLength: 200, unicode: false),
                        usertags = c.String(maxLength: 600, unicode: false),
                        audiocovername = c.String(unicode: false),
                        instaID = c.String(maxLength: 12, unicode: false),
                    })
                .PrimaryKey(t => t.videoid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.videos");
            DropTable("dbo.photos");
        }
    }
}
