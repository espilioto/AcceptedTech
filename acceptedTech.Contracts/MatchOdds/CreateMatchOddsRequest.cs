namespace acceptedTech.Contracts.MatchOdds
{
    public record CreateMatchOddsRequest(
        int MatchId,
        SpecifierType Specifier,
        decimal Odd);
}
