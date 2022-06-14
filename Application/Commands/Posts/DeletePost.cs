using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Commands.Posts
{
    public class DeletePost
    {
        public class Command : IRequest
        {
            public int PostID { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly PostsDbContext _context;

            public Handler(PostsDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command command, CancellationToken token)
            {

                var post = await _context.Posts.FindAsync(command.PostID);

                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }

        }
    }
}