namespace acceptedTech.Contracts.MatchOdds
{
    public record MatchOddsResponse(
        int Id,
        int MatchId,
        string Specifier,
        decimal Odd);
}
