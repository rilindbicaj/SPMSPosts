using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{

    public class Seed
    {

        public static async Task SeedData(PostsDbContext context)
        {

            if (!context.AudienceGroups.Any())
            {
                context.AudienceGroups.Add(new Domain.PostAudienceGroup
                {
                    AudienceGroupID = 1,
                    AudienceGroupName = "SHKI1920",
                    FacultyFilter = 1,
                    GenerationFilter = 1,
                    RoleFilter = 1
                });
            }

            if (!context.Posts.Any())
            {
                context.Posts.Add(new Domain.Post
                {
                    PostID = 1,
                    Title = "23423",
                    Date = DateTime.Now,
                    Contents = "sdfsdfsd",
                    Audience = 1
                });
            }
        }

    }

}