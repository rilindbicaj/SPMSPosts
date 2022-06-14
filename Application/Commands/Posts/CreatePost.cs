using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Requests;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands.Posts
{
    public class CreatePost
    {
        public class Command : IRequest
        {
            public PostCreateRequest post { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly PostsDbContext _context;
            private readonly IMapper _mapper;

            public Handler(PostsDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command command, CancellationToken token)
            {
                var post = _mapper.Map<Post>(command.post);
                
                post.Date = DateTime.Now;

                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }

        }
    }
}