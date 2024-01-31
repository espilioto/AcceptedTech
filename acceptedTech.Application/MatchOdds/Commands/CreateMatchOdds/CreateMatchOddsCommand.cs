using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.CreateMatchOdds
{
    public record CreateMatchOddsCommand(
        int MatchId,
        string Specifier,
        decimal Odd) : IRequest<ErrorOr<acceptedTech.Domain.MatchOdds>>;
}
