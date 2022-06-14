using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Requests;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries.Posts
{
    public class GetPostsForUser
    {
        public class Query : IRequest<IEnumerable<Post>>
        {
            public PostsReadByUserRequest Filters { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Post>>
        {
            private readonly PostsDbContext _context;

            public Handler(PostsDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Post>> Handle(Query request, CancellationToken token)
            {
                var filters = request.Filters;

                int facultyFilter = filters.Faculty == null ? -1 : (int)filters.Faculty;
                int roleFilter = filters.Role == null ? -1 : (int)filters.Role;
                int generationFilter = filters.Generation == null ? -1 : (int)filters.Generation;

                var posts = _context.Posts.Include(post => post.AudienceGroup)
                    .Where(post =>
                        ((post.AudienceGroup.FacultyFilter == facultyFilter) || (facultyFilter == -1)) &&
                        ((post.AudienceGroup.RoleFilter == roleFilter) || (roleFilter == -1)) &&
                        ((post.AudienceGroup.GenerationFilter == generationFilter) || (generationFilter == -1))
                        );

                return await posts.ToListAsync();

            }

        }
    }
}