namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
}
