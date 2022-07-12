using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands.Posts
{

    public class SubscribeToEmails
    {

        public class Command : IRequest
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly PostsDbContext _context;

            public Handler(PostsDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {

                var user = await _context.Users.FindAsync(request.UserId);

                user.Subscribed = !user.Subscribed;

                Console.WriteLine(user.Subscribed ? "Subscribed" : "Unsubscribed");

                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                await _context.SaveChangesAsync();

                return Unit.Value;

            }


        }

    }
}
