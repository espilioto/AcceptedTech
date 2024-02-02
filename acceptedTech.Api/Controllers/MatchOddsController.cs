using acceptedTech.Api.Controllers.Common;
using acceptedTech.Application.MatchOdds.Commands.CreateMatchOdds;
using acceptedTech.Application.MatchOdds.Commands.DeleteMatchOdds;
using acceptedTech.Application.MatchOdds.Commands.UpdateMatchOdds;
using acceptedTech.Application.MatchOdds.Queries.GetMatchOdds;
using acceptedTech.Application.MatchOdds.Queries.ListMatchOdds;
using acceptedTech.Contracts.Common;
using acceptedTech.Contracts.MatchOdds;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace acceptedTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchOddsController(ISender mediator) : ApiController
    {
        private readonly ISender _mediator = mediator;

        #region Get
        [HttpGet]
        public async Task<IActionResult> ListMatchOdds()
        {
            var command = new ListMatchOddsQuery();

            var result = await _mediator.Send(command);

            return result.Match(
                match => Ok(match.Select(x => new MatchOddsResponse(
                    Id: x.Id,
                    MatchId: x.MatchId,
                    Specifier: x.Specifier.ToContractSpecifierType().GetDescription(),
                    Odd: x.Odd))),
                Problem);
        }

        [HttpGet]
        [Route("{matchoddsid:int}")]
        public async Task<IActionResult> GetMatchOdds(int matchoddsid)
        {
            var command = new GetMatchOddsQuery(matchoddsid);

            var result = await _mediator.Send(command);

            return result.Match(
                match => Ok(new MatchOddsResponse(
                    result.Value.Id,
                    result.Value.MatchId,
                    result.Value.Specifier.ToContractSpecifierType().GetDescription(),
                    result.Value.Odd)),
                Problem);
        }

        #endregion

        #region Post
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMatchOdds(CreateMatchOddsRequest request)
        {
            var command = new CreateMatchOddsCommand(
                request.MatchId,
                request.Specifier.ToDomainSpecifierType(),
                request.Odd);

            var result = await _mediator.Send(command);

            return result.Match(
                matchId => Created(string.Empty, new MatchOddsResponse(
                    result.Value.Id,
                    result.Value.MatchId,
                    result.Value.Specifier.ToContractSpecifierType().GetDescription(),
                    result.Value.Odd)),
                Problem);
        }

        #endregion

        #region Put
        [HttpPut]
        [Route("{matchoddsid:int}/update")]
        public async Task<IActionResult> UpdateMatchOdds(UpdateMatchOddsRequest request, int matchoddsid)
        {
            var command = new UpdateMatchOddsCommand(
                    matchoddsid,
                    request.MatchId, 
                    request.Specifier.ToDomainSpecifierType(),
                    request.Odd);

            var result = await _mediator.Send(command);

            return result.Match(
                match => NoContent(),
                Problem);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{matchoddsid:int}/delete")]
        public async Task<IActionResult> DeleteMatchOdds(int matchoddsid)
        {
            var command = new DeleteMatchOddsCommand(matchoddsid);

            var result = await _mediator.Send(command);

            return result.Match(
                match => NoContent(),
                Problem);
        }
        #endregion

    }
}
