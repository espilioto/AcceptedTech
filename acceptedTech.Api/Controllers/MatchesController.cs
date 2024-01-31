using acceptedTech.Application.Matches.Commands.CreateMatch;
using acceptedTech.Contracts.Matches;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace acceptedTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ISender _mediator;

        public MatchesController(ISender mediator)
        {
            _mediator = mediator;
        }

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
        public async Task<IActionResult> CreateMatch(CreateMatchRequest request)
        {
            var command = new CreateMatchCommand(
                request.Description,
                request.MatchDate,
                request.MatchTime,
                request.TeamA,
                request.TeamB,
                (int)request.Sport);

            var result = await _mediator.Send(command);

            return result.MatchFirst(
                matchId => Created(string.Empty, new MatchResponse(
                                                    result.Value.Id,
                                                    request.Description,
                                                    request.MatchDate,
                                                    request.MatchTime,
                                                    request.TeamA,
                                                    request.TeamB,
                                                    request.Sport)),
                error => Problem()
                );
        }
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion
    }
}
