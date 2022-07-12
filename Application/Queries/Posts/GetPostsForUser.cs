using System;
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
                
                Console.WriteLine(facultyFilter + "/" + roleFilter + "/" + generationFilter);

                var posts = _context.Posts.Include(post => post.AudienceGroup)
                    .Where(post =>
                        ((post.AudienceGroup.FacultyFilter == facultyFilter) || (post.AudienceGroup.FacultyFilter == 0)) &&
                        ((post.AudienceGroup.RoleFilter == roleFilter) || (post.AudienceGroup.RoleFilter == 0)) &&
                        ((post.AudienceGroup.GenerationFilter == generationFilter) || (post.AudienceGroup.GenerationFilter == 0))
                        );

                return await posts.ToListAsync();

            }

            private bool SelectionAlgorithm(int a, int b, int c, int x, int y, int z)
            {
                
                return false;
            }

        }
    }
}