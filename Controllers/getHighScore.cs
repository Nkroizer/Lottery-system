using Microsoft.AspNetCore.Mvc;
using Lottery_system.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lottery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getHighScore : ControllerBase
    {
        // GET: api/<getHighScore>
        [HttpGet]
        public JsonResult Get()
        {
            users winner = new users();
            winner = helper.getWiner();
            JsonResult returnObject = new JsonResult(winner);
            return returnObject;
        }
    }
}
