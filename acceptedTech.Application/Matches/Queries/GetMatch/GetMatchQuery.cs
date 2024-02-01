using acceptedTech.Domain;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Queries.CreateMatch
{
    public record GetMatchQuery(int MatchId) : IRequest<ErrorOr<Match>>;
}
