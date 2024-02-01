namespace acceptedTech.Contracts.Matches
{
    public record UpdateMatchRequest(
        int Id,
        string Description,
        DateOnly MatchDate,
        TimeOnly MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
