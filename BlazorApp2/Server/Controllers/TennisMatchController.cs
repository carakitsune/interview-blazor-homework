using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("TennisMatch")]
    public class TennisMatchController : ControllerBase
    {
        [HttpGet("Get")]
        public string Get()
        {
            // var wins = System.IO.File.ReadAllText("../TestData/test.csv");
            // System.Console.WriteLine("Contents of WriteText.txt = {0}", wins);
            return "blubb result";
            // TODO: Implement the Get Method. Return type is "void" now however you should change this depending of what type you are going to return.
        }
    }
}
