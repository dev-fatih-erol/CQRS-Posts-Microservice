﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.Application.Commands;
using Posts.Application.Queries;

namespace Posts.Api.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("User/{userId:int}/Post")]
        public async Task<IActionResult> GetByUserId([FromRoute]int userId, [FromQuery]int pageIndex = 1)
        {
            return Ok(await _mediator.Send(new GetPostByUserIdQuery(userId, pageIndex)));
        }

        [HttpGet]
        [Route("Post/{id:length(24)}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var post = await _mediator.Send(new GetPostByIdQuery(id));

            if (post != null)
            {
                return Ok(post);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Create([FromBody]CreatePostCommand command)
        {
            var post = await _mediator.Send(command);

            return Created($"Post/{post.Id}", post);
        }
    }
}