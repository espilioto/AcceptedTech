namespace acceptedTech.Contracts.Matches
{
    public record UpdateMatchRequest(
        string Description,
        DateOnly MatchDate,
        TimeOnly MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
