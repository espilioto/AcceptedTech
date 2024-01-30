namespace acceptedTech.Contracts.Matches
{
    public record MatchResponse(
        int Id,
        string Description,
        DateOnly MatchDate,
        TimeOnly MatchTime,
        string TeamA,
        string TeamB,
        SportType Sport);
}
