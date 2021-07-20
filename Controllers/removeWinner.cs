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
    public class removeWinner : ControllerBase
    {
        // GET: api/<removeWinner>
        [HttpGet]
        public JsonResult Get()
        {
            users winner = new users();
            winner = helper.getWiner();
            globalHighScore.removeScore(winner);
            winner = helper.getWiner();
            JsonResult returnObject = new JsonResult(winner);
            return returnObject;
        }
    }
}
