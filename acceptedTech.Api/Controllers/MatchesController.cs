using acceptedTech.Api.Controllers.Common;
using acceptedTech.Application.Matches.Commands.CreateMatch;
using acceptedTech.Application.Matches.Commands.DeleteMatch;
using acceptedTech.Application.Matches.Commands.UpdateMatch;
using acceptedTech.Application.Matches.Queries.CreateMatch;
using acceptedTech.Contracts.Common;
using acceptedTech.Contracts.Matches;
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
        public async Task<IActionResult> ListMatches()
        {
            var command = new ListMatchesQuery();

            var result = await _mediator.Send(command);

            //TODO automapper
            return result.Match(
                match => Ok(match.Select(x => new MatchResponse(
                    Id: x.Id,
                    Description: x.Description,
                    MatchDate: x.MatchDate,
                    MatchTime: x.MatchTime,
                    TeamA: x.TeamA,
                    TeamB: x.TeamB,
                    Sport: x.Sport.ToContractSportType()))),
                Problem);
        }

        [HttpGet]
        [Route("{matchid:int}")]
        public async Task<IActionResult> GetMatch(int matchid)
        {
            var command = new GetMatchQuery(matchid);

            var result = await _mediator.Send(command);

            //TODO automapper
            return result.Match(
                match => Ok(new MatchResponse(
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
        [Route("create")]
        public async Task<IActionResult> CreateMatch(CreateMatchRequest request)
        {
            //TODO automapper
            var command = new CreateMatchCommand(
                request.Description,
                request.MatchDate,
                request.MatchTime,
                request.TeamA,
                request.TeamB,
                request.Sport.ToDomainSportType());

            var result = await _mediator.Send(command);

            //TODO automapper
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
        [Route("update/{matchid:int}")]
        public async Task<IActionResult> UpdateMatch(UpdateMatchRequest request, int matchid)
        {
            //TODO automapper
            var command = new UpdateMatchCommand(
                    matchid,
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
        [Route("delete/{matchid:int}")]
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
