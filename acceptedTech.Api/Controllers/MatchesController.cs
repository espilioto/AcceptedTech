using acceptedTech.Api.Controllers.Common;
using acceptedTech.Application.Matches.Commands.CreateMatch;
using acceptedTech.Application.Matches.Commands.UpdateMatch;
using acceptedTech.Contracts.Common;
using acceptedTech.Contracts.Matches;
using Azure.Core;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace acceptedTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchesController(ISender mediator) : ApiController
    {
        private readonly ISender _mediator = mediator;

        #region Get
        [HttpGet]
        [Route("matches")]
        public IActionResult ListMatches()
        {
            //return new List<MatchResponse>();
            return Ok("derp");
        }

        [HttpGet]
        [Route("matches/{matchid:int}")]
        public async Task<IActionResult> GetMatch(int matchid)
        {
            var command = new GetMatchQuery(matchid);

            var result = await _mediator.Send(command);

            return result.Match(
                match => Ok (new MatchResponse(
                    result.Value.Id,
                    result.Value.Description,
                    result.Value.MatchDate,
                    result.Value.MatchTime,
                    result.Value.TeamA,
                    result.Value.TeamB,
                    result.Value.Sport.ToContractSportType())),
                Problem);
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("creatematch")]
        public async Task<IActionResult> CreateMatch(CreateMatchRequest request)
        {
            var command = new CreateMatchCommand(
                request.Description,
                request.MatchDate,
                request.MatchTime,
                request.TeamA,
                request.TeamB,
                request.Sport.ToDomainSportType());

            var result = await _mediator.Send(command);

            return result.Match(
                matchId => Created(string.Empty, new MatchResponse(
                                                    result.Value.Id,
                                                    request.Description,
                                                    request.MatchDate,
                                                    request.MatchTime,
                                                    request.TeamA,
                                                    request.TeamB,
                                                    request.Sport)),
                Problem);
        }

        #endregion

        #region Put
        [HttpPut]
        [Route("updatematch")]
        public async Task<IActionResult> UpdateMatch(UpdateMatchRequest request)
        {
            var command = new UpdateMatchCommand(
                    request.Id,
                    request.Description,
                    request.MatchDate,
                    request.MatchTime,
                    request.TeamA,
                    request.TeamB,
                    request.Sport.ToDomainSportType()
                );

            var result = await _mediator.Send(command);

            return result.Match(
                match => NoContent(),
                Problem);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("deletematch/{matchid:int}")]
        public async Task<IActionResult> DeleteMatch(int matchid)
        {
            var command = new DeleteMatchCommand(matchid);

            var result = await _mediator.Send(command);

            return result.Match(
                match => NoContent(),
                Problem);
        }
        #endregion

    }
}
