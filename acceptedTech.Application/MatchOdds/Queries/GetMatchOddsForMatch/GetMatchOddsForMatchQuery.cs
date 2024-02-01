using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOddsForMatch
{
    public record GetMatchOddsForMatchQuery(int MatchId) : IRequest<ErrorOr<List<Domain.MatchOdds>>>;
}
