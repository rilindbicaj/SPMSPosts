using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Queries.Posts
{
    public class GetIfUserIsSubscribedToEmails
    {
        public class Query : IRequest<bool>
        {
            public Guid UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly PostsDbContext _context;

            public Handler(PostsDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.UserId);
                return user.Subscribed;
            }
        }
    }
}
