using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries.Posts
{
    public class GetAllPosts
    {
        public class Query : IRequest<IEnumerable<Post>>
        {

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

                return await _context.Posts.ToListAsync();

            }

        }

    }
}