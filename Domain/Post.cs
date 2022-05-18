using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Post
    {

        [Key]
        public int PostID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Contents { get; set; }

        public int Audience { get; set; }

        public virtual PostAudienceGroup AudienceGroup { get; set; }

    }
}