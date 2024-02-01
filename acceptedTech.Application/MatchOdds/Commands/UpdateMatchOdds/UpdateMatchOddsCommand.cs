using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.UpdateMatchOdds
{
    public record UpdateMatchOddsCommand(
        int Id,
        int MatchId,
        string Specifier,
        decimal Odd) : IRequest<ErrorOr<Success>>;
}
