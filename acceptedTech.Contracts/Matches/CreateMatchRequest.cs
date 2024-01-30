using acceptedTech.Domain.Enums;

namespace acceptedTech.Contracts.Matches
{
    public record CreateMatchRequest(
        string Description,
        string MatchDate,
        string MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
