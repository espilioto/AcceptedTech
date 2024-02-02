using acceptedTech.Domain.Enums;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.UpdateMatchOdds
{
    public record UpdateMatchOddsCommand(
        int Id,
        int MatchId,
        SpecifierType Specifier,
        decimal Odd) : IRequest<ErrorOr<Success>>;
}
