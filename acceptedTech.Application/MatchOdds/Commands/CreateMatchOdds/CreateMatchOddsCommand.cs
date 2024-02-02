using acceptedTech.Domain.Enums;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.MatchOdds.Commands.CreateMatchOdds
{
    public record CreateMatchOddsCommand(
        int MatchId,
        SpecifierType Specifier,
        decimal Odd) : IRequest<ErrorOr<Domain.MatchOdds>>;
}
