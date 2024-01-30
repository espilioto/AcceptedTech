namespace acceptedTech.Contracts.MatchOdds
{
    public record CreateMatchOddsRequest(
        int MatchId,
        string Specifier,
        decimal Odd);
}
