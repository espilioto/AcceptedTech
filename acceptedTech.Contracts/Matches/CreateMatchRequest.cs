namespace acceptedTech.Contracts.Matches
{
    public record CreateMatchRequest(
        string Description,
        DateOnly MatchDate,
        TimeOnly MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
