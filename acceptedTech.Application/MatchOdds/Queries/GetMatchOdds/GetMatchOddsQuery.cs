using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Queries.GetMatchOdds
{
    public record GetMatchOddsQuery(int MatchOddsId) : IRequest<ErrorOr<Domain.MatchOdds>>;
}
