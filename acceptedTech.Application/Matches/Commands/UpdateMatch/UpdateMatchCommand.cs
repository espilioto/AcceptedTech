using acceptedTech.Domain.Enums;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.UpdateMatch
{
    public record UpdateMatchCommand(
            int Id,
            string Description,
            DateOnly MatchDate,
            TimeOnly MatchTime,
            string TeamA,
            string TeamB,
            SportType Sport) : IRequest<ErrorOr<Success>>;
}
