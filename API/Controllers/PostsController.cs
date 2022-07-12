using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Posts;
using Application.Queries.Posts;
using Application.Requests;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class PostsController : MediatorController
    {

        [HttpGet("GetAllPosts")]

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await Mediator.Send(new GetAllPosts.Query { });
        }

        [HttpGet("GetPostsForUser")]
        public async Task<IEnumerable<Post>> GetPostsForUser([FromBody] PostsReadByUserRequest filters)
        {
            return await Mediator.Send(new GetPostsForUser.Query { Filters = filters });
        }

        [HttpGet("GetPostsByAudience/{audienceId}")]

        public async Task<IEnumerable<Post>> GetPostsByAudience(int audienceId)
        {
            return await Mediator.Send(new GetPostsByAudience.Query { audienceId = audienceId });
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateRequest post)
        {
            return Ok(await Mediator.Send(new CreatePost.Command { post = post }));
        }

        [HttpDelete("DeletePost/{postId}")]

        public async Task<IActionResult> DeletePost(int postId)
        {
            return Ok(await Mediator.Send(new DeletePost.Command { PostID = postId }));
        }


        [HttpGet("SubscribeToEmails/{userId}")]
        public async Task<IActionResult> SubscribeToEmails(Guid userId)
        {
            return Ok(await Mediator.Send(new SubscribeToEmails.Command { UserId = userId }));
        }

        [HttpGet("GetUserSubscription/{userId}")]
        public async Task<ActionResult<bool>> GetUserSubscription(Guid userId)
        {
            return Ok(await Mediator.Send(new GetIfUserIsSubscribedToEmails.Query { UserId = userId }));
        }

    }
}