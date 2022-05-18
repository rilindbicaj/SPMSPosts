using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.Posts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{

    public class PostsController : MediatorController
    {

        [HttpGet("GetAllPosts")]

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await Mediator.Send(new GetAllPosts.Query { });
        }

        [HttpGet("GetPostsByAudience/{audience}")]

        public async Task<IEnumerable<Post>> GetPostsByAudience(int audience)
        {
            return await Mediator.Send(new GetPostsByAudience.Query { audienceId = audience });
        }


    }
}