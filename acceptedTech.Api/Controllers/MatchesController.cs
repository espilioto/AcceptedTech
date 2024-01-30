using acceptedTech.Contracts.Matches;
using Microsoft.AspNetCore.Mvc;

namespace acceptedTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        #region Get
        [HttpGet]
        [Route("matches")]
        public IActionResult GetMatches()
        {
            //return new List<MatchResponse>();
            return Ok("derp");
        }

        [HttpGet]
        [Route("matches/{matchid}")]
        public IActionResult GetMatch(int matchid)
        {
            //return new MatchResponse();
            return Ok(matchid);
        }

        [HttpGet]
        [Route("matchodds/{matchoddsid}")]
        public IActionResult GetMatchOdds(int matchoddsid)
        {
            //return new List<MatchOddsResponse>();
            return Ok(matchoddsid);
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("createMatch")]
        public IActionResult CreateMatch(CreateMatchRequest request)
        {
            return Ok(request);
        }
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion
    }
}
