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
            var winData = System.IO.File.ReadAllText("./TestData/test.csv");
            string[] wins = winData.Split(',');

            var playerAWinsCount = 0;
            var playerBWinsCount = 0;

            var playerAGameCount = 0;
            var playerBGameCount = 0;

            var playerAAdvantageSetCount = 0;
            var playerBAdvantageSetCount = 0;

            foreach (var win in wins)
            {
                if (win == "1") {
                    playerAWinsCount++;
                    if (playerAWinsCount > 3 && (playerAWinsCount - playerBWinsCount) > 1) {
                        playerAGameCount ++;
                        playerAWinsCount = 0;

                        if (playerAGameCount > 5 && (playerAGameCount - playerBGameCount) > 1) {
                            playerAAdvantageSetCount ++;
                            playerAGameCount = 0;
                        }
                    }
                } else {
                    playerBWinsCount ++;
                    if (playerBWinsCount > 3 && (playerBWinsCount - playerAWinsCount) > 1) {
                        playerBGameCount ++;
                        playerBWinsCount = 0;

                        if (playerBGameCount > 5 && (playerBGameCount - playerAGameCount) > 1) {
                            playerBAdvantageSetCount ++;
                            playerBGameCount = 0;
                        }
                    }
                }
            }
            return $"Player A has {playerAAdvantageSetCount} Sets, {playerAGameCount} Games and {playerAWinsCount} Wins, Player B has {playerBAdvantageSetCount} Sets, {playerBGameCount} Games and {playerBWinsCount} Wins";
            // TODO: Implement the Get Method. Return type is "void" now however you should change this depending of what type you are going to return.
        }
    }
}
