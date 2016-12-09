namespace WebApplication1.Migrations.MediaContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleriesId = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Categories = c.String(),
                        UserName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Tags = c.String(),
                        isDisabled = c.Int(nullable: false),
                        isApproved = c.Int(nullable: false),
                        Added_Date = c.DateTime(nullable: false),
                        language = c.String(),
                        type = c.Int(nullable: false),
                        mode = c.String(),
                        privacy = c.Int(nullable: false),
                        authkey = c.String(),
                    })
                .PrimaryKey(t => t.GalleriesId);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        categoryid = c.Short(nullable: false, identity: true),
                        categoryname = c.String(nullable: false, maxLength: 100),
                        parentid = c.Short(nullable: false),
                        added_date = c.DateTime(),
                        type = c.Byte(nullable: false),
                        priority = c.Int(nullable: false),
                        isprivate = c.Byte(nullable: false),
                        mode = c.Byte(nullable: false),
                        term = c.String(maxLength: 50),
                        picturename = c.String(maxLength: 100),
                        description = c.String(unicode: false, storeType: "text"),
                        records = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.categoryid);
            
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        commentid = c.Long(nullable: false, identity: true),
                        videoid = c.Long(),
                        username = c.String(maxLength: 20),
                        _comment = c.String(unicode: false, storeType: "text"),
                        added_date = c.DateTime(),
                        isenabled = c.Byte(nullable: false),
                        type = c.Byte(nullable: false),
                        points = c.Int(nullable: false),
                        isapproved = c.Byte(nullable: false),
                        replyid = c.Long(nullable: false),
                        profileid = c.String(maxLength: 20),
                        level = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.commentid);
            
            CreateTable(
                "dbo.favorites",
                c => new
                    {
                        favoriteid = c.Long(nullable: false, identity: true),
                        videoid = c.Long(nullable: false),
                        username = c.String(nullable: false, maxLength: 20),
                        date_added = c.DateTime(nullable: false),
                        type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.favoriteid);
            
            CreateTable(
                "dbo.playlist_videos",
                c => new
                    {
                        id = c.Long(nullable: false),
                        videoid = c.Long(nullable: false),
                        added_date = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.id, t.videoid });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tags",
                c => new
                    {
                        tagid = c.Int(nullable: false, identity: true),
                        tagname = c.String(nullable: false, maxLength: 50),
                        status = c.Byte(nullable: false),
                        tag_level = c.Byte(nullable: false),
                        periority = c.Byte(nullable: false),
                        type = c.Byte(nullable: false),
                        records = c.Int(nullable: false),
                        tag_type = c.Byte(nullable: false),
                        term = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.tagid);
            
            CreateTable(
                "dbo.user_playlists",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        username = c.String(maxLength: 20),
                        title = c.String(maxLength: 50),
                        description = c.String(maxLength: 300),
                        tags = c.String(maxLength: 100),
                        added_date = c.DateTime(),
                        videos = c.Int(nullable: false),
                        isenabled = c.Byte(nullable: false),
                        privacy = c.Byte(nullable: false),
                        picturename = c.String(nullable: false, maxLength: 50),
                        isapproved = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user_ratings",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        itemid = c.Long(),
                        username = c.String(maxLength: 20),
                        type = c.Byte(nullable: false),
                        rating = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user_video_history",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20),
                        videoid = c.Long(nullable: false),
                        added_date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.useractivities",
                c => new
                    {
                        activityid = c.Long(nullable: false, identity: true),
                        username = c.String(maxLength: 20),
                        poster_username = c.String(maxLength: 20),
                        title = c.String(maxLength: 100),
                        activity = c.String(unicode: false, storeType: "text"),
                        added_date = c.DateTime(),
                        liked = c.Int(),
                        disliked = c.Int(),
                        comments = c.Int(),
                    })
                .PrimaryKey(t => t.activityid);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        countryname = c.String(),
                        firstname = c.String(),
                        lastname = c.String(),
                        gender = c.String(),
                        birthdate = c.DateTime(),
                        views = c.Int(nullable: false),
                        picturename = c.String(),
                        isenabled = c.Byte(nullable: false),
                        issendmessages = c.Byte(nullable: false),
                        isallowbirthday = c.Byte(nullable: false),
                        register_date = c.DateTime(),
                        last_login = c.DateTime(),
                        val_key = c.String(),
                        relationshipstatus = c.String(),
                        aboutme = c.String(),
                        website = c.String(),
                        hometown = c.String(),
                        currentcity = c.String(),
                        zipcode = c.String(),
                        occupations = c.String(),
                        companies = c.String(),
                        schools = c.String(),
                        interests = c.String(),
                        photos = c.String(),
                        movies = c.String(),
                        musics = c.String(),
                        books = c.String(),
                        isautomail = c.Byte(nullable: false),
                        mail_vcomment = c.Byte(nullable: false),
                        mail_ccomment = c.Byte(nullable: false),
                        mail_pmessage = c.Byte(nullable: false),
                        mail_finvite = c.Byte(nullable: false),
                        mail_subscribe = c.Byte(nullable: false),
                        privacy_fmessages = c.Byte(nullable: false),
                        videos_watched = c.Int(nullable: false),
                        subscribers = c.Int(nullable: false),
                        channel_iscomments = c.Byte(nullable: false),
                        channel_isfriends = c.Byte(nullable: false),
                        channel_issubscribers = c.Byte(nullable: false),
                        channel_isgroups = c.Byte(nullable: false),
                        channel_isphotos = c.Byte(nullable: false),
                        channel_isblogs = c.Byte(nullable: false),
                        channel_isaudios = c.Byte(nullable: false),
                        channel_name = c.String(),
                        channel_theme = c.String(),
                        stat_videos = c.Int(nullable: false),
                        stat_friends = c.Int(nullable: false),
                        stat_subscribers = c.Int(nullable: false),
                        stat_favorites = c.Int(nullable: false),
                        stat_groups = c.Int(nullable: false),
                        stat_messages = c.Int(nullable: false),
                        stat_comments = c.Int(nullable: false),
                        stat_photos = c.Int(nullable: false),
                        stat_blogs = c.Int(nullable: false),
                        stat_audios = c.Int(nullable: false),
                        stat_audiofavorites = c.Int(nullable: false),
                        type = c.Byte(nullable: false),
                        _readonly = c.Byte(nullable: false),
                        fb_uid = c.String(),
                        credits = c.Int(nullable: false),
                        remained_video = c.Int(nullable: false),
                        remained_audio = c.Int(nullable: false),
                        remained_gallery = c.Int(nullable: false),
                        remained_photos = c.Int(nullable: false),
                        remained_blogs = c.Int(nullable: false),
                        space_video = c.Int(nullable: false),
                        space_audio = c.Int(nullable: false),
                        space_photos = c.Int(nullable: false),
                        roleid = c.Int(nullable: false),
                        stat_forum_posts = c.Int(nullable: false),
                        stat_forum_points = c.Int(nullable: false),
                        last_purchased = c.DateTime(),
                        membership_expiry = c.DateTime(),
                        islifetimerenewal = c.Byte(nullable: false),
                        paypal_subscriber = c.Byte(nullable: false),
                        paypal_email = c.String(),
                        stat_qa = c.Short(nullable: false),
                        stat_qanswers = c.Short(nullable: false),
                        stat_qafavorites = c.Short(nullable: false),
                        stat_photofavorites = c.Short(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 20),
                        contentid = c.Long(name: "contentid "),
                        tags = c.String(unicode: false, storeType: "text"),
                        type = c.Byte(nullable: false),
                        status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserTags");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.useractivities");
            DropTable("dbo.user_video_history");
            DropTable("dbo.user_ratings");
            DropTable("dbo.user_playlists");
            DropTable("dbo.tags");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.playlist_videos");
            DropTable("dbo.favorites");
            DropTable("dbo.comments");
            DropTable("dbo.categories");
            DropTable("dbo.Galleries");
        }
    }
}
