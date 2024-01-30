using acceptedTech.Domain.Enums;

namespace acceptedTech.Contracts.Matches
{
    public record MatchResponse(
        int Id,
        string Description,
        string MatchDate,
        string MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
