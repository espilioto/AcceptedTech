using acceptedTech.Domain.Enums;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public record CreateMatchCommand(
            string Description,
            DateOnly MatchDate,
            TimeOnly MatchTime,
            string TeamA,
            string TeamB,
            int Sport) : IRequest<int>;
}
