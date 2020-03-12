using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("TennisMatch")]
    public class TennisMatchController : ControllerBase
    {
        [HttpGet("Get")]
        public Match Get()
        {
            var winData = System.IO.File.ReadAllText("./TestData/test.csv");
            string[] wins = winData.Split(',');
            Match match = new Match();
            match.Play(wins);
            return match;
            // TODO: Implement the Get Method. Return type is "void" now however you should change this depending of what type you are going to return.
        }
    }
}
