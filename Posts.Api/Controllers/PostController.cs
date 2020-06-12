﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}