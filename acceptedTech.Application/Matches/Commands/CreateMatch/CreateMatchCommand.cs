using acceptedTech.Domain;
using acceptedTech.Domain.Enums;
using ErrorOr;
using MediatR;

namespace acceptedTech.Application.Matches.Commands.CreateMatch
{
    public record CreateMatchCommand(
            string Description,
            DateOnly MatchDate,
            TimeOnly MatchTime,
            string TeamA,
            string TeamB,
            SportType Sport) : IRequest<ErrorOr<Match>>;
}
