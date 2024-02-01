using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOddsForMatch
{
    public record GetMatchWithOddsForMatchQuery(int MatchId) : IRequest<ErrorOr<Domain.Match>>;
}
