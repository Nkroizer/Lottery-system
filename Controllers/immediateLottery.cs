using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery_system.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lottery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class immediateLottery : ControllerBase
    {
        [HttpGet]
        public JsonResult Get([FromBody] playServiceRequest requestParams)
        {
            lotteryResults lotteryResult = new lotteryResults();

            users userScore = new users();
            if (requestParams.username == null || requestParams.tickets == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if (requestParams.tickets > 10)
                {
                    throw new ArgumentException("users are limited to 10 tickets");
                } else
                {
                    userScore.score = 0;
                    userScore.userName = requestParams.username;
                    for (int i = 0; i < requestParams.tickets; i++)
                    {
                        userScore.score += helper.getScore();
                    }
                    userScore.magic = helper.getMagicNumber(userScore.score);
                }
            }
            lotteryResult.score = userScore.score;
            lotteryResult.highest = userScore.score > globalHighScore.highestScore;
            globalHighScore.addScore(userScore);
            JsonResult returnObject = new JsonResult(lotteryResult);
            return returnObject;
        }
    }
}
