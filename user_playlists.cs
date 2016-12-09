namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
}
