using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class MediaModels
    {
        public partial class video
        {
            public long videoid { get; set; }

           
            public short? categoryid { get; set; }

            [Required]
            [StringLength(20)]
            public string username { get; set; }

            [StringLength(100)]
            public string title { get; set; }

            [StringLength(100)]
            public string search_term { get; set; }

            [Column(TypeName = "text")]
            public string description { get; set; }

            [StringLength(200)]
            public string tags { get; set; }

            [StringLength(20)]
            public string duration { get; set; }

            public int views { get; set; }

            public int favorites { get; set; }

            public int total_rating { get; set; }

            public int comments { get; set; }

            public int responses { get; set; }

            public float ratings { get; set; }

            public float avg_rating { get; set; }

            [Required]
            [StringLength(50)]
            public string videofilename { get; set; }

            [Required]
            [StringLength(50)]
            public string thumbfilename { get; set; }

            [StringLength(100)]
            public string originalvideofilename { get; set; }

            [Column(TypeName = "text")]
            public string embed_script { get; set; }

            public byte isenabled { get; set; }

            public byte isprivate { get; set; }

            public byte iscomments { get; set; }

            public byte isratings { get; set; }

            public byte isresponse { get; set; }

            public byte isfeatured { get; set; }

            public byte isexternal { get; set; }

            public byte isadult { get; set; }

            public int response_videoid { get; set; }

            public int duration_sec { get; set; }

            public byte ispublished { get; set; }

            public byte isreviewed { get; set; }

            [Required]
            [StringLength(200)]
            public string flv_url { get; set; }

            [Required]
            [StringLength(200)]
            public string org_url { get; set; }

            [Required]
            [StringLength(200)]
            public string thumb_url { get; set; }

            public byte errorcode { get; set; }

            public DateTime? date_added { get; set; }

            [StringLength(15)]
            public string ipaddress { get; set; }

            public byte type { get; set; }

            public int liked { get; set; }

            public int disliked { get; set; }

            [StringLength(150)]
            public string youtubeid { get; set; }

            public byte istagsreviewed { get; set; }

            [StringLength(200)]
            public string categories { get; set; }

            [Required]
            [StringLength(20)]
            public string language { get; set; }

            public int downloads { get; set; }

            public byte mode { get; set; }

            [StringLength(10)]
            public string authkey { get; set; }

            public long galleryid { get; set; }

            [StringLength(200)]
            public string coverurl { get; set; }

            [StringLength(600)]
            public string usertags { get; set; }

            public string audiocovername { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [StringLength(12)]
            public string instaID { get; set; }
        }
        public partial class photo
        {
            [Key]
            public long imageid { get; set; }
            
            [Required]
            [StringLength(20)]
            public string username { get; set; }

            [Required]
            [StringLength(100)]
            public string filename { get; set; }

            public short categoryid { get; set; }

            [Required]
            [StringLength(100)]
            public string caption { get; set; }

            [StringLength(1000)]
            public string description { get; set; }

            public byte isdisabled { get; set; }

            public byte isadult { get; set; }

            public int views { get; set; }

            public int comments { get; set; }

            public int total_ratings { get; set; }

            public float ratings { get; set; }

            public float avg_rating { get; set; }

            [StringLength(300)]
            public string tags { get; set; }

            public DateTime? added_date { get; set; }

            public int favorites { get; set; }

            public byte iscomments { get; set; }

            public byte isapproved { get; set; }

            public long galleryid { get; set; }

            public int liked { get; set; }

            public int disliked { get; set; }

            [StringLength(200)]
            public string categories { get; set; }

            public byte iswall { get; set; }

            public byte editorchoice { get; set; }

            public byte iscloud { get; set; }

            [Required]
            [StringLength(20)]
            public string language { get; set; }

            public byte mode { get; set; }

            public long nextid { get; set; }

            public long previd { get; set; }

            public byte privacy { get; set; }

            [StringLength(10)]
            public string authkey { get; set; }

            [StringLength(100)]
            public string usertags { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            [StringLength(12)]
            public string instaID { get; set; }
        }

    }
   

}