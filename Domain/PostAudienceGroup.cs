using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PostAudienceGroup
    {

        [Key]
        public int AudienceGroupID { get; set; }

        public string AudienceGroupName { get; set; }

        public int FacultyFilter { get; set; }

        public int GenerationFilter { get; set; }

        public int RoleFilter { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}