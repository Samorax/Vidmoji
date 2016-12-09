using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserRelatedModel
    {
        public partial class useractivity
        {
            [Key]
            public long activityid { get; set; }

            [StringLength(20)]
            public string username { get; set; }

            [StringLength(20)]
            public string poster_username { get; set; }

            [StringLength(100)]
            public string title { get; set; }

            [Column(TypeName = "text")]
            public string activity { get; set; }

            public DateTime? added_date { get; set; }

            public int? liked { get; set; }

            public int? disliked { get; set; }

            public int? comments { get; set; }
        }
        public partial class UserTag
        {
            public int Id { get; set; }

            [StringLength(20)]
            public string username { get; set; }

            [Column("contentid ")]
            public long? contentid_ { get; set; }

            [Column(TypeName = "text")]
            public string tags { get; set; }

            public byte type { get; set; }

            public byte status { get; set; }
        }

        public partial class user_playlists
        { 

        public long id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        [StringLength(100)]
        public string tags { get; set; }

        public DateTime? added_date { get; set; }

        public int videos { get; set; }

        public byte isenabled { get; set; }

        public byte privacy { get; set; }

        [Required]
        [StringLength(50)]
        public string picturename { get; set; }

        public byte isapproved { get; set; }
    }

        public partial class tag
        {
            public int tagid { get; set; }

            [Required]
            [StringLength(50)]
            public string tagname { get; set; }

            public byte status { get; set; }

            public byte tag_level { get; set; }

            public byte periority { get; set; }

            public byte type { get; set; }

            public int records { get; set; }

            public byte tag_type { get; set; }

            [StringLength(50)]
            public string term { get; set; }
        }

        public partial class playlist_videos
        {
            [Key]
            [Column(Order = 0)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public long id { get; set; }

            [Key]
            [Column(Order = 1)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public long videoid { get; set; }

            public DateTime? added_date { get; set; }
        }

        public partial class category
        {
            public short categoryid { get; set; }

            [Required]
            [StringLength(100)]
            public string categoryname { get; set; }

            public short parentid { get; set; }

            public DateTime? added_date { get; set; }

            public byte type { get; set; }

            public int priority { get; set; }

            public byte isprivate { get; set; }

            public byte mode { get; set; }

            [StringLength(50)]
            public string term { get; set; }

            [StringLength(100)]
            public string picturename { get; set; }

            [Column(TypeName = "text")]
            public string description { get; set; }

            public int records { get; set; }
        }

        public partial class favorite
        {
            public long favoriteid { get; set; }

            public long videoid { get; set; }

            [Required]
            [StringLength(20)]
            public string username { get; set; }

            public DateTime date_added { get; set; }

            public byte type { get; set; }
        }

        public partial class comment
        {
            public long commentid { get; set; }

            public long? videoid { get; set; }

            [StringLength(20)]
            public string username { get; set; }

            [Column("_comment", TypeName = "text")]
            public string C_comment { get; set; }

            public DateTime? added_date { get; set; }

            public byte isenabled { get; set; }

            public byte type { get; set; }

            public int points { get; set; }

            public byte isapproved { get; set; }

            public long replyid { get; set; }

            [StringLength(20)]
            public string profileid { get; set; }

            [StringLength(10)]
            public string level { get; set; }
        }

        public partial class user_video_history
        {
            public long id { get; set; }

            [Required]
            [StringLength(20)]
            public string username { get; set; }

            public long videoid { get; set; }

            [Column(TypeName = "date")]
            public DateTime added_date { get; set; }
        }

        public partial class user_ratings
        {
            public long id { get; set; }

            public long? itemid { get; set; }

            [StringLength(20)]
            public string username { get; set; }

            public byte type { get; set; }

            public byte rating { get; set; }
        }
    }
}