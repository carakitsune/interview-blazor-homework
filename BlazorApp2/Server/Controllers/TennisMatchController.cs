using BlazorApp2.Shared;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("TennisMatch")]
    public class TennisMatchController : ControllerBase
    {
        [HttpGet("Get")]
        public void Get()
        {
            // TODO: Implement the Get Method. Return type is "void" now however you should change this depending of what type you are going to return.
        }



    }


}
