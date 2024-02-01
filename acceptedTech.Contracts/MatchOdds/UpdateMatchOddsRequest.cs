namespace acceptedTech.Contracts.MatchOdds
{
    public record UpdateMatchOddsRequest(
        int MatchId,
        string Specifier,
        decimal Odd);
}
