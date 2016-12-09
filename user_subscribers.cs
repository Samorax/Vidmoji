namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_subscribers
    {
        public long id { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(20)]
        public string subscriber_username { get; set; }

        public DateTime? added_date { get; set; }
    }
}
