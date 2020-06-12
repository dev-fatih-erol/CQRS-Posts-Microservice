using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Posts.Api.Controllers
{
    public class PostController : Controller
    {
        public PostController()
        {
                
        }

        [HttpGet]
        [Route("Post/{id:length(24)}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            return Ok();
        }
    }
}