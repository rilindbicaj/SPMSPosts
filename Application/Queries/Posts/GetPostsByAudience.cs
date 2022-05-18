using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries.Posts
{
    public class GetPostsByAudience
    {
        public class Query : IRequest<IEnumerable<Post>>
        {
            public int audienceId { get; set; }
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
                return await _context.Posts.Where(post => post.Audience == request.audienceId)
                                            .ToListAsync();
            }

        }
    }
}